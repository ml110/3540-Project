///////////////////////////////////////////////////////////////////////////////////////////////////
/* CSIS 3540 - CLIENT SERVER SYSTEMS
 * CRUISE LINE PROJECT - SHIPBOARD APPLICATION - SCHEDULE MANAGER FORM
 * 
 * This form is for managing the schedule of the staff aboard the ship on a given trip
 * 
 */
///////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
///////////////////////////////////////////////////////////////////////////////////////////////////
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CruiseControl
{
	public partial class ScheduleForm : Form
	{
		//SQL Connection
		private MySqlConnection connection;
		MySqlCommand command;

		private int tripNum;
		private string shiftStart = "";
		private string shiftEnd = "";
        private int staffID;

        //I need this for reasons
        Cruncher beepBoop;
		
		public ScheduleForm(int TN, MySqlConnection con, MySqlCommand cmd)
		{
			InitializeComponent();
			connection = con;
			command = cmd;
			tripNum = TN;

            beepBoop = new Cruncher(connection, command);
		}

		private void ScheduleForm_Load(object sender, EventArgs e)
		{
			string dateQuery = "SELECT trip_date FROM TRIP_ITINERARY WHERE trip_id = '" + tripNum + "';";
			setupComboBox(cbDay, dateQuery);

			// readies the department combobox in DISPLAY OPTIONS
			string deptQuery = "SELECT dept_name FROM DEPARTMENT";
			cbDept.Items.Add("-----");
			setupComboBox(cbDept, deptQuery);
			
			//need to cut the times from the date options in the CB
			for (int i = 0; i < cbDay.Items.Count; i++)
			{
				//funky date format/string conversions
				string day = cbDay.Items[i].ToString();
				DateTime dateFormat = DateTime.Parse(day);
				string d = dateFormat.ToString("yyyy-MM-dd");
				cbDay.Items[i] = d.Trim();
			}
			
			//Readies the date combobox in DISPLAY OPTIONS
			cbDay.Text = cbDay.Items[0].ToString();
			string theDay = cbDay.Text.Trim();
			updateDisplay(theDay);

			//readies the department combobox in SCHEDULE NEW SHIFT
			setupComboBox(cbAddDept, deptQuery);

		}

		//loads a combobox with options that are the result of a SQL query
		//IMPORTANT: Queries must only return a single column!
		private void setupComboBox(ComboBox CB, string QUERY)
		{
			if (CB.Enabled == false)
			{
				CB.Enabled = true;
			}

			command.CommandText = QUERY;
			command.Connection = connection;
			MySqlDataReader sRead = command.ExecuteReader();

			while (sRead.Read())
			{
				for (int i = 0; i < sRead.FieldCount; i++)
				{
					CB.Items.Add(sRead[i].ToString());
				}
			}

			sRead.Close();

		}

		//DAY
		private void cbDay_SelectedIndexChanged(object sender, EventArgs e)
		{
			string theDay = cbDay.Text.Trim();
			updateDisplay(theDay);
		}

		//DEPTARMENT
		private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
		{
			string theDay = cbDay.Text.Trim();
			updateDisplay(theDay);
		}

		//THIS METHOD UPDATES THE DISPLAY
		private void updateDisplay(string day)
		{
			DataSet ds = new DataSet();
			dgvSched.DataSource = null;
			MySqlDataAdapter MDA;
			
			string query = "SELECT SS.shift_date AS SHIFTDATE, concat(SH.shift_start, \" - \" , SH.shift_end) AS SHIFT, concat(ST.staff_lastname, \", \", ST.staff_firstname) AS STAFF, J.job_title AS DUTY, WA.area_name AS DUTYAREA, D.dept_name AS DEPT FROM STAFF_SHIFT AS SS";
				query += " INNER JOIN SHIFT AS SH ON SS.shift_id = SH.shift_id";
				query += " INNER JOIN STAFF AS ST ON SS.staff_id = ST.staff_id";
				query += " INNER JOIN JOBS AS J ON ST.job_id = J.job_id";
				query += " INNER JOIN DEPARTMENT AS D ON J.dept_id = D.dept_id";
				query += " INNER JOIN WORKAREAS AS WA ON SH.area_id = WA.area_id";
				query += " WHERE SH.trip_id = " + tripNum + " AND SS.shift_date = \"" + day + "\"";

			if (cbDept.Text != "-----") //check for 'none'
			{
				query += " AND D.dept_name = \"" + cbDept.Text.Trim() + "\"";
			}

			query += " ORDER BY SS.shift_date, SH.shift_start";

			if (cbDept.Text == "-----") //check for 'none'
			{
				query += " , D.dept_id";
			}

			MDA = new MySqlDataAdapter(query, connection);
			MDA.Fill(ds, "SCHED");

			dgvSched.DataSource = ds.Tables["SCHED"];
		}

		//when the user selects a department, the workarea CB needs to update as well as the staff CB
		private void cbAddDept_SelectedIndexChanged(object sender, EventArgs e)
		{
			cbAddArea.Items.Clear();
			cbAddArea.Text = null;
			cbName.Items.Clear();
			cbName.Text = null;

			string empQuery = "SELECT concat(\"[\", ST.staff_id, \"] \", upper(J.job_title_code), \". \", ST.staff_firstname, \" \", ST.staff_lastname) AS STAFF FROM STAFF AS ST";
				empQuery += " INNER JOIN TRIP AS T ON ST.ship_id = T.ship_id";
				empQuery += " INNER JOIN JOBS AS J ON ST.job_id = J.job_id";
				empQuery += " INNER JOIN DEPARTMENT AS D ON J.dept_id = D.dept_id";
				empQuery += " WHERE T.trip_id = " + tripNum + " AND D.dept_name = \"" + cbAddDept.Text + "\"";
			string waQuery = "SELECT WA.area_name FROM WORKAREAS AS WA";

			if (cbAddDept.Text != "SECURITY".Trim()) //SECURITY CAN GO ANYWHERE HEH
			{
				waQuery += " INNER JOIN DEPARTMENT AS D ON WA.dept_id = D.dept_id WHERE D.dept_name = \"" + cbAddDept.Text + "\";";
			}

			setupComboBox(cbAddArea, waQuery);
			setupComboBox(cbName, empQuery);

			//enable the controls
			if (cbAddDept.Text != null)
			{
				cbAddArea.Enabled = true;
				cbName.Enabled = true;
				rbAfternoon.Enabled = true;
				rbEvening.Enabled = true;
				rbMorning.Enabled = true;
			}

            validateButton();
		}

/////// Next several methods for insertion prep ////////////////////////////////////////////////////////
		
		//sets the shift times from the radio buttons
		private void setShiftTimes()
		{
			if (rbMorning.Checked == true)
			{
				shiftStart = "00:00:00";
				shiftEnd = "08:00:00";
			}
			else
			{
				if (rbAfternoon.Checked == true)
				{
					shiftStart = "08:00:00";
					shiftEnd = "16:00:00";
				}
				else
				{
					if (rbEvening.Checked == true)
					{
						shiftStart = "16:00:00";
						shiftEnd = "23:00:00";
					}
				}
			}
		}

        //Ensure all the fields are filled, then enable the insert button
        private void validateButton()
        {
            bool flag = false;
            setShiftTimes();
            Debug.WriteLine("CHECK START: " + flag);
            Debug.WriteLine(cbAddDept.Text + " " + cbAddArea.Text + " " + cbName.Text + " " + shiftStart);

            if (cbAddDept.Text != null && cbAddArea.Text != null && cbName.Text != null && shiftStart != "")
            {
                flag = true;
            }

            if (flag == true)
            {
                btnInsert.Enabled = true;
            }
            else
            {
                btnInsert.Enabled = false;
            }

            Debug.WriteLine("CHECK END: " + flag);
        }

		//Insert the values into the database
		private void btnInsert_Click(object sender, EventArgs e)
		{
            //setShiftTimes();
            int areaID = beepBoop.getPK("WORKAREAS", "area_id", "area_name", cbAddArea.Text.Trim());
            string staffIDstring = cbName.Text.Split(']')[0];
            staffIDstring = staffIDstring.Split('[')[1];

            int shiftID = beepBoop.getShiftID(tripNum, shiftStart, shiftEnd, areaID);
            staffID = Int16.Parse(staffIDstring);
            string shiftDate = cbDay.Text.Trim();

            Debug.WriteLine(shiftID + " " + staffID + " " + shiftDate);

			try
			{
				command.CommandText = "INSERT INTO STAFF_SHIFT(shift_id, staff_id, shift_date) VALUES('" + shiftID + "', '" + staffID + "', '" + shiftDate + "')";
				command.Connection = connection;
				MySqlDataReader sRead = command.ExecuteReader();
				sRead.Close();

				string theDay = cbDay.Text.Trim();
				updateDisplay(theDay);

				controlReset();
			}
			catch (MySql.Data.MySqlClient.MySqlException)
			{
				MessageBox.Show("SQL ERROR: Please check that the shift does not already exist.", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}   		
		}

        private void cbAddArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateButton();
        }

        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateButton();
        }

		//METHOD THAT RESETS THE INSERTION CONTROLS AFTER EACH RUN
		private void controlReset()
		{
			cbAddDept.Text = null;
			
			cbAddArea.Items.Clear();
			cbAddArea.Text = null;
			cbAddArea.Enabled = false;

			rbAfternoon.Checked = false;
			rbMorning.Checked = false;
			rbEvening.Checked = false;

			cbName.Items.Clear();
			cbName.Text = null;
			cbName.Enabled = false;

			btnInsert.Enabled = false;
		}

/////// End of insertion prep code ////////////////////////////////////////////////////////////////////

        //Cancel the selected shift from the DGV
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //NOTE: To delete from STAFF_SHIFT, you need the shift_id, staff_id, and the shift_day
            string deleteDay;
            int deleteShift;
            int deleteStaff;

            //GETTING THE SHIFT DATE
            string day = dgvSched.SelectedRows[0].Cells[0].Value.ToString();
            DateTime dateFormat = DateTime.Parse(day);
            deleteDay = dateFormat.ToString("yyyy-MM-dd");
            deleteDay = deleteDay.Substring(0, 10).Trim();

            //GETTING THE SHIFT ID
            string aName = dgvSched.SelectedRows[0].Cells[4].Value.ToString();
            int aID = beepBoop.getPK("WORKAREAS", "area_id", "area_name", aName);
            string shiftTime = dgvSched.SelectedRows[0].Cells[1].Value.ToString();
            deleteShift = beepBoop.getShiftID(tripNum, shiftTime.Split('-')[0].Trim(), shiftTime.Split('-')[1].Trim(), aID);

            //GETTING THE STAFF ID
            string jName = dgvSched.SelectedRows[0].Cells[3].Value.ToString();
            int jobID = beepBoop.getPK("JOBS", "job_id", "job_title", jName);
            string fName = dgvSched.SelectedRows[0].Cells[2].Value.ToString();
            fName = fName.Split(',')[1].Trim();
            string lName = dgvSched.SelectedRows[0].Cells[2].Value.ToString();
            lName = lName.Split(',')[0].Trim();
            int shipID = beepBoop.getPK("TRIP", "ship_id", "ship_id", tripNum.ToString());
            deleteStaff = beepBoop.getStaffID(shipID, fName, lName, jobID);

            //MessageBox.Show(deleteStaff.ToString());
            command.CommandText = "DELETE FROM STAFF_SHIFT WHERE shift_id = '" + deleteShift + "' AND staff_id = '" + deleteStaff + "' AND shift_date = \"" + deleteDay + "\";";
            command.Connection = connection;
            MySqlDataReader sRead = command.ExecuteReader();
            sRead.Close();

            string theDay = cbDay.Text.Trim();
            updateDisplay(theDay);
        }

        private void validateDelete()
        {
            if (dgvSched.SelectedRows != null)
            {
                btnCancel.Enabled = true;
            }
            else
            {
                btnCancel.Enabled = false;
            }
        }

        private void dgvSched_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            validateDelete();
        }
	}
}
