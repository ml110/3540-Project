using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace customerSignUp
{
    public class inputValidation
    {

        public static bool checkEmail(String email)
        {
            bool isValid = false;
            Regex r = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            if (r.IsMatch(email))
            {
                isValid = true;
            }
            return isValid;
        }

        public static bool checkNames(String name)
        {
            bool isValid = false;
            Regex r = new Regex(@"^[a-zA-Z]+$");
            if (r.IsMatch(name))
            {
                isValid = true;
            }
            return isValid;
        }

        public static bool checkPhone(String phone)
        {
            bool isValid = false;
            Regex r = new Regex("^[0-9]*$");
            if (r.IsMatch(phone))
            {
                isValid = true;
            }
            return isValid;
        }

        public static bool checkCity(String city)
        {
            bool isValid = false;
            Regex r = new Regex(@"^[a-zA-Z ]*$");
            if (r.IsMatch(city))
            {
                isValid = true;
            }
            return isValid;
        }

        public static bool checkCountry(String Country)
        {
            bool isValid = false;
            Regex r = new Regex(@"^[a-zA-Z]+$");
            if (r.IsMatch(Country))
            {
                isValid = true;
            }
            return isValid;
        }


    }
}
