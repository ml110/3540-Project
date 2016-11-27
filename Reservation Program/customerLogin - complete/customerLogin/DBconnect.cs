using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerSignUp
{
    class DBConnect
    {

        private string connectionString;
        public DBConnect()
        {
            connectionString = "SERVER=" + "ec2-54-226-9-216.compute-1.amazonaws.com" + ";DATABASE=" +
               "f2016_s1_user16" + ";" + "UID=" + "f2016_s1_user16" + ";" + "PASSWORD=" + "f2016_s1_user16" + ";";
        }

        public string getConnection()
        {
            return connectionString;
        }
    }
}
