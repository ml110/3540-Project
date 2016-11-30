using MySql.Data.MySqlClient;
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
    public partial class Form1 : Form
    {
        
        private MySqlConnection connection;
        MySqlCommand cmd;

        private List<ROOM> roomList;
        private List<ROOM_PASSENGER> rmpassList;
        private List<TRIP> tripList;
        private List<Button> buttonList;
        public Form1()
        {
            InitializeComponent();
            roomList = new List<ROOM>();
            rmpassList = new List<ROOM_PASSENGER>();
            tripList = new List<TRIP>();
            buttonList = new List<Button>();
            cmd = new MySqlCommand();
        }

         private void Form1_Load(object sender, EventArgs e)
        {
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
            ///////////////// begin populate 

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
                rm.phone_number = dataReader["phone_number"].ToString();
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

            for (int i = 0; i < tripList.Count; i++)
            {
                cbShip.Items.Add(tripList[i].trip_id);
            }
        }
            

        private void pictureBox1_Click(object sender, EventArgs e) {  }

        private void cbShip_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbDeck.Items.Clear();
            for (int i = 0; i < buttonList.Count; i++)
                this.Controls.Remove(buttonList[i]);

            List<int> decks = new List<int>();

            int tripID = int.Parse(cbShip.GetItemText(cbShip.SelectedItem));
            int shipID = 0;
            for (int i = 0; i < tripList.Count; i++)
                if (tripList[i].trip_id == tripID)
                    shipID = tripList[i].ship_id;

            foreach (ROOM r in roomList) {
                if (r.ship_id == shipID)
                {
                    string deckNum = r.room_number.ToString("D5").Substring(0, 1);

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
            int top = 25;
            int left = 170;
            int currentRow = 0;
            int totalHeight = 0;

            for (int i = 0; i < buttonList.Count; i++)
                this.Controls.Remove(buttonList[i]);

            int tripID = int.Parse(cbShip.GetItemText(cbShip.SelectedItem));
            int shipID = 0;
            for (int i = 0; i < tripList.Count; i++)
                if (tripList[i].trip_id == tripID)
                    shipID = tripList[i].ship_id;

            for (int i = 0; i < roomList.Count; i++)
            {
                if (roomList[i].ship_id == shipID
                    && this.cbDeck.GetItemText(cbDeck.SelectedItem) == roomList[i].room_number.ToString("D5").Substring(0, 1))
                {

                    int getRow = int.Parse(roomList[i].room_number.ToString("D5").Substring(1, 2));

                    if (getRow != currentRow)
                    {
                        currentRow = getRow;
                        top = 25;
                        left += 51;

                        // hardcoded hallways to save time
                        if(currentRow == 1 || currentRow == 3 || currentRow == 4 || currentRow == 6)
                            left += 50;
                    }
                    
                    Button newButton = new Button();
                    newButton.Top = top;
                    newButton.Left = left;
                    newButton.Height = 25;
                    newButton.Width = 50;
                    newButton.Text = roomList[i].room_number.ToString();

                    var findEmpty = from rp in rmpassList
                                    where rp.room_id == roomList[i].room_id
                                    where rp.trip_id == tripID
                                    select rp;

                    if (findEmpty.Count() != 0)
                        newButton.Enabled = false;
                    else
                    {
                        if (roomList[i].roomCat_id == 2)
                            newButton.BackColor = Color.SkyBlue;
                        else if (roomList[i].roomCat_id == 3)
                            newButton.BackColor = Color.YellowGreen;
                        else
                            newButton.BackColor = Color.Tan;
                    }

                    buttonList.Add(newButton);
                    this.Controls.Add(newButton);

                    if (totalHeight < top)
                        totalHeight = top;

                    top += newButton.Height + 1;
                }
            }

            pictureBox1.SendToBack();
            //for resizing
            //pictureBox1.Size = new Size( (left*2) + 50, totalHeight + 75);
        }
    }
    }

