using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gifts_Control
{
    class giftInv
    {

        private int gift_id;
        private int ship_id;
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
        public int shipID
        {
            set
            {
                ship_id = value;
            }
            get
            {
                return ship_id;
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

