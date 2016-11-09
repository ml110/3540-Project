///////////////////////////////////////////////////////////////////////////////////////////////////
/* CSIS 3540 - CLIENT SERVER SYSTEMS
 * CRUISE LINE PROJECT - SHIPBOARD APPLICATION - SCHEDULE FORM
 * 
 * Manupreet Kaur
 * Pawanpreet Kaur
 * Matthew Lai
 * Amanda Lee
 * Shaun Lu
 * Manjot Sangha
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
		
		public ScheduleForm(int TN, MySqlConnection con, MySqlCommand cmd)
		{
			InitializeComponent();
			connection = con;
			command = cmd;
			tripNum = TN;
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

		private void ScheduleForm_Load(object sender, EventArgs e)
		{
			string dateQuery = "SELECT trip_date FROM TRIP_ITINERARY WHERE trip_id = '" + tripNum + "';";
			setupComboBox(cbDay, dateQuery);
			
			//need to cut the times from the date options in the CB
			for (int i = 0; i < cbDay.Items.Count; i++)
			{
				string day = cbDay.Items[i].ToString();
				//Debug.WriteLine(day);
				DateTime dateFormat = DateTime.Parse(day);
				//Debug.WriteLine(dateFormat);
				string d = dateFormat.ToString("yyyy-MM-dd");
				//Debug.WriteLine(d);
				cbDay.Items[i] = d.Trim();
			}
			cbDay.Text = cbDay.Items[0].ToString();
			string theDay = cbDay.Text.Trim();
			updateDisplay(theDay);
		}


		private void cbDay_SelectedIndexChanged(object sender, EventArgs e)
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
			query += " ORDER BY SS.shift_date, SH.shift_start, D.dept_id";

			MDA = new MySqlDataAdapter(query, connection);
			MDA.Fill(ds, "SCHED");

			dgvSched.DataSource = ds.Tables["SCHED"];
		}


	}
}
