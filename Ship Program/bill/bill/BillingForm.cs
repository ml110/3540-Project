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

namespace bill
{
    public partial class BillingForm : Form
    {
        // Remember: add Reference MySQL.Data
        private MySqlConnection connection;
        MySqlCommand cmd;
        
        private List<GIFT> gList;
        private List<DRINK> dList;
        private List<Customer> pList;
        
        GIFT g;
        DRINK d;
        Customer rp;

        int tID; //TRIP
        int sID; //SHIP

        public BillingForm()
        {
            InitializeComponent();
            cmd = new MySqlCommand();
        }

        //RELEASE CONSTRUCTOR
        public BillingForm(MySqlConnection CONN, MySqlCommand CMD, int TN)
        {
            InitializeComponent();
            connection = CONN;
            cmd = CMD;
            tID = TN;
        }

        private void BillingForm_Load(object sender, EventArgs e)
        {
            gList = new List<GIFT>();
            dList = new List<DRINK>();
            pList = new List<Customer>();

            DBConnect(); //TEMP THING
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

        private void setupSqlCommand(String query)
        {
            cmd.Connection = connection;
            cmd.CommandText = query;
        }

        private void calcBill_Click(object sender, EventArgs e)
        {
            string query1 = "SELECT isBillHolder FROM ROOM_PASSENGER WHERE roomPass_id = " + rumID.Text;
            string query = "select gt.gift_id, gt.giftSale_id, g.gift_name, g.gift_price, gt.sale_time, gt.sale_date, gt.shop_id from GIFT_TRANSACTION as gt INNER JOIN GIFTS as  g on gt.gift_id = g.gift_id  where gt.roomPass_id = " + rumID.Text;
            string query2 = " select bt.drink_id, bt.barSale_id, d.drink_name, d.drink_price, bt.sale_time, bt.sale_date, bt.bar_id from  BAR_TRANSACTION as bt   INNER JOIN DRINKS as  d on d.drink_id = bt.drink_id  where bt.roomPass_id = " + rumID.Text;
            bool value = true;
            string query3 = "select pass_firstname , pass_lastname from PASSENGER where pass_id =" + rumID.Text;
            // MessageBox.Show(query);

            //Open connection
            if (connection != null)
            {
                setupSqlCommand(query1);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    rp = new Customer();
                    // MessageBox.Show(dataReader["isBillHolder"].ToString());
                    rp.isBillHolder = (dataReader["isBillHolder"].ToString() == "True");
					MessageBox.Show(rp.isBillHolder.ToString());
                    pList.Add(rp);
                }

                //close Data Reader
                dataReader.Close();

                if (rp.isBillHolder == value)
                {
                    string filename = "Bill - " + rp.pass_fname + " " + rp.pass_lname + ".txt";
                    label5.Text = null;

                    using (StreamWriter file = new StreamWriter(filename))
                    {
                        label5.Text = "";

                        setupSqlCommand(query3);
                        dataReader = cmd.ExecuteReader();

                        while (dataReader.Read())
                        {
                            rp = new Customer();

                            rp.pass_fname = (dataReader["pass_firstname"].ToString());
                            rp.pass_lname = (dataReader["pass_lastname"].ToString());

                            pList.Add(rp);
                        }

                        //close Data Reader
                        dataReader.Close();
                            label5.Text = "Bill Holder Name : " + rp.pass_fname +" " + rp.pass_lname + "\n";
                            file.WriteLine("Bill Holder Name : " + rp.pass_fname + " " + rp.pass_lname + "\n");
                        

                        setupSqlCommand(query);
                        dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            g = new GIFT();

                            g.giftID = int.Parse(dataReader["gift_id"].ToString());
                            g.giftNAME = (dataReader["gift_name"].ToString());
                            g.giftPRICE = double.Parse(dataReader["gift_price"].ToString());
                            g.gsID = (int.Parse(dataReader["giftSale_id"].ToString()));
                            g.Date = (DateTime.Parse(dataReader["sale_date"].ToString()));
                            g.saleTIME = (DateTime.Parse(dataReader["sale_time"].ToString()));

                            gList.Add(g);
                        }

                        //close Data Reader
                        dataReader.Close();

                        double sum = 0;
                        
                        string header = String.Format("{0,-10}{1,-25}{2,-10}{3,-12}{4,-12}\n",
                                       "SaleID", "Name", "Price", "Date", "Time" );
                        label5.Text += "\n";
                        label5.Text += header + "\n";
                        file.WriteLine( "\n");
                        file.WriteLine(header + "\n");
                        
                        foreach (GIFT ab in gList)
                        {
                            string output = String.Format("{0,-10}{1,-25}{2,-10:c}{3,-12:yyyy-MM-dd}{4,-12:hh:mm:ss}",
                                ab.gsID, ab.giftNAME , ab.giftPRICE,ab.Date, ab.saleTIME );
                            label5.Text += output + "\n";
                            file.WriteLine(output + "\n");
                            sum += ab.giftPRICE;
                        }

                        //  MessageBox.Show(sum.ToString());
                        setupSqlCommand(query2);
                        dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {
                            d = new DRINK();

                            d.barID = (int.Parse(dataReader["bar_id"].ToString()));
                            d.bsID = (int.Parse(dataReader["barSale_id"].ToString()));
                            d.drinkID = (int.Parse(dataReader["drink_id"].ToString()));
                            d.drinkNAME = dataReader["drink_name"].ToString();
                            d.drinkPRICE = double.Parse(dataReader["drink_price"].ToString());
                            d.Date = (DateTime.Parse(dataReader["sale_date"].ToString()));
                            d.saleTIME = (DateTime.Parse(dataReader["sale_time"].ToString()));

                            dList.Add(d);
                        }

                        //close Data Reader
                        dataReader.Close();
                        foreach (DRINK ef in dList)
                        {
                            string output1 = String.Format("{0,-10}{1,-25}{2,-10:c}{3,-12:yyyy-MM-dd}{4,-12:hh:mm:ss}", ef.bsID, ef.drinkNAME, ef.drinkPRICE, ef.Date, ef.saleTIME);
    
                            label5.Text += (output1 + "\n");
                            file.WriteLine(output1 + "\n");
                            sum += ef.drinkPRICE;
                        }

                        label5.Text += "=====================\n";
                        file.WriteLine("===================\n");
                        label5.Text += "Your Total Bill is : $";
                        label5.Text += sum.ToString();
                        file.WriteLine("Your Total Bill is : $"+ sum.ToString());
                        label5.Text += "\n \n THANKS";
                        file.WriteLine("\n");
                        file.WriteLine( "\n"+"THANKS");
                    }
                }
                else
                {
                    label5.Text = null;
                    label5.Text = ("Passenger is not a bill holder!");
                }
            }
            else
            {
                MessageBox.Show("Try to connect");
            }
		}

		//this will give the bill holder's name for the reciept given the roomnumber
		private string getBHname(int RN)
		{
			string name = "";
			string QUERY = "SELECT R.room_number, concat(P.pass_firstname, \" \", P.pass_lastname) AS billHolder FROM ROOM_PASSENGER AS RP";
			QUERY += " INNER JOIN PASSENGER AS P ON RP.pass_id = P.pass_id";
			QUERY += " INNER JOIN ROOM AS R ON RP.room_id = R.room_id";
			QUERY += " WHERE RP.trip_id = 1 AND RP.isBillHolder = 1 AND R.room_number = '" + RN + "';";

			cmd.Connection = connection;
			cmd.CommandText = QUERY;
			MySqlDataReader MDR = cmd.ExecuteReader();

			while (MDR.Read())
			{
				name = MDR["billHolder"].ToString();
			}
			MDR.Close();

			if (name == null || name == "")
			{
				throw new ArgumentException("No passengers in the selected room!");
			}
			else
			{
				return name;
			}
		}

		//This should calculate all the expenses
		private void btnCalc_Click(object sender, EventArgs e)
		{
			string billName = "";

			try
			{
				billName = getBHname(Int32.Parse(rumID.Text.Trim()));
				MessageBox.Show(billName);
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message, "OOPS", MessageBoxButtons.OK);
			}
		}

        //This needs to generate the Bill
        private void printBill_Click(object sender, EventArgs e)
        {
                
        }

		
    }
}