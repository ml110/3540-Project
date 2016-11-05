using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/////////////////////////////////
using MySql.Data.MySqlClient;
using System.IO;
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
        
        public Main_Form()
        {
            InitializeComponent();
        }

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
            }
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            DBConnect();
        }

        private void setTripNum(int a)
        {
            tripNum = a;
        }

        private int getTripNum()
        {
            return tripNum;
        }

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

        private void btnSetTripNum_Click(object sender, EventArgs e)
        {
            string tNumber = cbTripSelect.Text;
            setTripNum(Int16.Parse(tNumber));
            lblCurrentTrip.Text = tNumber;
            lblCurrentTrip.ForeColor = System.Drawing.Color.Green;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestForm test = new TestForm(getTripNum());
            test.Visible = true;
        }
    }
}
