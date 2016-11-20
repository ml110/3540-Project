using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bill
{
    class GIFT
    {
        
        private int gift_id;
        private double gift_price;
        private string gift_name;
        private int gs_id;
        private int roomPass_id;
        private int shop_id;
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

        public int gsID
        {
            set
            {
                gs_id = value;
            }
            get
            {
                return gs_id;
            }
        }
        public int giftID
        {
            set
            {
                gift_id = value;
            }
            get
            {
                return gift_id;
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
        public int shopID
        {
            set
            {
                shop_id = value;
            }
            get
            {
                return shop_id;
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


        
        public string giftNAME
        {
            set
            {
                gift_name = value;
            }
            get
            {
                return gift_name;
            }
        }
        public double giftPRICE
        {
            set
            {
                gift_price = value;
            }
            get
            {
                return gift_price;
            }
        }
      
    
        public override string ToString()
        {
            string s = "gift_id: " + gift_id;
            return s;
        }
    }
}
