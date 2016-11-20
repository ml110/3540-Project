using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gifts_Control
{
    class giftTrans
    {
        private string shop_name;
        
        private string pass_f;
        private string pass_l;
        private string gift_name;
        private int roomPass_id;
       
        private DateTime date;
        private int staff_id;

        public string shopName
        {
            set
            {
                shop_name = value;
            }
            get
            {
                return shop_name;
            }
        }
        public string passFirstname
        {
            set
            {
                pass_f = value;
            }
            get
            {
                return pass_f;
            }
        }
        public string passLastname
        {
            set
            {
                pass_l = value;
            }
            get
            {
                return pass_l;
            }
        }

        public int StaffID
        {
            set
            {
                staff_id = value;
            }
            get
            {
                return staff_id;
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

        public override string ToString()
        {
            string s = "gift_name: " + gift_name;
            return s;
        }
    }
}

