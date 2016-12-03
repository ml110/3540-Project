using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

//http://ec2-54-226-9-216.compute-1.amazonaws.com/phpmyadmin/
//f2016_s1_user18


namespace customerSignUp
{
    public partial class Form1 : Form
    {
        DBConnect db;
        MySqlConnection con;
        MySqlCommand cmd,comm;
        MySqlDataReader sqlReader,sqlReadCountries;

        int tripidSelected = 0;
        DateTime unselectedDateBirthGus0;
        string departDateToSqlFormat, cityPassInput = null;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            db = new DBConnect();
            con = new MySqlConnection(db.getConnection());
            con.Open();//to open sql Connection
           // MessageBox.Show("Database Connected");

            ///////////////////////load data into COMBOBOX///////////////////////////////////////
            cmd = new MySqlCommand();
            cmd.CommandText = "SELECT count(TI.trip_id) as NumberOfDays, T.departure_port, P.port_name AS departure,";
            cmd.CommandText += "T.destination_port, Po.port_name AS destination FROM TRIP AS T INNER JOIN PORTS AS P ON T.departure_port = P.port_id ";
            cmd.CommandText += "INNER JOIN PORTS AS Po ON T.destination_port = Po.port_id inner join TRIP_ITINERARY as TI on TI.trip_id = T.trip_id ";
            cmd.CommandText += "group by TI.trip_id";
            cmd.Connection = con; // using the query and connect to mysql
            sqlReader = cmd.ExecuteReader();//activate SQLReader to read DEPARTMENT TABLE from MySQL

            while (sqlReader.Read()) // while READING
            {
                tripDetails.Items.Add(sqlReader["NumberOfDays"] + "-DAY PASSAGE FROM " + sqlReader["departure"] + " TO " + sqlReader["destination"]);//read what? assigned to read DepartmentName column from DEPARTMENT Table
            }
            sqlReader.Close();//always close after open SQL method.

            comm = new MySqlCommand();
            comm.CommandText = "select country_name from COUNTRY group by country_name";
            comm.Connection = con;
            sqlReadCountries = comm.ExecuteReader();

            while (sqlReadCountries.Read())
            {
                countryInput.Items.Add(sqlReadCountries["country_name"]);
            }
            sqlReadCountries.Close();


            /////////////////    create DateTimePicker    //////////////////////
            dateOfBirthGus0.Format = DateTimePickerFormat.Custom;
            dateOfBirthGus0.CustomFormat = "MMMM dd, yyyy";
            unselectedDateBirthGus0 = dateOfBirthGus0.Value;

            /////////////////    load default values = "1" onto Number Of Guest combo box   ///////////////////
            numberGuestInput.SelectedIndex = 0;

        }
        public void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /////////////////     load trip depart date and ship name details onto textboxes   //////////////////
            db = new DBConnect();
            tripidSelected = tripDetails.SelectedIndex + 1;
            string query = "select T.departure_date as DPartDate,S.ship_name as shipName from TRIP as T ";
            query += "inner join SHIP as S on S.ship_id = T.ship_id where T.trip_id =" + tripidSelected + ";";
            MySqlConnection conDataBase = new MySqlConnection(db.getConnection());
            MySqlCommand cmdDataBase = new MySqlCommand(query, conDataBase);
            MySqlDataReader myReader;
            try
            {
                conDataBase.Open();
                myReader = cmdDataBase.ExecuteReader();
                while (myReader.Read()) // while READING
                {
                    string shipName = myReader.GetString("shipName");
                    DateTime departureD = (DateTime)myReader["DPartDate"];
                    departDateToSqlFormat = departureD.ToString("yyyy-MM-dd");
                    txtBoxDepartDate.Text = departureD.ToString("MMMM dd, yyyy"); 
                    txtShipName.Text = shipName;
                }
                
                sqlReader.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            /////////////////////////////  validate inputs   /////////////////////////////

            bool wrong = false;

            if (inputValidation.checkEmail(emailInput.Text.ToString()))
            {
                labelEmail.ForeColor = Color.Black;
                labelEmail.Text = string.Empty;
            }
            else
            {
                labelEmail.ForeColor = Color.Red; 
                labelEmail.Text = "x";          
                wrong = true;
            }


            if (inputValidation.checkNames(fNameInput.Text.ToString()) && fNameInput.Text.Length > 2)
            {
                labelFName.ForeColor = Color.Black;
                labelFName.Text = string.Empty;
            }
            else
            {
                labelFName.ForeColor = Color.Red;
                labelFName.Text = "x";
                wrong = true;
            }

            if (inputValidation.checkNames(lNameInput.Text.ToString()) && lNameInput.Text.Length > 1)
            {
                labelLName.ForeColor = Color.Black;
                labelLName.Text = string.Empty;
            }
            else
            {
                labelLName.ForeColor = Color.Red;
                labelLName.Text = "x";
                wrong = true;
            }

            if (inputValidation.checkPhone(phNumbeInput.Text) && phNumbeInput.Text.Length > 3)
            {
                labelPhone.ForeColor = Color.Black;
                labelPhone.Text = string.Empty;
            }
            else
            {
                labelPhone.ForeColor = Color.Red;
                labelPhone.Text = "x";
                wrong = true;
            }

            if (inputValidation.checkCity(cityInput.Text.ToString()) && cityInput.Text.Length > 3)
            {
                labelCity.ForeColor = Color.Black;
                labelCity.Text = string.Empty;
            }
            else
            {
                labelCity.ForeColor = Color.Red;
                labelCity.Text = "x";
                wrong = true;
            }

            if (countryInput.SelectedIndex > -1)
            {
                labelCountry.ForeColor = Color.Black;
                labelCountry.Text = string.Empty;
            }
            else
            {
                labelCountry.ForeColor = Color.Red;
                labelCountry.Text = "x";
                wrong = true;
            }

            if (addressInput.Text.Length > 8)
            {
                labelAddress.ForeColor = Color.Black;
                labelAddress.Text = string.Empty;
            }
            else
            {
                labelAddress.ForeColor = Color.Red;
                labelAddress.Text = "x";
                wrong = true;
            }
         
            ////////////////   validate dateOfBirthGus0     ///////////////////////
            if (dateOfBirthGus0.Value != unselectedDateBirthGus0)
            {
                labelDateGus0.ForeColor = Color.Black;
                labelDateGus0.Text = string.Empty;
            }
            else 
            {
                labelDateGus0.ForeColor = Color.Red;
                labelDateGus0.Text = "x";
                wrong = true;
            }


            if (wrong == true)
            {
                ///////////////////    pass values to next form    //////////////////////////////

                StateRoom nextForm = new StateRoom(fNameInput.Text.Trim(), lNameInput.Text.Trim(), phNumbeInput.Text.Trim(), addressInput.Text.Trim(), countryInput.Text.Trim(), emailInput.Text.Trim(), txtShipName.Text.Trim(), numberGuestInput.Text, cityInput.Text.Trim(), dateOfBirthGus0.Value,txtBoxDepartDate.Text, departDateToSqlFormat, tripidSelected.ToString(),tripDetails.Text);
                this.Hide();
                nextForm.ShowDialog();
                this.Close();

            }
            else
            {
                MessageBox.Show("Please fill up every boxes correctly");
            }
            con.Close();
            
        }

    }
}



