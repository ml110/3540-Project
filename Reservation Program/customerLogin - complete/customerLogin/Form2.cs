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

//http://ec2-54-226-9-216.compute-1.amazonaws.com/phpmyadmin/
//f2016_s1_user18

//https://www.youtube.com/watch?v=NX8-LhgFnUU
//https://msdn.microsoft.com/en-us/library/system.windows.forms.textbox.passwordchar(v=vs.110).aspx


namespace customerLogin
{
    public partial class Form2 : Form
    {
        DBConnect db;
        MySqlConnection con;
        MySqlCommand cmd;
        MySqlDataReader sqlReader;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            db = new DBConnect();
            con = new MySqlConnection(db.getConnection());
            con.Open();//to open sql Connection
            MessageBox.Show("Database Connected");

            ///////////////////////load data into COMBOBOX///////////////////////////////////////
            //to load COMBO BOX https://www.youtube.com/watch?v=GkfwRTXbKtA
            cmd = new MySqlCommand();
          //  cmd.CommandText = "select p.port_name from TRIP as t inner join PORTS as p on t.departure_port = p.port_id inner join t.destination_port = p.port_id  ";
            cmd.CommandText = "SELECT T.trip_id, T.ship_id,  T.departure_port, T.destination_port, P.port_name FROM TRIP AS T INNER JOIN PORTS AS P ON T.departure_port = P.port_id INNER JOIN PORTS AS Po ON T.destination_port = Po.port_id";
            cmd.Connection = con; // using the query and connect to mysql
            sqlReader = cmd.ExecuteReader();//activate SQLReader to read DEPARTMENT TABLE from MySQL

            while (sqlReader.Read()) // while READING
            {
                comboBox1.Items.Add("PASSAGE FROM " + sqlReader["port_name"] + " TO " + sqlReader["port_name"]);//read what? assigned to read DepartmentName column from DEPARTMENT Table
            }
            sqlReader.Close();//always close after open SQL method.
        }

        
    }
}
