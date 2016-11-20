using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_control
{
    class drink
    {
        
            private int drink_id;
            private double drink_price;
            private string drink_name;
            
            
           
           
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

