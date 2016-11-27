using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace customerLogin
{
    public partial class FormTesting : Form
    {
        DBConnect db;
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader sqlReader;

        public FormTesting()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            db = new DBConnect();
            con = new MySqlConnection(db.getConnection());
            con.Open();//to open sql Connection
          //  MessageBox.Show("Connected");

            ///////////////////////load data into COMBOBOX///////////////////////////////////////
            //to load COMBO BOX https://www.youtube.com/watch?v=GkfwRTXbKtA
            cmd = new MySqlCommand();
            cmd.CommandText = "select * from TRIP";
            cmd.Connection = con; // using the query and connect to mysql
            sqlReader = cmd.ExecuteReader();//activate SQLReader to read DEPARTMENT TABLE from MySQL

            while (sqlReader.Read()) // while READING
            {
                comboBox1.Items.Add(sqlReader["departure_date"]);//read what? assigned to read DepartmentName column from DEPARTMENT Table
            }
            sqlReader.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            db = new DBConnect();
           // con = new MySqlConnection(db.getConnection());
            cmd = new MySqlCommand();
            //cmd.CommandText = "select EmployeeNumber, concat(E.FirstNAme,' ',E.LastNAme) as FullName, Email, Department from EMPLOYEE as E where Department ='" + comboDepartment.SelectedItem + "'";
            //cmd.CommandText = "select * from TRIP where trip_id ='" + comboBox1.SelectedIndex + "'";
            //cmd.Connection = con;// using the query and connect to mysql
            //sqlReader = cmd.ExecuteReader();//activate SQLReader to read DEPARTMENT TABLE from MySQL
            int selectedIndex = comboBox1.SelectedIndex + 1;
            string query = "select * from TRIP where trip_id =" + selectedIndex + ";";
            MySqlConnection conDataBase = new MySqlConnection(db.getConnection());
            MySqlCommand cmdDataBase = new MySqlCommand(query,conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read()) // while READING
                {
                    DateTime departureD = (DateTime)myReader["departure_date"];
                    textBox1.Text = departureD.ToString("MMMM dd, yyyy");
                }
                sqlReader.Close();

            }
            catch (Exception ex)
            {

            }

            

        }
    }
}
