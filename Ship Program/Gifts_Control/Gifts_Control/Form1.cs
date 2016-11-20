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
namespace Gifts_Control
{
    public partial class Form1 : Form
    {

        private MySqlConnection connection;
        MySqlCommand cmd;

        private List<giftInv> GiftList;
        
        private List<giftTrans> gTrans;
        
        private List<gift> gList;
       
        giftInv gt;
        
        gift g;
     
        
        giftTrans gTrs;


        public Form1()
        {
            InitializeComponent();
            cmd = new MySqlCommand();
            
        }

        private void LoadInfo()
        {
            XmlReader reader = XmlReader.Create("data.xml");


            List<string> names = new List<string> { "uid", "password", "server", "database" };
            TextBox[] txt = { userTxt, passTxt, hostText, dbText };

            int index;
            while (reader.Read())
            {
                if (reader.IsStartElement() && names.IndexOf(reader.Name) >= 0)
                {
                    index = names.IndexOf(reader.Name);
                    reader.Read();
                    txt[index].Text = reader.Value;
                }
            }

            reader.Close();
        }

        private void Connect2Database()
        {
            string server = hostText.Text;
            string database = dbText.Text;


            string uid = userTxt.Text;
            string password = passTxt.Text;

            string connectionString;


            connectionString = "SERVER=" + server + ";DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open();
                MessageBox.Show("Connected");
                cmdConnect.Enabled = false;
                cmdClose.Enabled = true;
            }
            catch (MySqlException ex)
            {

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
        private void cmdLoad_Click(object sender, EventArgs e)
        {
            LoadInfo();

        }
        
        private void cmdConnect_Click(object sender, EventArgs e)
        {
            Connect2Database();

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            if (connection != null)
                connection.Close();
            cmdConnect.Enabled = true;
            cmdClose.Enabled = false;
            MessageBox.Show("Connection closed");

        }

        private void setupSqlCommand(String query)
        {
            cmd.Connection = connection;
            cmd.CommandText = query;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            int s = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[s];
            string a = Convert.ToString(selectedRow.Cells[3].Value);
            MessageBox.Show(a);

            int number = int.Parse(num.Text);

            int result = number + int.Parse(a);
            dataGridView1.Rows[s].Cells[3].Value = result.ToString();
            MessageBox.Show(result.ToString());

            
            string a1 = Convert.ToString(selectedRow.Cells[0].Value);

            string query = " UPDATE GIFT_INV SET inventory = " + result + " WHERE GIFT_id = " + a1 + " and ship_id = 1 ";
            setupSqlCommand(query);
            cmd.ExecuteNonQuery();

          //  MessageBox.Show(query);
        }

        private void MinBtn_Click(object sender, EventArgs e)
        {
            int s = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[s];
            string a = Convert.ToString(selectedRow.Cells[3].Value);
            MessageBox.Show("Inventry after update: "+a);

            int number = int.Parse(num.Text);

            int result = int.Parse(a) - number;
            dataGridView1.Rows[s].Cells[3].Value = result.ToString();
            MessageBox.Show("Inventry after update: "+result.ToString());

            
            string a1 = Convert.ToString(selectedRow.Cells[0].Value);

            string query = " UPDATE GIFT_INV SET inventory = " + result + " WHERE gift_id = " + a1 + " and ship_id = 1 ";
            setupSqlCommand(query);
            cmd.ExecuteNonQuery();

           // MessageBox.Show(query);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadInfo();
            Connect2Database();
            gList = new List<gift>();
           
            
            GiftList = new List<giftInv>();
            gTrans = new List<giftTrans>();
            

            string query = "select GIFTS.gift_id,gift_name,gift_price,inventory from GIFTS,GIFT_INV ";
            query += " where GIFTS.gift_id = GIFT_INV.gift_id and GIFT_INV.ship_id = 1 ";



            if (connection != null)
            {



                setupSqlCommand(query);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                 //   MessageBox.Show(query);


                while (dataReader.Read())
                {
                    gt = new giftInv();
                    g = new gift();

                    g.giftID = (int.Parse(dataReader["gift_id"].ToString()));
                    g.giftNAME = (dataReader["gift_name"].ToString());
                    g.giftPRICE = double.Parse(dataReader["gift_price"].ToString());
                    g.Inventory = int.Parse(dataReader["inventory"].ToString());
                    gList.Add(g);

                }

                //close Data Reader
                //  MessageBox.Show(dList.Count.ToString());
                dataReader.Close();

                dataGridView1.DataSource = null;
                // dataGridView1.SelectedRows.Clear();

                dataGridView1.DataSource = gList;
                //   dataGridView1.DataSource = dList;

            }
            else
            {
                MessageBox.Show("Try to connect");
            }
        }

        private void gftFilter_Click(object sender, EventArgs e)
        {
            string query = "select GIFTS.gift_name,GIFT_TRANSACTION.Shop_id,GIFT_TRANSACTION.sale_date,GIFT_TRANSACTION.roomPass_id,GIFT_TRANSACTION.staff_id,";
            query += " WORKAREAS.area_name,PASSENGER.pass_firstname,PASSENGER.pass_lastname from GIFTS, PASSENGER ,GIFT_TRANSACTION,";
            query += "WORKAREAS where  GIFT_TRANSACTION.roomPass_id = "+ roomId.Text + " and GIFT_TRANSACTION.shop_id = WORKAREAS.area_id  and GIFT_TRANSACTION.roomPass_id = PASSENGER.pass_id and GIFTS.gift_id = GIFT_TRANSACTION.gift_id order by GIFT_TRANSACTION.sale_time and GIFT_TRANSACTION.sale_date";



            if (connection != null)
            {



                setupSqlCommand(query);
                MySqlDataReader dataReader = cmd.ExecuteReader();




                while (dataReader.Read())
                {


                    gTrs = new giftTrans();

                    
                    gTrs.giftNAME = dataReader["gift_name"].ToString();
                  gTrs.shopName = (dataReader["area_name"].ToString());
                    gTrs.StaffID = int.Parse(dataReader["staff_id"].ToString());
                    
                    gTrs.roomPID = int.Parse(dataReader["roomPass_id"].ToString());
                    gTrs.Date = DateTime.Parse(dataReader["sale_date"].ToString());
                    gTrs.passFirstname = (dataReader["pass_firstname"].ToString());
                    gTrs.passLastname = (dataReader["pass_lastname"].ToString());
                    gTrans.Add(gTrs);
                   

                }

                //close Data Reader
                dataReader.Close();

                dataGridView1.DataSource = null;
               
                dataGridView1.DataSource = gTrans;

            }
            else
            {
                MessageBox.Show("Try to connect");
            }
        }

        
    }
}
