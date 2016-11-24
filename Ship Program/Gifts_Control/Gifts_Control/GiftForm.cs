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
    public partial class GiftForm : Form
    {

        private MySqlConnection connection;
        MySqlCommand cmd;

		int tID; //TRIP
		int sID; //SHIP

        public GiftForm()
        {
            InitializeComponent();
            cmd = new MySqlCommand();    
        }

		//REALESE CONSTRUCTOR
        public GiftForm(MySqlConnection CONN, MySqlCommand CMD, int TN, int SN)
        {
            InitializeComponent();
            connection = CONN;
            cmd = CMD;
            tID = TN;
			sID = SN;
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
			tID = 1;
			sID = 1;
        }

        private void setupSqlCommand(String query)
        {
            cmd.Connection = connection;
            cmd.CommandText = query;
        }

		private void GiftForm_Load(object sender, EventArgs e)
		{
			DBConnect();
			displayInv();
		}

		private void displayInv()
		{
			string query = "select GIFTS.gift_id AS ID, gift_name AS GIFT, gift_price AS PRICE, inventory AS STOCK from GIFTS, GIFT_INV ";
			query += " where GIFTS.gift_id = GIFT_INV.gift_id and GIFT_INV.ship_id = '" + sID + "'";

			DataSet DS = new DataSet();
			dgvDisplay.DataSource = null;
			MySqlDataAdapter MDA;

			MDA = new MySqlDataAdapter(query, connection);
			MDA.Fill(DS, "INV");
			dgvDisplay.DataSource = DS.Tables["INV"];
		}

		private void addInv()
		{
			int s = dgvDisplay.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dgvDisplay.Rows[s];
			string a = Convert.ToString(selectedRow.Cells[3].Value);
			//MessageBox.Show(a);

			int number = int.Parse(num.Text);

			int result = number + int.Parse(a);
			dgvDisplay.Rows[s].Cells[3].Value = result.ToString();
			//MessageBox.Show(result.ToString());

			string a1 = Convert.ToString(selectedRow.Cells[0].Value);

			string query = " UPDATE GIFT_INV SET inventory = " + result + " WHERE GIFT_id = " + a1 + " and ship_id = 1 ";
			setupSqlCommand(query);
			cmd.ExecuteNonQuery();

			//MessageBox.Show(query);
			displayInv();
			num.Text = "";
		}

        private void AddBtn_Click(object sender, EventArgs e)
        {
			try
			{
				addInv();
			}
			catch (FormatException)
			{
				MessageBox.Show("Please enter a valid number!", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (MySqlException)
			{
				MessageBox.Show("There was an error updating the inventory. Please contact an Administrator", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

		private void decInv()
		{
			int s = dgvDisplay.SelectedCells[0].RowIndex;
			DataGridViewRow selectedRow = dgvDisplay.Rows[s];
			string a = Convert.ToString(selectedRow.Cells[3].Value);
			//MessageBox.Show("Inventry after update: " + a);

			int number = int.Parse(num.Text);

			int result = int.Parse(a) - number;
			dgvDisplay.Rows[s].Cells[3].Value = result.ToString();
			//MessageBox.Show("Inventry after update: " + result.ToString());

			string a1 = Convert.ToString(selectedRow.Cells[0].Value);

			string query = " UPDATE GIFT_INV SET inventory = " + result + " WHERE gift_id = " + a1 + " and ship_id = 1 ";
			setupSqlCommand(query);
			cmd.ExecuteNonQuery();

			// MessageBox.Show(query);
			displayInv();
			num.Text = "";
		}

        private void MinBtn_Click(object sender, EventArgs e)
        {
			try
			{
				decInv();
			}
			catch (FormatException)
			{
				MessageBox.Show("Please enter a valid number!", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (MySqlException)
			{
				MessageBox.Show("There was an error updating the inventory. Please contact an Administrator", "OOPS", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }

		private void showLog()
		{
			string logQuery = "SELECT concat(GT.sale_date, \" \", GT.sale_time) AS SALETIME, G.gift_name AS GIFT, G.gift_price AS PRICE,  concat(P.pass_firstname, \" \", P.pass_lastname) AS CUSTOMER, WA.area_name AS SHOP, concat(S.staff_firstname, \" \", S.staff_lastname) AS STAFF FROM GIFT_TRANSACTION AS GT";
				logQuery += " INNER JOIN GIFTS AS G ON GT.gift_id = G.gift_id";
				logQuery += " INNER JOIN ROOM_PASSENGER AS RP ON GT.roomPass_id = RP.roomPass_id";
				logQuery += " INNER JOIN ROOM AS R ON RP.room_id = R.room_id";
				logQuery += " INNER JOIN PASSENGER AS P ON RP.pass_id = P.pass_id";
				logQuery += " INNER JOIN STAFF AS S ON GT.staff_id = S.staff_id";
				logQuery += " INNER JOIN WORKAREAS AS WA ON GT.shop_id = WA.area_id";
				logQuery += " WHERE RP.trip_id = '" + tID + "'";
				logQuery += " ORDER BY SALETIME";

			DataSet DS = new DataSet();
			dgvDisplay.DataSource = null;
			MySqlDataAdapter MDA;

			MDA = new MySqlDataAdapter(logQuery, connection);
			MDA.Fill(DS, "LOG");
			dgvDisplay.DataSource = DS.Tables["LOG"];
		}

		private void btnLog_Click(object sender, EventArgs e)
		{
			showLog();
			MinBtn.Enabled = false;
			AddBtn.Enabled = false;
			num.Enabled = false;
		}

		private void btnInvControl_Click(object sender, EventArgs e)
		{
			displayInv();
			MinBtn.Enabled = true;
			AddBtn.Enabled = true;
			num.Enabled = true;
		}
        
    }
}
