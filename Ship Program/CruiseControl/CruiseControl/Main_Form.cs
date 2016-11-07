///////////////////////////////////////////////////////////////////////////////////////////////////
/* CSIS 3540 - CLIENT SERVER SYSTEMS
 * CRUISE LINE PROJECT - SHIPBOARD APPLICATION
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
    public partial class Main_Form : Form
    {
        //SQL Connection
        private MySqlConnection connection;
        MySqlCommand command = new MySqlCommand();

        //Selected Trip
        private static int tripNum;
		int shipNum;
        
        public Main_Form()
        {
            InitializeComponent();
        }

		//METHOD TO CONNECT TO THE DB; RUN ON PROGRAM START
        private void DBConnect()
        {
            string server = "ec2-54-226-9-216.compute-1.amazonaws.com";
            string db = "f2016_s1_user16";
            string id = "f2016_s1_user16";
            string pass = "f2016_s1_user16";
            string port = "3306";

            string connectionString = "SERVER=" + server + ";PORT=" + port + ";DATABASE=" + db + ";UID=" + id + ";PASSWORD=" + pass + ";";
            connection = new MySqlConnection(connectionString);

            connection.Open();

            if (connection != null)
            {
                lblDBStatus.Text = "CONNECTED";
                lblDBStatus.ForeColor = System.Drawing.Color.Green;

                string query = "SELECT trip_id FROM TRIP;";
                setupComboBox(cbTripSelect, query);

				lblCurrentDate.Text = "Connected at " + System.DateTime.Now.ToString();
            }
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            DBConnect();
        }

		//tripNum Mutator
        private void setTripNum(int a)
        {
            tripNum = a;
        }

		//tripNum Accessor
        private int getTripNum()
        {
            return tripNum;
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

		//METHOD SELECTING THE TRIP NUMBER
        private void btnSetTripNum_Click(object sender, EventArgs e)
        {
            string tNumber = cbTripSelect.Text;
            setTripNum(Int16.Parse(tNumber)); //set tripNum
            lblCurrentTrip.Text = tNumber;
            lblCurrentTrip.ForeColor = System.Drawing.Color.Green;

			//triggers update on the right-side information
			updateTripString();
			updateVessel();
			updatePassengers();
			updateCrew();
        }

/////// Next several methods are for updating the trip information on the right ///////////////////

		//METHOD FOR UPDATING THE TRIP TITLE
		private void updateTripString()
		{
			command.CommandText = "SELECT T.ship_id AS SHIPNUM, T.departure_date AS DEPARTDATE, P.port_name AS DEPARTPORT, C.city_name AS DEPARTCITY, P2.port_name AS DESTPORT, C2.city_name AS DESTCITY  FROM TRIP AS T INNER JOIN PORTS AS P ON T.departure_port = P.port_id INNER JOIN CITY AS C ON P.city_id = C.city_id INNER JOIN PORTS AS P2 ON T.destination_port = P2.port_id INNER JOIN CITY AS C2 ON P2.city_id = C2.city_id WHERE T.trip_id = '" + getTripNum() + "';";
			command.Connection = connection;
			MySqlDataReader sRead = command.ExecuteReader();
			string tripString = "";

			while (sRead.Read())
			{
				tripString = sRead["DEPARTPORT"].ToString() + ", " + sRead["DEPARTCITY"].ToString() + " >>> ";
				tripString += sRead["DESTPORT"].ToString() + ", " + sRead["DESTCITY"].ToString() + "\n" + "SAILING ON " + sRead["DEPARTDATE"].ToString().Substring(0, 10);
				shipNum = Int16.Parse(sRead["SHIPNUM"].ToString());
			}

			sRead.Close();

			lblTripString.Text = tripString;
			lblTripString.ForeColor = System.Drawing.Color.Black;
		}

		//METHOD FOR UPDATING VESSEL INFORMATION
		private void updateVessel()
		{
			command.CommandText = "SELECT S.ship_name AS VESSEL, S.ship_callsign AS CALLSIGN, S.ship_IMOnumber AS IMO, concat(P.port_name, \", \", Co.country_name) AS REGPORT, CONCAT(J.job_title, \" \",ST.staff_firstname, \" \", ST.staff_lastname) AS CAPTAIN FROM SHIP AS S INNER JOIN STAFF AS ST ON S.ship_captain = ST.staff_id INNER JOIN JOBS AS J ON ST.job_id = J.job_id INNER JOIN PORTS AS P ON S.ship_portofreg = P.port_id INNER JOIN CITY AS C ON P.city_id = C.city_id INNER JOIN COUNTRY AS Co ON C.country_id = Co.country_id WHERE S.ship_id = '" + shipNum + "';";
			command.Connection = connection;
			MySqlDataReader sRead = command.ExecuteReader();
			string vesselString = "";

			while (sRead.Read())
			{
				vesselString += sRead["VESSEL"] + "\n";
				vesselString += sRead["CALLSIGN"] + "\n";
				vesselString += sRead["IMO"] + "\n";
				vesselString += sRead["REGPORT"] + "\n\n";
				vesselString += sRead["CAPTAIN"];
			}

			sRead.Close();

			lblVessel.Text = vesselString;
		}

		//METHOD FOR UPDATNG PASSENGER COUNT
		private void updatePassengers()
		{
			//first grab the total passenger count
			command.CommandText = "SELECT count(pass_id) AS NUMPASS FROM ROOM_PASSENGER WHERE trip_id = '" + getTripNum() + "';";
			command.Connection = connection;
			MySqlDataReader sRead = command.ExecuteReader();
			string passengerString = "";

			while (sRead.Read())
			{
				passengerString = sRead["NUMPASS"] + "/1428" + "\n";
			}

			sRead.Close();

			//now get the number of rooms occupied
			command.CommandText = "SELECT count(isBillHolder) AS NUMROOMS FROM ROOM_PASSENGER WHERE trip_id = '" + getTripNum() + "' AND isBillHolder = 1;";
			sRead = command.ExecuteReader();

			while (sRead.Read())
			{
				passengerString += sRead["NUMROOMS"] + " rooms occupied";
			}

			sRead.Close();

			lblPass.Text = passengerString;
		}

		//METHOD FOR UPDATING CREW STATUS
		private void updateCrew()
		{
			DataSet ds = new DataSet();
			dgvCrew.DataSource = null;
			MySqlDataAdapter MDA;
			int totalCrew = 0;

			string query = "SELECT D.dept_name AS DEPARTMENT, count(S.staff_id) AS NUMSTAFF FROM STAFF AS S INNER JOIN JOBS AS J ON S.job_id = J.job_id INNER JOIN DEPARTMENT AS D ON J.dept_id = D.dept_id WHERE S.ship_id = '" + shipNum + "' GROUP BY D.dept_id";
			MDA = new MySqlDataAdapter(query, connection);
			MDA.Fill(ds, "DEPT");

			dgvCrew.DataSource = ds.Tables["DEPT"];
		}

///////////////////////////////////////////////////////////////////////////////////////////////////

/////// TEST STUFF, REMOVE FROM FINAL VERSION /////////////////////////////
        private void button1_Click(object sender, EventArgs e)
        {
            TestForm test = new TestForm(getTripNum());
            test.Visible = true;
        }
//////////////////////////////////////////////////////////////////////////
    }
}

