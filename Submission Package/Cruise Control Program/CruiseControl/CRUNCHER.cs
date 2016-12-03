///////////////////////////////////////////////////////////////////////////////////////////////////
/* CSIS 3540 - CLIENT SERVER SYSTEMS
 * CRUISE LINE PROJECT - SHIPBOARD APPLICATION - SQL INSERTION VALUES CRUNCHER
 * 
 * This class is a collections of methods that converts text user inputs into values that will be
 * used for insertion SQL commands.
 * 
 */
///////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///////////////////////////////////////////////////////////////////////////////////////////////////
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CruiseControl
{
	class CRUNCHER
	{
        //SQL Connection
        private MySqlConnection connection;
        MySqlCommand command;

        //CONSTRUCTOR for getting the connection stuff
        public CRUNCHER(MySqlConnection con, MySqlCommand cmd)
        {
            connection = con;
            command = cmd;
        }
        
        //METHOD FOR GETTING THE SHIFT ID BASED ON: trip_id, shift_start, shift_end, area_id
		public int getShiftID(int tID, string sStart, string sEnd, int aID)
		{
			int shiftID = 0;

            Debug.WriteLine("SHIFTID WHERE CONDS: " + tID + " " + sStart + " " + sEnd + " " + aID);

            command.CommandText = "SELECT shift_id FROM SHIFT WHERE trip_id = '" + tID + "'";
                command.CommandText += " AND shift_start = \"" + sStart + "\"";
                command.CommandText += " AND shift_end = \"" + sEnd + "\"";
                command.CommandText += " AND area_id = '" + aID + "'";
            command.Connection = connection;
            MySqlDataReader sRead = command.ExecuteReader();

            while (sRead.Read())
            {
                shiftID = Int16.Parse(sRead["shift_id"].ToString());
            }

            sRead.Close();

			return shiftID;
		}

        //METHOD FOR GETTING THE LAST (int) PK IN A TABLE
        public int getLastPK(string tableName, string fieldName)
        {
            int lastPK = 0;

            command.CommandText = "SELECT " + fieldName + " FROM " + tableName + " ORDER BY " + fieldName + " DESC LIMIT 1;";
            command.Connection = connection;
            MySqlDataReader sRead = command.ExecuteReader();

            while (sRead.Read())
            {
                lastPK = Int16.Parse(sRead[0].ToString());
            }

            sRead.Close();

            return lastPK;
        }

        //METHOD FOR GETTING THE PK OF A ROW GIVEN A (string) FIELD
        public int getPK(string tableName, string keyField, string condField, string condition)
        {
            int PK = 0;

            Debug.WriteLine("AID WHERE CONDS: " + tableName + " " + keyField + " " + condField + " " + condition);

            command.CommandText = "SELECT " + keyField + " FROM " + tableName + " WHERE " + condField + " = \"" + condition + "\"";
            command.Connection = connection;
            MySqlDataReader sRead = command.ExecuteReader();

            while (sRead.Read())
            {
                PK = Int16.Parse(sRead[0].ToString());
            }

            sRead.Close();

            return PK;
        }

        //METHOD FOR GETTING THE STAFF ID GIVEN THEIR NAME, JOBID (and boat i guess)
        public int getStaffID(int ship, string first, string last, int jobID)
        {
            int staffID = 0;

            command.CommandText = "SELECT staff_id FROM STAFF WHERE ship_id = '" + ship + "'";
                command.CommandText += " AND staff_firstname = \"" + first + "\"";
                command.CommandText += " AND staff_lastname = \"" + last + "\"";
                command.CommandText += " AND job_id = '" + jobID + "'";
            command.Connection = connection;
            MySqlDataReader sRead = command.ExecuteReader();

            while (sRead.Read())
            {
                staffID = Int16.Parse(sRead["staff_id"].ToString());
            }

            sRead.Close();

            return staffID;
        }
	}
}
