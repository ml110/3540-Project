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
namespace Drinks_control
{
    public partial class DrinkForm : Form
    {
        private MySqlConnection connection;
        MySqlCommand cmd;


        private List<drinkInv> DrinkList;

        private List<barTrans> dt;

        private List<drink> dList;

        drinkInv bt;
        barTrans btrans;
        drink d;

        int tID; //TRIP
        int sID; //SHIP

        public DrinkForm()
        {
            InitializeComponent();
            cmd = new MySqlCommand();
        }

        //REALESE CONSTRUCTOR
        public DrinkForm(MySqlConnection CONN, MySqlCommand CMD, int TN)
        {
            InitializeComponent();
            connection = CONN;
            cmd = CMD;
            tID = TN;
        }

        //TEMP CONNECTION METHOD
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
        }
       
        private void DrinkForm_Load(object sender, EventArgs e)
        {

            DBConnect();

            dList = new List<drink>();
            DrinkList = new List<drinkInv>();
            dt = new List<barTrans>();

            string query = "select DRINKS.drink_id,drink_name,drink_price,inventory from DRINKS,DRINK_INV ";
            query += " where DRINKS.drink_id = DRINK_INV.drink_id and DRINK_INV.ship_id = 1";

            if (connection != null)
            {
                setupSqlCommand(query);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    bt = new drinkInv();
                    d = new drink();

                    d.drinkID = (int.Parse(dataReader["drink_id"].ToString()));
                    d.drinkNAME = (dataReader["drink_name"].ToString());
                    d.drinkPRICE = double.Parse(dataReader["drink_price"].ToString());
                    d.Inventory = int.Parse(dataReader["inventory"].ToString());
                    dList.Add(d);
                }

                //close Data Reader
                //  MessageBox.Show(dList.Count.ToString());
                dataReader.Close();

                dataGridView1.DataSource = null;
                // dataGridView1.SelectedRows.Clear();

                dataGridView1.DataSource = dList;
                //   dataGridView1.DataSource = dList;
            }
            else
            {
                MessageBox.Show("Try to connect");
            }
        }

        private void setupSqlCommand(String query)
        {
            cmd.Connection = connection;
            cmd.CommandText = query;
        }

       

        private void Add_Click(object sender, EventArgs e)
        {
            int s = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[s];
            string a = Convert.ToString(selectedRow.Cells[3].Value);
            MessageBox.Show("Inventry before update: "+a);

            int number = int.Parse(num.Text);

            int result = number + int.Parse(a);
            dataGridView1.Rows[s].Cells[3].Value = result.ToString();
            MessageBox.Show("Inventry after update: "+result.ToString());

            
            string a1 = Convert.ToString(selectedRow.Cells[0].Value);

            string query = " UPDATE DRINK_INV SET inventory = " + result + " WHERE drink_id = " + a1 + " and ship_id = 1 ";
            setupSqlCommand(query);
            cmd.ExecuteNonQuery();

            MessageBox.Show(query);
            
        }

        private void minus_Click(object sender, EventArgs e)
        {
            int s = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[s];
            string a = Convert.ToString(selectedRow.Cells[3].Value);
            MessageBox.Show("Inventory before update:" +a);

            int number = int.Parse(num.Text);

            int result = int.Parse(a) - number;
            dataGridView1.Rows[s].Cells[3].Value = result.ToString();
            MessageBox.Show("Inventory after update: "+result.ToString());

            
            string a1 = Convert.ToString(selectedRow.Cells[0].Value);

            string query = " UPDATE DRINK_INV SET inventory = " + result + " WHERE drink_id = " + a1 + " and ship_id = 1 ";
            setupSqlCommand(query);
            cmd.ExecuteNonQuery();

        }

        private void Drinks_Click(object sender, EventArgs e)
        {
            string query = "select DRINKS.drink_name,BAR_TRANSACTION.bartender_id,BAR_TRANSACTION.sale_date,BAR_TRANSACTION.bar_id,BAR_TRANSACTION.roomPass_id,";
            query += " WORKAREAS.area_name,PASSENGER.pass_firstname,PASSENGER.pass_lastname from DRINKS, PASSENGER ,BAR_TRANSACTION, ";
               
                   query += "  WORKAREAS where  BAR_TRANSACTION.roomPass_id = " + roomId.Text +" and BAR_TRANSACTION.bar_id = WORKAREAS.area_id  and BAR_TRANSACTION.roomPass_id = PASSENGER.pass_id and DRINKS.drink_id = BAR_TRANSACTION.drink_id order by BAR_TRANSACTION.sale_time and BAR_TRANSACTION.sale_date";



            if (connection != null)
            {



                setupSqlCommand(query);
                MySqlDataReader dataReader = cmd.ExecuteReader();




                while (dataReader.Read())
                {


                    btrans = new barTrans();

                    
                    btrans.drinkNAME = dataReader["drink_name"].ToString();
                    btrans.barName = (dataReader["area_name"].ToString());
                    btrans.StaffID = int.Parse(dataReader["bartender_id"].ToString());
                    btrans.Date = DateTime.Parse(dataReader["sale_date"].ToString());
                   
                    btrans.roomPID = int.Parse(dataReader["roomPass_id"].ToString());
                    btrans.passFirstname = (dataReader["pass_firstname"].ToString());
                    btrans.passLastname = (dataReader["pass_lastname"].ToString());
                    // btrans.Date.ToString("yyyy-MM-dd");
                    // btrans.saleTIME = DateTime.Parse(dataReader["sale_time"].ToString());
                    // btrans.saleTIME.ToString("hh:mm:ss");
                    dt.Add(btrans);

                }

                //close Data Reader
                dataReader.Close();

                dataGridView1.DataSource = null;
                // dataGridView1.SelectedRows.Clear();
                // MessageBox.Show(g);
                dataGridView1.DataSource = dt;
                //   dataGridView1.DataSource = dList;

            }
            else
            {
                MessageBox.Show("Try to connect");
            }
        }
    }
}