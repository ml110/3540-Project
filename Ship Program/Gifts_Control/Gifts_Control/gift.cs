using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gifts_Control
{
    class gift
    {
        private int gift_id;
        private double gift_price;
        private string gift_name;




        private int inventory;

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
        public int Inventory
        {
            set
            {
                inventory = value;
            }
            get
            {
                return inventory;
            }
        }

        public override string ToString()
        {
            string s = "gift_id: " + gift_id;
            return s;
        }
    }
}

