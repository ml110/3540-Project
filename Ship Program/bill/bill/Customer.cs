using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bill
{
    class Customer
    {
        private bool billHolder;
        private int roomPass_id;
        private string pass_firstname;
        private string pass_lastname;

        public int rumPassID
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
        public bool isBillHolder
        {
            set
            {
                billHolder = value;
            }
            get
            {
                return billHolder;
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
    }
}
