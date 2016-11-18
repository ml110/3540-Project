using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipMap
{
    public partial class Form_table : Form
    {
        private MySqlConnection connection;
        MySqlCommand cmd;
        public int dinner_id;
        public int ship_id;
        private List<STAFF> empList;
        private int current_staff;

        public Form_table()
        {
            InitializeComponent();
            dinner_id = new int();
            ship_id = new int();
            cmd = new MySqlCommand();
            empList = new List<STAFF>();
            current_staff = new int();
        }

        private void FormPassenger_Load(object sender, EventArgs e)
        {
            String connectionString = "SERVER=" + "ec2-54-226-9-216.compute-1.amazonaws.com" + "; DATABASE=" +
            "f2016_s1_user16" + ";" + "UID=" + "f2016_s1_user16" + "; " + "PASSWORD=" + "f2016_s1_user16" + "; ";

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
            if (connection != null)
            {
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM STAFF WHERE ship_id ="
                                  + ship_id
                                  + " AND job_id = 10";
            }
            STAFF s;

            MySqlDataReader dataReader1 = cmd.ExecuteReader();

            while (dataReader1.Read())
            {
                s = new STAFF();
                s.name = dataReader1["staff_firstname"].ToString() + " " + dataReader1["staff_lastname"].ToString();
                s.staff_id = int.Parse(dataReader1["staff_id"].ToString());

                empList.Add(s);
            }
            dataReader1.Close();

            foreach (STAFF w in empList)
                cbWaiter.Items.Add(w.name + " " + w.staff_id.ToString());

            if (connection != null)
            {
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM DINNER WHERE dinner_id=" + dinner_id;
            }
            int staff_id = 0;
            MySqlDataReader dataReader4 = cmd.ExecuteReader();
            while (dataReader4.Read())
            {
                txtDate.Text = Convert.ToDateTime(dataReader4["dinner_date"].ToString()).ToString("MMM dd, yyyy");
                txtSitting.Text = dataReader4["dinner_sitting"].ToString();
                txtRoom.Text = dataReader4["room_id"].ToString();
                current_staff = int.Parse(dataReader4["waiter_id"].ToString());
                txtFee.Text = dataReader4["hasFee"].ToString();
            }
            dataReader4.Close();

            for (int i = 0; i < empList.Count; i++)
                if (current_staff == empList[i].staff_id)
                    cbWaiter.SelectedIndex = i;
        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            int new_staff = empList[cbWaiter.SelectedIndex].staff_id;

            try {
                cmd.CommandText = "UPDATE DINNER SET waiter_id=" +
                                  new_staff +
                                  " WHERE dinner_id=" +
                                  dinner_id + ";";
                cmd.Connection = connection;
                MySqlDataReader sRead = cmd.ExecuteReader();
                sRead.Close();
            }
            catch { }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbWaiter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;

            for (int i = 0; i < empList.Count; i++)
                if (current_staff == empList[i].staff_id)
                    index = i;

            if (cbWaiter.SelectedIndex == index)
                btnSave.Enabled = false;
            else
                btnSave.Enabled = true;
        }
    }
}
