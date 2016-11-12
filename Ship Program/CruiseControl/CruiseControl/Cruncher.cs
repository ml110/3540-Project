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
	class Cruncher
	{
		//METHOD FOR GETTING THE SHIFT ID BASED ON: trip_id, shift_start, shift_end, area_id
		private int getShiftID(int tID, string sStart, string sEnd, int aID)
		{
			int shiftID = 0;

			return shiftID;
		}
	}
}
