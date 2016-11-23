using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace bill
{
    public partial class BillingForm : Form
    {
        // Remember: add Reference MySQL.Data
        private MySqlConnection connection;
        MySqlCommand cmd;

        List<TRANSACTION> listTran;

        int tID; //TRIP
        int sID; //SHIP

        public BillingForm() //TEMP CONSTRUCTOR
        {
            InitializeComponent();
            cmd = new MySqlCommand();
        }

        //RELEASE CONSTRUCTOR
        public BillingForm(MySqlConnection CONN, MySqlCommand CMD, int TN)
        {
            InitializeComponent();
            connection = CONN;
            cmd = CMD;
            tID = TN;
        }

        private void BillingForm_Load(object sender, EventArgs e)
        {
            DBConnect(); //TEMP THING
        }

        //TEMP CONNECTION METHOD
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
        }

		//this will give the bill holder's name for the reciept given the roomnumber
		private string getBHname(int RN)
		{
			string name = "";
			string QUERY = "SELECT R.room_number, concat(P.pass_firstname, \" \", P.pass_lastname) AS billHolder FROM ROOM_PASSENGER AS RP";
			QUERY += " INNER JOIN PASSENGER AS P ON RP.pass_id = P.pass_id";
			QUERY += " INNER JOIN ROOM AS R ON RP.room_id = R.room_id";
			QUERY += " WHERE RP.trip_id = 1 AND RP.isBillHolder = 1 AND R.room_number = '" + RN + "';";

			cmd.Connection = connection;
			cmd.CommandText = QUERY;
			MySqlDataReader MDR = cmd.ExecuteReader();

			while (MDR.Read())
			{
				name = MDR["billHolder"].ToString();
			}
			MDR.Close();

			if (name == null || name == "")
			{
				throw new ArgumentException("No passengers in the selected room!");
			}
			else
			{
				return name;
			}
		}

        //this method will generate the list of transactions associated with the RN
        private void generateTrans(int RN)
        {
            //run two queries, one for drinks the other for gifts
        }

		//This should calculate all the expenses
		private void btnCalc_Click(object sender, EventArgs e)
		{
			string billName = "";

			try
			{
				billName = getBHname(Int32.Parse(rumID.Text.Trim()));
				MessageBox.Show(billName);
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message, "OOPS", MessageBoxButtons.OK);
			}
		}

        //This needs to generate the Bill
        private void printBill_Click(object sender, EventArgs e)
        {
                
        }

		
    }
}