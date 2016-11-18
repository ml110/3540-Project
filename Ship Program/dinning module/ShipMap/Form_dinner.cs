using MySql.Data.MySqlClient;
using ShipMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShipMap
{
    public partial class Form_dinner : Form
    {
        /// Whomever linking this forum to parent needs to make changes to pass the int 'tripID'
        /// tripID (initialized @ line 26, 35 and 40) is currently hardcoded to =1 for testing purposes
        /// the rest of the code should work without changes
        private MySqlConnection connection;
        MySqlCommand cmd;

        private List<DINNER> dinnerList;
        private List<TABLE> tableList;
        private List<ROOM> roomList;
        private List<ROOM_PASSENGER> rmpassList;
        private List<TRIP> tripList;
        private List<Button> buttonList;
        private List<PASSENGER> passList;
        private int tripID; //////
        public Form_dinner()
        {
            InitializeComponent();
            dinnerList = new List<DINNER>();
            tableList = new List<TABLE>();
            roomList = new List<ROOM>();
            rmpassList = new List<ROOM_PASSENGER>();
            tripList = new List<TRIP>();
            buttonList = new List<Button>();
            passList = new List<PASSENGER>();
            cmd = new MySqlCommand();
            tripID = new int(); /////////////
        }

         private void Form1_Load(object sender, EventArgs e)
        {
            tripID = 1; //////////// link trip to parent forum

            this.AutoSize = true;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
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
            // populate from DB

            string Qpop = "SELECT * FROM ROOM";
            ROOM rm;

            if (connection != null)
            {
                cmd.Connection = connection;
                cmd.CommandText = Qpop;
            }

            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                rm = new ROOM();
                rm.room_id = int.Parse(dataReader["room_id"].ToString());
                rm.room_number = int.Parse(dataReader["room_number"].ToString());
                rm.roomCat_id = int.Parse(dataReader["roomCat_id"].ToString());
                rm.ship_id = int.Parse(dataReader["ship_id"].ToString());

                roomList.Add(rm);
            }
            dataReader.Close();

            string Qpoppass = "SELECT * FROM ROOM_PASSENGER";
            ROOM_PASSENGER rp;

            if (connection != null)
            {
                cmd.Connection = connection;
                cmd.CommandText = Qpoppass;
            }

            MySqlDataReader dataReader1 = cmd.ExecuteReader();

            while (dataReader1.Read())
            {
                rp = new ROOM_PASSENGER();
                rp.room_id = int.Parse(dataReader1["room_id"].ToString());
                rp.pass_id = int.Parse(dataReader1["pass_id"].ToString());
                rp.trip_id = int.Parse(dataReader1["trip_id"].ToString());
                rp.isBillHolder = bool.Parse(dataReader1["isBillHolder"].ToString());
                rp.roomPass_id = int.Parse(dataReader1["roomPass_id"].ToString());

                rmpassList.Add(rp);
            }
            dataReader1.Close();

            string Qtrip = "SELECT * FROM TRIP";
            TRIP t;

            if (connection != null)
            {
                cmd.Connection = connection;
                cmd.CommandText = Qtrip;
            }

            MySqlDataReader dataReader2 = cmd.ExecuteReader();

            while (dataReader2.Read())
            {
                t = new TRIP();
                t.trip_id = int.Parse(dataReader2["trip_id"].ToString());
                t.ship_id = int.Parse(dataReader2["ship_id"].ToString());

                tripList.Add(t);
            }
            dataReader2.Close();

            string Qp = "SELECT * FROM PASSENGER";
            PASSENGER p;

            if (connection != null)
            {
                cmd.Connection = connection;
                cmd.CommandText = Qp;
            }

            MySqlDataReader dataReader3 = cmd.ExecuteReader();

            while (dataReader3.Read())
            {
                p = new PASSENGER();
                p.pass_id = int.Parse(dataReader3["pass_id"].ToString());
                p.name = dataReader3["pass_firstname"].ToString() + " " + dataReader3["pass_lastname"].ToString();

                passList.Add(p);
            }
            dataReader3.Close();

            string Qd = "SELECT * FROM DINNER";
            DINNER din;

            if (connection != null)
            {
                cmd.Connection = connection;
                cmd.CommandText = Qd;
            }

            MySqlDataReader dataReader4 = cmd.ExecuteReader();

            while (dataReader4.Read())
            {
                din = new DINNER();
                din.dinner_id = int.Parse(dataReader4["dinner_id"].ToString());
                din.table_id = int.Parse(dataReader4["table_id"].ToString());
                din.group_amount = int.Parse(dataReader4["group_amount"].ToString());
                din.dinner_date = Convert.ToDateTime(dataReader4["dinner_date"].ToString()).ToString("MMM dd, yyyy");
                din.dinner_sitting = int.Parse(dataReader4["dinner_sitting"].ToString());
                din.room_id = int.Parse(dataReader4["room_id"].ToString());
                din.waiter_id = int.Parse(dataReader4["waiter_id"].ToString());
                din.trip_id = int.Parse(dataReader4["trip_id"].ToString());
                din.hasFee = bool.Parse(dataReader4["hasFee"].ToString());

                dinnerList.Add(din);
            }
            dataReader4.Close();

            string Qt = "SELECT * FROM TABLE0";
            TABLE tb;

            if (connection != null)
            {
                cmd.Connection = connection;
                cmd.CommandText = Qt;
            }

            MySqlDataReader dataReader5 = cmd.ExecuteReader();

            while (dataReader5.Read())
            {
                tb = new TABLE();
                tb.table_id = int.Parse(dataReader5["table_id"].ToString());
                tb.max_capacity = int.Parse(dataReader5["max_capacity"].ToString());
                tb.ship_id = int.Parse(dataReader5["ship_id"].ToString());
                tb.area_id = int.Parse(dataReader5["area_id"].ToString());

                tableList.Add(tb);
            }
            dataReader5.Close();

            // fill cbDeck (date of dinner; ignore misleading var names code was copied from elsewhere)

            int shipID = 0;
            for (int i = 0; i < tripList.Count; i++)
                if (tripList[i].trip_id == tripID)
                    shipID = tripList[i].ship_id;

            foreach (DINNER r in dinnerList)
            {
                if (r.trip_id == tripID)
                {
                    string deckNum = r.dinner_date;

                    bool newDeck = true;
                    for (int i = 0; i < cbDeck.Items.Count; i++)
                        if (cbDeck.GetItemText(cbDeck.Items[i]) == deckNum)
                            newDeck = false;

                    if (newDeck)
                        cbDeck.Items.Add(deckNum);
                }
            }
        }

        private void cbDeck_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbSitting.SelectedIndex != -1)
                drawMap();
        }

        private void newPassForum(object sender, EventArgs e)
        {
            Form_table newForum = new Form_table();

            int dinner_id = 0;
            for (int i = 0; i < dinnerList.Count; i++)
            {
                if (dinnerList[i].trip_id == tripID &&
                    dinnerList[i].dinner_sitting == int.Parse(cbSitting.SelectedItem.ToString()) &&
                    dinnerList[i].dinner_date == cbDeck.SelectedItem.ToString() &&
                    dinnerList[i].table_id == int.Parse(((Button)sender).Text)) {

                    dinner_id = dinnerList[i].dinner_id;
                    break;
                }         
            }

            newForum.dinner_id = dinner_id;
            newForum.ship_id = tripList[tripID].ship_id;
            newForum.Show();
        }

        private void cbSitting_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDeck.SelectedIndex != -1)
                drawMap();
        }

        private void drawMap()
        {
            int top = 25;
            int left = 170;

            for (int i = 0; i < buttonList.Count; i++)
                this.Controls.Remove(buttonList[i]);

            int shipID = 0;
            for (int i = 0; i < tripList.Count; i++)
                if (tripList[i].trip_id == tripID)
                    shipID = tripList[i].ship_id;
            int row = 0;

            for (int i = 0; i < tableList.Count; i++)
            {
                if (tableList[i].ship_id == shipID)
                {
                    Button newButton = new Button();
                    newButton.Top = top;
                    newButton.Left = left;
                    newButton.Height = 50;
                    newButton.Width = 50;
                    newButton.Text = tableList[i].table_id.ToString();

                    var findEmpty = from rp in dinnerList
                                    where rp.table_id == tableList[i].table_id
                                    where rp.trip_id == tripID
                                    where rp.dinner_sitting == int.Parse(cbSitting.SelectedItem.ToString())
                                    where rp.dinner_date == cbDeck.SelectedItem.ToString()
                                    select rp;

                    if (findEmpty.Count() == 0)
                        newButton.Enabled = false;
                    else
                        newButton.Click += newPassForum;
                    
                    buttonList.Add(newButton);
                    this.Controls.Add(newButton);

                    if (row == 4)
                    {
                        row = 0;
                        top = 25;
                        left += 70;
                    }
                    else
                    {
                        row++;
                        top += newButton.Height + 20;
                    }

                }
            } 
        }
    }
    }

