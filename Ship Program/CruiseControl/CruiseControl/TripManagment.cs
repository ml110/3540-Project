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
    public partial class TripManagment : Form
    {
        private MySqlConnection connection;
        MySqlCommand cmd;
        private string selected;

        public TripManagment(int TN)
        {
            InitializeComponent();
            selected = TN.ToString();
            cmd = new MySqlCommand();
        }

        private void connect()
        {
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
            if (connection != null)
                connection.Close();
        }

        private void setupSqlCommand(String query)
        {
            cmd.Connection = connection;
            cmd.CommandText = query;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            showDays();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connect();
            showDays();
            close();
        }

        private void showDays()
        {
            //shows all days in the trip
            string query = "SELECT * FROM TRIP_ITINERARY where trip_id =\"" + selected + "\" order by day_id";
            DataSet ds = new DataSet();
            MySqlDataAdapter mcmd = new MySqlDataAdapter(query, connection);
            mcmd.Fill(ds, "days");
            dgv1.DataSource = ds.Tables["days"];
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //opens add form
            Add newForm = new Add("1");
            newForm.Visible = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //checks if there is a selected cell in the datagridview, and opens the Edit form if there is
            int rowindex = dgv1.CurrentCell.RowIndex;
            Int32 selectedCellCount =
            dgv1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                //trip_id, day_id, trip_date, status_id, isReroute, isCancelled, itin_id

                string tripId = dgv1.Rows[rowindex].Cells[0].Value.ToString();
                string day = dgv1.Rows[rowindex].Cells[1].Value.ToString();
                string tripDate = dgv1.Rows[rowindex].Cells[2].Value.ToString();
                string statusId = dgv1.Rows[rowindex].Cells[3].Value.ToString();
                string isReroute = dgv1.Rows[rowindex].Cells[4].Value.ToString();
                string isCancelled = dgv1.Rows[rowindex].Cells[5].Value.ToString();
                string itin_id = dgv1.Rows[rowindex].Cells[6].Value.ToString();


                Edit newForm = new Edit(tripId, day, tripDate, statusId, isReroute, isCancelled, itin_id);
                newForm.Visible = true;
            }
            else
            {
                MessageBox.Show("Select a Day");
            }
        }

        private void btnAddBelow_Click(object sender, EventArgs e)
        {
            //if a datagridview cell is selected then open the AddBelow form
            int rowindex = dgv1.CurrentCell.RowIndex;
            Int32 selectedCellCount = dgv1.GetCellCount(DataGridViewElementStates.Selected);
            if (selectedCellCount > 0)
            {
                string tripId = dgv1.Rows[rowindex].Cells[0].Value.ToString();
                string day = dgv1.Rows[rowindex].Cells[1].Value.ToString();



                AddBelow newForm = new AddBelow(tripId, day);
                newForm.Visible = true;
            }
            else
            {
                MessageBox.Show("Make a Selection");
            }
        }
    }
}
