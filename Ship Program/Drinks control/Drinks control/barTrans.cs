using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drinks_control
{
    class barTrans
    {
        private string bar_name;
        private string pass_f;
        private string pass_l;
        private int roomPass_id;
        
        private DateTime date;
        private int staff_id;
        private string drink_name;
        public string barName
        {
            set
            {
                bar_name = value;
            }
            get
            {
                return bar_name;
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
            string s = "drink_name: " + drink_name;
            return s;
        }
    }
}
