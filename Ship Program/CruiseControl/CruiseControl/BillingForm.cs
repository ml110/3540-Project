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

namespace CruiseControl
{
    public partial class BillingForm : Form
    {
        // Remember: add Reference MySQL.Data
        private MySqlConnection connection;
        MySqlCommand cmd;

        List<TRANSACTION> listTran;

        int tID; //TRIP
		int rNum; //curently loaded in roomnumber

        public BillingForm() //TEMP CONSTRUCTOR
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
            //DBConnect(); //TEMP THING
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
				rumID.Text = "";
				throw new ArgumentException("No passengers in the selected room!");
			}
			else
			{
				return name;
			}
		}

        //this method will generate the list of transactions associated with the RN
        private List<TRANSACTION> generateTrans(int RN)
        {
            //run two queries, one for drinks the other for gifts

			List<TRANSACTION> LT = new List<TRANSACTION>();

			//GIFT STUFF
			string giftQ = "SELECT G.gift_name AS ITEM, G.gift_price AS PRICE, concat(GT.sale_date, \" \", GT.sale_time) AS saleTime, concat(P.pass_firstname, \" \", P.pass_lastname) AS custName, WA.area_id AS AREA, S.staff_firstname AS staffName, R.room_number AS RN FROM GIFT_TRANSACTION AS GT";
				giftQ += " INNER JOIN GIFTS AS G ON GT.gift_id = G.gift_id";
				giftQ += " INNER JOIN ROOM_PASSENGER AS RP ON GT.roomPass_id = RP.roomPass_id";
				giftQ += " INNER JOIN ROOM AS R ON RP.room_id = R.room_id";
				giftQ += " INNER JOIN PASSENGER AS P ON RP.pass_id = P.pass_id";
				giftQ += " INNER JOIN STAFF AS S ON GT.staff_id = S.staff_id";
				giftQ += " INNER JOIN WORKAREAS AS WA ON GT.shop_id = WA.area_id";
				giftQ += " WHERE RP.trip_id = 1 AND R.room_number = '" + RN + "';";

			cmd.CommandText = giftQ;
			cmd.Connection = connection;
			MySqlDataReader MDR = cmd.ExecuteReader();

			while (MDR.Read())
			{
				TRANSACTION temp = new TRANSACTION();
				temp.item = MDR["ITEM"].ToString();
				temp.price = Convert.ToDouble(MDR["PRICE"].ToString());
				temp.saleTimeStamp = MDR["saleTime"].ToString();
				temp.customerName = MDR["custName"].ToString();
				temp.areaName = MDR["AREA"].ToString();
				temp.staffName = MDR["staffName"].ToString();
				temp.roomNum = Convert.ToInt32(MDR["RN"].ToString());

				LT.Add(temp);
			}
			MDR.Close();

			//DRINK STUFF
			string drinkQ = "SELECT D.drink_name AS ITEM, D.drink_price AS PRICE, concat(BT.sale_date, \" \", BT.sale_time) AS saleTime, concat(P.pass_firstname, \" \", P.pass_lastname) AS custName, WA.area_id AS AREA, S.staff_firstname AS staffName, R.room_number AS RN FROM BAR_TRANSACTION AS BT";
				drinkQ += " INNER JOIN DRINKS AS D ON BT.drink_id = D.drink_id";
				drinkQ += " INNER JOIN ROOM_PASSENGER AS RP ON BT.roomPass_id = RP.roomPass_id";
				drinkQ += " INNER JOIN ROOM AS R ON RP.room_id = R.room_id";
				drinkQ += " INNER JOIN PASSENGER AS P ON RP.pass_id = P.pass_id";
				drinkQ += " INNER JOIN STAFF AS S ON BT.bartender_id = S.staff_id";
				drinkQ += " INNER JOIN WORKAREAS AS WA ON BT.bar_id = WA.area_id";
				drinkQ += " WHERE RP.trip_id = 1 AND R.room_number = '" + RN + "';";

			cmd.CommandText = drinkQ;
			cmd.Connection = connection;
			MDR = cmd.ExecuteReader();

			while (MDR.Read())
			{
				TRANSACTION temp = new TRANSACTION();
				temp.item = MDR["ITEM"].ToString();
				temp.price = Convert.ToDouble(MDR["PRICE"].ToString());
				temp.saleTimeStamp = MDR["saleTime"].ToString();
				temp.customerName = MDR["custName"].ToString();
				temp.areaName = MDR["AREA"].ToString();
				temp.staffName = MDR["staffName"].ToString();
				temp.roomNum = Convert.ToInt32(MDR["RN"].ToString());

				LT.Add(temp);
			}
			MDR.Close();

			return LT;
        }

		//this method shows the receipt up on the display
		private void showReceipt(string BH, List<TRANSACTION> LT)
		{
			//room number workaround
			int RN = LT.ElementAt(0).roomNum;
			double totalPrice = 0;

			//need to sort the LT first by date
			LT = LT.OrderBy(o => o.saleTimeStamp).ToList();

			txtReceipt.Text = "\r\n" + "ROOM " + String.Format("{0:D5}", RN) + "\r\n";
			txtReceipt.Text += "BILL HOLDER: " + BH + "\r\n";
			txtReceipt.Text += "===============================================================================================================\r\n";
			txtReceipt.Text += String.Format("{0,-35} {1,8} {2,22} {3,20} {4,9} {5,12}", "ITEM", "PRICE", "PURCHASE DATE", "CUSTOMER", "LOCATION", "STAFF") + "\r\n"; //TITLES
			txtReceipt.Text += "===============================================================================================================\r\n";
			for (int i = 0; i < LT.Count; i++)
			{
				txtReceipt.Text += String.Format("{0,-35} {1,8:C2} {2,22} {3,20} {4,9} {5,12}", LT.ElementAt(i).item, LT.ElementAt(i).price, LT.ElementAt(i).saleTimeStamp, LT.ElementAt(i).customerName, LT.ElementAt(i).areaName, LT.ElementAt(i).staffName) + "\r\n";
				
				//calculate the total price while this runs
				totalPrice += LT.ElementAt(i).price;
			}
			txtReceipt.Text += "===============================================================================================================\r\n";
			txtReceipt.Text += String.Format("{0,-35} {1,8:C2}", "TOTAL", totalPrice) + "\r\n";
			txtReceipt.Text += "===============================================================================================================\r\n" + "\r\n";

			txtReceipt.Text += "THANK YOU FOR SAILING WITH STEVE'S CRUISE LINE" + "\r\n";
			txtReceipt.Text += "WE HOPE TO SEE YOU AGAIN SOON!";
		}

		//This should calculate all the expenses
		private void btnCalc_Click(object sender, EventArgs e)
		{
			string billName = "";

			try
			{
				rNum = Int32.Parse(rumID.Text.Trim());
				billName = getBHname(rNum);
				listTran = generateTrans(rNum);

				showReceipt(billName, listTran);
			}
			catch (ArgumentException ex)
			{
				MessageBox.Show(ex.Message, "OOPS", MessageBoxButtons.OK);
			}
			catch (FormatException)
			{
				MessageBox.Show("Invalid Input!", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

        //This needs to generate the Bill
        private void printBill_Click(object sender, EventArgs e)
        {
			if (txtReceipt.Text == "" || txtReceipt.Text == null)
			{
				MessageBox.Show("No bill loaded!", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				StreamWriter myFile = new StreamWriter("../../../SAVED BILLS/ROOM " + rNum.ToString() + " BILL.txt");

				for (int i = 0; i < txtReceipt.Lines.Length; i++)
				{
					myFile.WriteLine(txtReceipt.Lines[i]);
				}

				myFile.Close();
				MessageBox.Show("Bill saved!", "SUCCESS");
			}
        }

		
    }
}