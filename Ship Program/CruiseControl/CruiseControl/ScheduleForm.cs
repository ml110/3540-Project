///////////////////////////////////////////////////////////////////////////////////////////////////
/* CSIS 3540 - CLIENT SERVER SYSTEMS
 * CRUISE LINE PROJECT - SHIPBOARD APPLICATION - SCHEDULE FORM
 * 
 * Manupreet Kaur
 * Pawanpreet Kaur
 * Matthew Lai
 * Amanda Lee
 * Shaun Lu
 * Manjot Sangha
 * 
 */
///////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
///////////////////////////////////////////////////////////////////////////////////////////////////
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CruiseControl
{
	public partial class ScheduleForm : Form
	{
		//SQL Connection
		private MySqlConnection connection;
		MySqlCommand command;

		private int tripNum;
		
		public ScheduleForm(int TN, MySqlConnection con, MySqlCommand cmd)
		{
			InitializeComponent();
			connection = con;
			command = cmd;
			tripNum = TN;
		}

		//loads a combobox with options that are the result of a SQL query
		//IMPORTANT: Queries must only return a single column!
		private void setupComboBox(ComboBox CB, string QUERY)
		{
			if (CB.Enabled == false)
			{
				CB.Enabled = true;
			}

			command.CommandText = QUERY;
			command.Connection = connection;
			MySqlDataReader sRead = command.ExecuteReader();

			while (sRead.Read())
			{
				for (int i = 0; i < sRead.FieldCount; i++)
				{
					CB.Items.Add(sRead[i].ToString());
				}
			}

			sRead.Close();
		}

		private void ScheduleForm_Load(object sender, EventArgs e)
		{
			string dateQuery = "SELECT trip_date FROM TRIP_ITINERARY WHERE trip_id = '" + tripNum + "';";
			setupComboBox(cbDay, dateQuery);
		}


	}
}
