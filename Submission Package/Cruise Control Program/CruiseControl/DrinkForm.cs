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
    public partial class DrinkForm : Form
    {
        private MySqlConnection connection;
        MySqlCommand cmd;

        int tID; //TRIP
        int sID; //SHIP

        public DrinkForm()
        {
            InitializeComponent();
            cmd = new MySqlCommand();
        }

        //REALESE CONSTRUCTOR
        public DrinkForm(MySqlConnection CONN, MySqlCommand CMD, int TN, int SN)
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
       
        private void DrinkForm_Load(object sender, EventArgs e)
        {
			//DBConnect(); //remove from release version
			displayInv();
        }

        private void setupSqlCommand(String query)
        {
            cmd.Connection = connection;
            cmd.CommandText = query;
        }

		//moving some code here to create a seperate method for inventory display
		private void displayInv()
		{
			string query = "select DRINKS.drink_id AS ID, drink_name AS DRINK, drink_price AS PRICE, inventory AS STOCK from DRINKS, DRINK_INV ";
			query += " where DRINKS.drink_id = DRINK_INV.drink_id and DRINK_INV.ship_id = '" + sID + "'";
			
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
			//MessageBox.Show("Inventry before update: "+a);

			int number = int.Parse(num.Text);

			int result = number + int.Parse(a);
			dgvDisplay.Rows[s].Cells[3].Value = result.ToString();
			//MessageBox.Show("Inventry after update: "+result.ToString());

			string a1 = Convert.ToString(selectedRow.Cells[0].Value);

			string query = " UPDATE DRINK_INV SET inventory = " + result + " WHERE drink_id = " + a1 + " and ship_id = '" + sID + "'";
			setupSqlCommand(query);
			cmd.ExecuteNonQuery();

			//MessageBox.Show(query);
			displayInv();
			num.Text = "";
		}

        private void Add_Click(object sender, EventArgs e)
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
			//MessageBox.Show("Inventory before update:" +a);

			int number = int.Parse(num.Text);

			int result = int.Parse(a) - number;
			dgvDisplay.Rows[s].Cells[3].Value = result.ToString();
			//MessageBox.Show("Inventory after update: "+result.ToString());

			string a1 = Convert.ToString(selectedRow.Cells[0].Value);

			string query = " UPDATE DRINK_INV SET inventory = " + result + " WHERE drink_id = " + a1 + " and ship_id = '" + sID + "'";
			setupSqlCommand(query);
			cmd.ExecuteNonQuery();

			displayInv();
			num.Text = "";
		}

        private void minus_Click(object sender, EventArgs e)
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
			string logQuery = "SELECT concat(BT.sale_date, \" \", BT.sale_time) AS SALETIME, D.drink_name AS DRINK, D.drink_price AS PRICE,  concat(P.pass_firstname, \" \", P.pass_lastname) AS CUSTOMER, WA.area_name AS BAR, concat(S.staff_firstname, \" \", S.staff_lastname) AS BARTENDER FROM BAR_TRANSACTION AS BT";
				logQuery += " INNER JOIN DRINKS AS D ON BT.drink_id = D.drink_id";
				logQuery += " INNER JOIN ROOM_PASSENGER AS RP ON BT.roomPass_id = RP.roomPass_id";
				logQuery += " INNER JOIN ROOM AS R ON RP.room_id = R.room_id";
				logQuery += " INNER JOIN PASSENGER AS P ON RP.pass_id = P.pass_id";
				logQuery += " INNER JOIN STAFF AS S ON BT.bartender_id = S.staff_id";
				logQuery += " INNER JOIN WORKAREAS AS WA ON BT.bar_id = WA.area_id";
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
			minus.Enabled = false;
			Add.Enabled = false;
			num.Enabled = false;
		}

		private void btnInvControl_Click(object sender, EventArgs e)
		{
			displayInv();
			minus.Enabled = true;
			Add.Enabled = true;
			num.Enabled = true;
		}

    }
}