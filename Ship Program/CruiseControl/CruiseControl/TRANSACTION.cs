//THIS CLASS FOR USE IN BILLING FORM
//Represents the purchase of a gift or a drink
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CruiseControl
{
    class TRANSACTION
    {
        public string item { get; set; }
        public double price { get; set; }
        public string saleTimeStamp { get; set; }
        public string customerName { get; set; }
        public string areaName { get; set; }
        public string staffName { get; set; }

		//heh
		public int roomNum { get; set; }

        public string printLine()
        {
            string transactionString = "";

            transactionString = item + "\t";
            transactionString += price.ToString() + "\t";
            transactionString += saleTimeStamp + "\t";
            transactionString += customerName + "\t";
            transactionString += areaName + "\t";
            transactionString += staffName + "\t";

            return transactionString;
        }
    }
}
