using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_control
{
    class drinkInv
    {
        

            private int drink_id;
            private int ship_id;
            private int inventory;


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
                string s = "drink_id: " + drink_id;
                return s;
            }
        }
    }

