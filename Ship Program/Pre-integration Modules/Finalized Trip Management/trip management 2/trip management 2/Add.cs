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

namespace trip_management_2
{
    public partial class Add : Form
    {
        private MySqlConnection connection;
        MySqlCommand cmd;
        string trip;
        public Add(string tr)
        {
            InitializeComponent();
            cmd = new MySqlCommand();
            trip = tr;
            connect();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Add_Load(object sender, EventArgs e)
        {
            datePickerFormat();
            fillCmb();
        }

        private void datePickerFormat()
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "H:mm:ss";
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "H:mm:ss";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //inserts new data into the database
            string day = txtDay.Text;
            string date = dateTimePicker1.Text;
            string port = cmbPort.Text;
            string status = cmbStatus.Text;
            string statusId = getStatusId(status);
            string reroute = "";
            string arrival;
            string depart;
            string instruction = "";
            string portId = getPortId(port);
            int itinId = getLastItinId();
            itinId++;
            int DayTxt = 0;// Convert.ToInt32(txtDay.Text);

            if (rbrTrue.Checked == true)
            {
                reroute = "1";
            }
            else
            {
                reroute = "0";
            }


            if (status == "Cruising")
            {
                arrival = null;
                depart = null;
            }
            else if (status == "Embark")
            {
                arrival = null;
                depart = dateTimePicker3.Text;
            }
            else if (status == "Debark")
            {
                arrival = dateTimePicker2.Text;
                depart = null;
            }
            else
            {
                arrival = dateTimePicker2.Text;
                depart = dateTimePicker3.Text;
            }


            if (!Int32.TryParse(txtDay.Text, out DayTxt))
            {
                MessageBox.Show("Invalid Day");
            }
            else if(portId == "error")
            {
                MessageBox.Show("Invalid Port");
            }
            else if(statusId == "error")
            {
                MessageBox.Show("Invalid Status");
            }
            else
            {
                instruction = "INSERT INTO TRIP_ITINERARY(trip_id, day_id, trip_date, status_id, isReroute, isCancelled,itin_id) ";
                instruction += "values ('" + trip + "','" + day + "','" + date + "','" + statusId + "','" + reroute + "','0','" + itinId + "')";
                cmd.CommandText = instruction;

                cmd.ExecuteNonQuery();

                if(status != "Cruising")
                {
                    instruction = "INSERT INTO TRIP_PORTS (itin_id, port_id, arrival_time, depart_time) ";
                    instruction += "values ('" + itinId + "','" + portId + "','" + arrival + "','" + depart + "')";
                    cmd.CommandText = instruction;

                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Day Added");
                
            }


        }

        private string getStatusId(string status)
        {
            //gets the status id from the status_name
            string query = "SELECT status_id FROM STATUS where status_name = '" + status + "'";
            string statusId = "";
            setupSqlCommand(query);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if(dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    statusId = dataReader["status_id"].ToString();
                }
            }else
            {
                statusId = "error";
            }
            dataReader.Close();
            return statusId;
        }

        private int getLastItinId()
        {
            //gets the last itin_id in trip_itinerary
            string query = "SELECT itin_id FROM TRIP_ITINERARY ORDER BY itin_id DESC LIMIT 1";
            int itinId = 0;
            setupSqlCommand(query);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                itinId = Convert.ToInt32(dataReader["itin_id"]);
            }
            dataReader.Close();
            return itinId;
        }

        private string getPortId(string name)
        {
            //gets port id from port name
            string query = "SELECT port_id FROM PORTS where port_name = '" + name + "'";
            string portId = "";
            setupSqlCommand(query);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if(dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    portId = dataReader["port_id"].ToString();
                }
            }else
            {
                portId = "error";
            }
            dataReader.Close();
            return portId;
        }

        private void connect()
        {
            //connects to the database
            String database = "f2016_s1_user16";
            String server = "ec2-54-226-9-216.compute-1.amazonaws.com";
            String user = "f2016_s1_user16";
            String pass = "f2016_s1_user16";

            string connectionString;

            connectionString = "SERVER=" + server + ";DATABASE=" +
            database + ";" + "UID=" + user + ";" + "PASSWORD=" + pass + ";";
            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (MySqlException ex)
            {
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
            }
        }

        private void close()
        {
            //closes the database connection
            if (connection != null)
                connection.Close();
        }

        private void setupSqlCommand(String query)
        {
            cmd.Connection = connection;
            cmd.CommandText = query;
        }

        private void fillCmb()
        {
            //fills the status and port comboboxes with data
            string query1 = "Select status_name from STATUS";
            string query2 = "Select port_name from PORTS";
            DataSet status = new DataSet();
            DataSet port = new DataSet();
            MySqlDataAdapter cmb1 = new MySqlDataAdapter(query1, connection);
            MySqlDataAdapter cmb2 = new MySqlDataAdapter(query2, connection);
            cmb1.Fill(status, "status_name");
            cmb2.Fill(port, "port_name");
            cmbStatus.DataSource = status.Tables["status_name"];
            cmbStatus.DisplayMember = "status_name";
            cmbPort.DataSource = port.Tables["port_name"];
            cmbPort.DisplayMember = "port_name";


        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //disallow certain input depending on status
            string selected = cmbStatus.Text;
            if (selected == "Cruising")
            {
                dateTimePicker2.Enabled = false;
                dateTimePicker3.Enabled = false;
                cmbPort.Enabled = false;
            }
            else if (selected == "Embark")
            {
                dateTimePicker2.Enabled = false;
                dateTimePicker3.Enabled = true;
                cmbPort.Enabled = true;
            }
            else if (selected == "Debark")
            {
                dateTimePicker2.Enabled = true;
                dateTimePicker3.Enabled = false;
                cmbPort.Enabled = true;
            }
            else
            {
                dateTimePicker2.Enabled = true;
                dateTimePicker3.Enabled = true;
                cmbPort.Enabled = true;
            }
        }
    }
}
