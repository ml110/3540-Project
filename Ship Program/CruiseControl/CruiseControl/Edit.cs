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

namespace CruiseControl
{
    public partial class Edit : Form
    {
        private MySqlConnection connection;
        MySqlCommand cmd;
        private String tripId, day, tripDate, statusId, isReroute, isCancelled, itin_id;

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //disallow input for certain statuses
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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //updates row in database
            int DayTxt;
            string statusName = cmbStatus.Text;
            string status = getStatusId(cmbStatus.Text);
            string port = getPortId(cmbPort.Text);
            string arrival = null;
            string date = dateTimePicker1.Text;
            string depart = null;
            string reroute = "";
            string cancel = "";
            if(rbrFalse.Checked == true)
            {
                reroute = "0";
            }else
            {
                reroute = "1";
            }

            if(rbcFalse.Checked == true)
            {
                cancel = "0";
            }else
            {
                cancel = "1";
            }
            bool checkDay = checkForDay();

            //input validation
            if (!Int32.TryParse(txtDay.Text, out DayTxt) && checkDay == false)
            {
                MessageBox.Show("Invalid Day");
            }
            else if(status == "error")
            {
                MessageBox.Show("Invalid Status");
            }
            else if(port == "error")
            {
                MessageBox.Show("Invalid Port");
            }else
            {
                string instruction = "";
                string checkItin = checkItinId(itin_id);

                if (statusName == "Cruising")
                {
                    arrival = null;
                    depart = null;
                }
                else if (statusName == "Embark")
                {
                    arrival = null;
                    depart = dateTimePicker3.Text;
                }
                else if (statusName == "Debark")
                {
                    arrival = dateTimePicker2.Text;
                    depart = null;
                }
                else
                {
                    arrival = dateTimePicker2.Text;
                    depart = dateTimePicker3.Text;
                }

                //updates the row in trip_itinerary
                instruction = "UPDATE TRIP_ITINERARY ";
                instruction += "SET trip_id = '"+tripId+"', trip_date = '"+date+"', status_id = '"+statusId+"', isReroute = '"+reroute+"', isCancelled = '"+cancel+"', itin_id = '"+itin_id+"' ";
                instruction += "WHERE trip_id ='"+tripId+"' and day_id = '"+day+"'";

                cmd.CommandText = instruction;

                cmd.ExecuteNonQuery();

                if (status != "1")
                {

                    if (checkItin != "error")
                    {
                        //edit row in itin ports
                        instruction = "UPDATE TRIP_PORTS ";


                        if(status == "2")
                        {
                            instruction += "set itin_id = '" + itin_id + "', port_id = '" + port + "', arrival_time = '" + arrival + "', depart_time = '" + depart + "' ";
                        }
                        else if(status == "3")
                        {
                            instruction += "set itin_id = '" + itin_id + "', port_id = '" + port + "',depart_time = '" + depart + "' ";
                        }
                        else if(status == "4")
                        {
                            instruction += "set itin_id = '" + itin_id + "', port_id = '" + port + "', arrival_time = '" + arrival + "' ";
                        }

                        instruction += "WHERE itin_id ='" + itin_id + "'";
                        cmd.CommandText = instruction;

                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        //add new row to itin_ports
                        if (status == "2")
                        {
                            instruction = "INSERT INTO TRIP_PORTS (itin_id, port_id, arrival_time, depart_time) ";
                            instruction += "values ('" + itin_id + "','" + port + "','" + arrival + "','" + depart + "')";
                        }
                        else if (status == "3")
                        {
                            instruction = "INSERT INTO TRIP_PORTS (itin_id, port_id, depart_time) ";
                            instruction += "values ('" + itin_id + "','" + port + "','" + depart + "')";
                        }
                        else if (status == "4")
                        {
                            instruction = "INSERT INTO TRIP_PORTS (itin_id, port_id, arrival_time) ";
                            instruction += "values ('" + itin_id + "','" + port + "','" + arrival + "')";
                        }
                        
                        cmd.CommandText = instruction;

                        cmd.ExecuteNonQuery();


                    }
                }

                MessageBox.Show("Day Edited");
            }
        }

        private bool checkForDay()
        {
            //checks if a day exists in the trip
            string query = "SELECT * from TRIP_ITINERARY where day_id = '" + day + "' And trip_id = '" + tripId + "'";
            bool output = false;
            setupSqlCommand(query);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if(dataReader.HasRows)
            {
                output = true;
            }
            dataReader.Close();
            return output;
        }

        private string checkItinId(string itin)
        {
            //checks if a itin_id exists in trip_ports
            string query = "SELECT * FROM TRIP_PORTS where itin_id = '" + itin + "'";
            string itinId = "";
            setupSqlCommand(query);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    itinId = dataReader["itin_id"].ToString();
                }
            }
            else
            {
                itinId = "error";
            }
            dataReader.Close();
            return itinId;
        }

        private void datePickerFormat()
        {
            //changes the format for datatimepickers
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "H:mm:ss";
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "H:mm:ss";
        }

        public Edit(string one, string two, string three, string four, string five, string six, string seven)
        {
            InitializeComponent();
            cmd = new MySqlCommand();
            connect();
            fillCmb();
            tripId = one;
            day = two;
            tripDate = three;
            statusId = four;
            isReroute = five;
            isCancelled = six;
            itin_id = seven;

            dateTimePicker1.Text = tripDate;
            txtDay.Text = day;

            setRadioButtons();
            getStatus();
            getPortsInfo();

            datePickerFormat();

        }

        private string getStatusId(string status)
        {
            //gets status_id from status_name
            string query = "SELECT status_id FROM STATUS where status_name = '" + status + "'";
            string statusId = "";
            setupSqlCommand(query);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    statusId = dataReader["status_id"].ToString();
                }
            }
            else
            {
                statusId = "error";
            }
            dataReader.Close();
            return statusId;
        }

        private string getPortId(string name)
        {
            //gets port_id from port_name
            string query = "SELECT port_id FROM PORTS where port_name = '" + name + "'";
            string portId = "";
            setupSqlCommand(query);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    portId = dataReader["port_id"].ToString();
                }
            }
            else
            {
                portId = "error";
            }
            dataReader.Close();
            return portId;
        }

        private void setRadioButtons()
        {
            //sets radiobuttons to false/true depending on info in database
            if (isReroute == "False")
            {
                rbrFalse.Checked = true;
            }
            else
            {
                rbrTrue.Checked = true;
            }
            if (isCancelled == "False")
            {
                rbcFalse.Checked = true;
            }
            else
            {
                rbcTrue.Checked = true;
            }
        }

        private void getStatus()
        {
            //gets the status_name from status_id
            //changes the cmb text to the status name
            string query = "SELECT status_name FROM STATUS where status_id = \"" + statusId + "\"";
            setupSqlCommand(query);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            string statusName = "";
            while (dataReader.Read())
            {
                statusName = dataReader["status_name"].ToString();
            }
            dataReader.Close();
            cmbStatus.Text = statusName;
        }

        private void connect()
        {
            String database = "f2016_s1_user16";
            String server = "ec2-54-226-9-216.compute-1.amazonaws.com";
            String user = "f2016_s1_user16";
            String pass = "f2016_s1_user16";

            string connectionString;

            //connectionString = "SERVER=ec2-52-20-54-9.compute-1.amazonaws.com;DATABASE=sampdb;UID=f2016_s1_user24;PASSWORD=f2016_s1_user24;";
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
            //fills the port and status comboboxes with their data
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

        private void getPortsInfo()
        {
            //gets the port information from trip_ports
            //puts data into the inputs in gui
            string query = "SELECT * from TRIP_PORTS where itin_id = \"" + itin_id + "\"";
            setupSqlCommand(query);
            MySqlDataReader test = cmd.ExecuteReader();
            string port = "";
            while (test.Read())
            {
                string arrival = test["arrival_time"].ToString();
                string depart = test["depart_time"].ToString();
                if (arrival == null)
                {
                    dateTimePicker2.Text = null;
                }
                else
                {
                    dateTimePicker2.Text = test["arrival_time"].ToString();
                }

                if(depart == null)
                {
                    dateTimePicker3.Text = null;
                }
                else
                {
                    dateTimePicker3.Text = test["depart_time"].ToString();
                }
                port = test["port_id"].ToString();
            }
            test.Close();

            //gets port_name from port_id
            query = "SELECT port_name FROM PORTS where port_id = \"" + port + "\"";
            setupSqlCommand(query);
            MySqlDataReader test2 = cmd.ExecuteReader();
            while (test2.Read())
            {
                cmbPort.Text = test2["port_name"].ToString();
            }
            test2.Close();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            
        }

        private void Edit_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
