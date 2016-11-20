using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bill
{
    class DRINK
    {
        private int drink_id;
        private double drink_price;
        private string drink_name;
        private int bs_id;
        private int roomPass_id;
        private int bar_id;
        private DateTime date;
        private DateTime stime;
        private int s_id;
        private string pass_firstname;
        private string pass_lastname;

        public int staffID
        {
            set
            {
                s_id = value;
            }
            get
            {
                return s_id;
            }
        }
        public string pass_fname
        {
            set
            {
                pass_firstname = value;
            }
            get
            {
                return pass_firstname;
            }
        }
        public string pass_lname
        {
            set
            {
                pass_lastname = value;
            }
            get
            {
                return pass_lastname;
            }
        }

        public int bsID
        {
            set
            {
                bs_id = value;
            }
            get
            {
                return bs_id;
            }
        }
        public int drinkID
        {
            set
            {
                drink_id = value;
            }
            get
            {
                return drink_id;
            }
        }
        public int roomPID
        {
            set
            {
                roomPass_id = value;
            }
            get
            {
                return roomPass_id;
            }
        }
        public int barID
        {
            set
            {
                bar_id = value;
            }
            get
            {
                return bar_id;
            }
        }
        public DateTime Date
        {
            set
            {
                date = value;
            }
            get
            {
                return date;
            }
        }
        public DateTime saleTIME
        {
            set
            {
                stime = value;
            }
            get
            {
                return stime;
            }
        }

        public string drinkNAME
        {
            set
            {
                drink_name = value;
            }
            get
            {
                return drink_name;
            }
        }
        public double drinkPRICE
        {
            set
            {
                drink_price = value;
            }
            get
            {
                return drink_price;
            }
        }
       

        public override string ToString()
        {
            string s = "drink_id: " + drink_id;
            return s;
        }
    }
}
