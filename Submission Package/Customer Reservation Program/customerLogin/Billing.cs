using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace customerSignUp
{
    public partial class Billing : Form
    {
        private string guest0firstNam="", guest0lastNam="", guest0address="", guest0city="", guest0country="", guest0email="", numberOfGuest="", tripId="", guest0phone="", shipName="", departureDate="", departureDateSql="", tripDetails="", deckName="", roomNumber="",roomType="";       
        private DateTime unselectedDateBirthGus1, unselectedDateBirthGus2, unselectedDateBirthGus3, dateOfBirthGus0, departureDateForCalculate,now = DateTime.Today;
        private passValuesToForm cs = new passValuesToForm();
        private MySqlDataReader sqlReadCity;
        private int numOfGuest,roomTypeId;

        //////////////////////////  Passing of values from previous forms   //////////////////////////////////
        public Billing(string fName, string lName, string ph, string addres, string numOfGuest, string shpName, string eml, string county, string cty, DateTime dobGuest0, string departDate, string departDateSql,DateTime departDateForCal, string tripid,string tripInfo,string deckNam,string roomNum,int roomTypId)
        {
            InitializeComponent();

            guest0firstNam = cs.passFnameValue = fName;
            guest0lastNam = cs.passLnameValue = lName;
            guest0phone = cs.passPhoneValue = ph;
            guest0address = cs.passAddressValue = addres;
            guest0country = cs.passCountryValue = county;
            guest0email = cs.passEmailValue = eml;
            shipName = cs.passShipNameValue = shpName;
            numberOfGuest = cs.passNumberOfGuestValue = numOfGuest;
            guest0city = cs.passCityValue = cty;
            dateOfBirthGus0 = cs.passDateOfBirthGus0Value = dobGuest0;
            departureDate = cs.passDepartureDateValue = departDate;
            departureDateSql = cs.passDepartureDateSqlValue = departDateSql;
            departureDateForCalculate = cs.passDepartureDateForCal = departDateForCal;
            tripId = cs.passTripIdValue = tripid;
            tripDetails = cs.passTripDetailsValue = tripInfo;
            deckName = deckNam;
            roomNumber = roomNum;
            roomTypeId = roomTypId;
        }
        private void Billing_Load(object sender, EventArgs e)
        {

            dateBirthGuest1Input.Format = DateTimePickerFormat.Custom;
            dateBirthGuest1Input.CustomFormat = "MMMM dd, yyyy";
            unselectedDateBirthGus1 = dateBirthGuest1Input.Value;

            dateBirthGuest2Input.Format = DateTimePickerFormat.Custom;
            dateBirthGuest2Input.CustomFormat = "MMMM dd, yyyy";
            unselectedDateBirthGus2 = dateBirthGuest2Input.Value;

            dateBirthGuest3Input.Format = DateTimePickerFormat.Custom;
            dateBirthGuest3Input.CustomFormat = "MMMM dd, yyyy";
            unselectedDateBirthGus3 = dateBirthGuest3Input.Value;

            numOfGuest = int.Parse(numberOfGuest);

            ////////////////   Adjust UX design accordingly to the number of guest selected on Main form   ////////////////////////////
            switch (numOfGuest)
            {
                case 0:
                    this.Size = new Size(1052, 445);
                    labelInvoice.Location = new Point(445, 0);
                    displayRes.Location = new Point(111, 87);
                    displayRes.Size = new Size(638, 247);
                    btnExit.Location = new Point(811, 217);
                    btnCalc.Location = new Point(811, 116);
                    
                    labelGuest1.Dispose();
                    horizontalGuest1.Dispose();
                    labelFnameGuest1.Dispose();
                    labelLnameGuest1.Dispose();
                    labelDateBirthGuest1.Dispose();
                    fNameGuest1Input.Dispose();
                    lNameGuest1Input.Dispose();
                    dateBirthGuest1Input.Dispose();
                    validationDateBirthGuest1.Dispose();
                    validationFnameGuest1.Dispose();
                    validationLnameGuest1.Dispose();

                    labelGuest2.Dispose();
                    horizontalGuest2.Dispose();
                    labelFnameGuest2.Dispose();
                    labelLnameGuest2.Dispose();
                    labelDateBirthGuest2.Dispose();
                    fNameGuest2Input.Dispose();
                    lNameGuest2Input.Dispose();
                    dateBirthGuest2Input.Dispose();
                    validationDateBirthGuest2.Dispose();
                    validationFnameGuest2.Dispose();
                    validationLnameGuest2.Dispose();

                    labelGuest3.Dispose();
                    horizontalGuest3.Dispose();
                    labelFnameGuest3.Dispose();
                    labelLnameGuest3.Dispose();
                    labelDateBirthGuest3.Dispose();
                    fNameGuest3Input.Dispose();
                    lNameGuest3Input.Dispose();
                    dateBirthGuest3Input.Dispose();
                    validationDateBirthGuest3.Dispose();
                    validationFnameGuest3.Dispose();
                    validationLnameGuest3.Dispose();
                    break;

                case 1:
                    this.Size = new Size(1052, 578);
                    labelInvoice.Location = new Point(445, 122);
                    displayRes.Location = new Point(111, 204);
                    displayRes.Size = new Size(638, 285);
                    btnExit.Location = new Point(811, 352);
                    btnCalc.Location = new Point(811, 251);

                    labelGuest2.Dispose();
                    horizontalGuest2.Dispose();
                    labelFnameGuest2.Dispose();
                    labelLnameGuest2.Dispose();
                    labelDateBirthGuest2.Dispose();
                    fNameGuest2Input.Dispose();
                    lNameGuest2Input.Dispose();
                    dateBirthGuest2Input.Dispose();
                    validationDateBirthGuest2.Dispose();
                    validationFnameGuest2.Dispose();
                    validationLnameGuest2.Dispose();

                    labelGuest3.Dispose();
                    horizontalGuest3.Dispose();
                    labelFnameGuest3.Dispose();
                    labelLnameGuest3.Dispose();
                    labelDateBirthGuest3.Dispose();
                    fNameGuest3Input.Dispose();
                    lNameGuest3Input.Dispose();
                    dateBirthGuest3Input.Dispose();
                    validationDateBirthGuest3.Dispose();
                    validationFnameGuest3.Dispose();
                    validationLnameGuest3.Dispose();
                    break;

                case 2:
                    this.Size = new Size(1052, 710);
                    labelInvoice.Location = new Point(445, 241);
                    displayRes.Location = new Point(111, 331);
                    displayRes.Size = new Size(638,285);
                    btnExit.Location = new Point(811, 471); 
                    btnCalc.Location = new Point(811, 370); 

                    labelGuest3.Dispose();
                    horizontalGuest3.Dispose();
                    labelFnameGuest3.Dispose();
                    labelLnameGuest3.Dispose();
                    labelDateBirthGuest3.Dispose();
                    fNameGuest3Input.Dispose();
                    lNameGuest3Input.Dispose();
                    dateBirthGuest3Input.Dispose();
                    validationDateBirthGuest3.Dispose();
                    validationFnameGuest3.Dispose();
                    validationLnameGuest3.Dispose();
                    break;

                case 3:
                    break;
            }

        }
        private void btnCalc_Click_1(object sender, EventArgs e)
        {
            bool wrong = false;

            //////////////////////   Validation of names and dob for Guest 1 to 3   ///////////////////////////////
            switch (numOfGuest)
            {
                case 0:
                    break;
                case 1:
                    if (inputValidation.checkNames(fNameGuest1Input.Text.ToString()) && fNameGuest1Input.Text.Length > 2)
                    {
                        validationFnameGuest1.ForeColor = Color.Black;
                        validationFnameGuest1.Text = string.Empty;
                    }
                    else
                    {
                        validationFnameGuest1.ForeColor = Color.Red;
                        validationFnameGuest1.Text = "x";
                        wrong = true;
                    }

                    if (inputValidation.checkNames(lNameGuest1Input.Text.ToString()) && lNameGuest1Input.Text.Length > 1)
                    {
                        validationLnameGuest1.ForeColor = Color.Black;
                        validationLnameGuest1.Text = string.Empty;
                    }
                    else
                    {
                        validationLnameGuest1.ForeColor = Color.Red;
                        validationLnameGuest1.Text = "x";
                        wrong = true;
                    }

                    if (dateBirthGuest1Input.Value != unselectedDateBirthGus1)
                    {
                        validationDateBirthGuest1.ForeColor = Color.Black;
                        validationDateBirthGuest1.Text = string.Empty;
                    }
                    else
                    {
                        validationDateBirthGuest1.ForeColor = Color.Red;
                        validationDateBirthGuest1.Text = "x";
                        wrong = true;
                    }
                    break;
                case 2:
                    ////////////////// validate guest 1   /////////////////
                    if (inputValidation.checkNames(fNameGuest1Input.Text.ToString()) && fNameGuest1Input.Text.Length > 2)
                    {
                        validationFnameGuest1.ForeColor = Color.Black;
                        validationFnameGuest1.Text = string.Empty;
                    }
                    else
                    {
                        validationFnameGuest1.ForeColor = Color.Red;
                        validationFnameGuest1.Text = "x";
                        wrong = true;
                    }

                    if (inputValidation.checkNames(lNameGuest1Input.Text.ToString()) && lNameGuest1Input.Text.Length > 1)
                    {
                        validationLnameGuest1.ForeColor = Color.Black;
                        validationLnameGuest1.Text = string.Empty;
                    }
                    else
                    {
                        validationLnameGuest1.ForeColor = Color.Red;
                        validationLnameGuest1.Text = "x";
                        wrong = true;
                    }

                    if (dateBirthGuest1Input.Value != unselectedDateBirthGus1)
                    {
                        validationDateBirthGuest1.ForeColor = Color.Black;
                        validationDateBirthGuest1.Text = string.Empty;
                    }
                    else
                    {
                        validationDateBirthGuest1.ForeColor = Color.Red;
                        validationDateBirthGuest1.Text = "x";
                        wrong = true;
                    }


                    ////////////////   guest 2     ///////////////////////
                    if (inputValidation.checkNames(fNameGuest2Input.Text.ToString()) && fNameGuest2Input.Text.Length > 2)
                    {
                        validationFnameGuest2.ForeColor = Color.Black;
                        validationFnameGuest2.Text = string.Empty;
                    }
                    else
                    {
                        validationFnameGuest2.ForeColor = Color.Red;
                        validationFnameGuest2.Text = "x";
                        wrong = true;
                    }

                    if (inputValidation.checkNames(lNameGuest2Input.Text.ToString()) && lNameGuest2Input.Text.Length > 1)
                    {
                        validationLnameGuest2.ForeColor = Color.Black;
                        validationLnameGuest2.Text = string.Empty;
                    }
                    else
                    {
                        validationLnameGuest2.ForeColor = Color.Red;
                        validationLnameGuest2.Text = "x";
                        wrong = true;
                    }

                    if (dateBirthGuest2Input.Value != unselectedDateBirthGus2)
                    {
                        validationDateBirthGuest2.ForeColor = Color.Black;
                        validationDateBirthGuest2.Text = string.Empty;
                    }
                    else
                    {
                        validationDateBirthGuest2.ForeColor = Color.Red;
                        validationDateBirthGuest2.Text = "x";
                        wrong = true;
                    }
                    break;
                case 3:
                    ////////////////// validate guest 1   /////////////////
                    if (inputValidation.checkNames(fNameGuest1Input.Text.ToString()) && fNameGuest1Input.Text.Length > 2)
                    {
                        validationFnameGuest1.ForeColor = Color.Black;
                        validationFnameGuest1.Text = string.Empty;
                    }
                    else
                    {
                        validationFnameGuest1.ForeColor = Color.Red;
                        validationFnameGuest1.Text = "x";
                        wrong = true;
                    }

                    if (inputValidation.checkNames(lNameGuest1Input.Text.ToString()) && lNameGuest1Input.Text.Length > 1)
                    {
                        validationLnameGuest1.ForeColor = Color.Black;
                        validationLnameGuest1.Text = string.Empty;
                    }
                    else
                    {
                        validationLnameGuest1.ForeColor = Color.Red;
                        validationLnameGuest1.Text = "x";
                        wrong = true;
                    }

                    if (dateBirthGuest1Input.Value != unselectedDateBirthGus1)
                    {
                        validationDateBirthGuest1.ForeColor = Color.Black;
                        validationDateBirthGuest1.Text = string.Empty;
                    }
                    else
                    {
                        validationDateBirthGuest1.ForeColor = Color.Red;
                        validationDateBirthGuest1.Text = "x";
                        wrong = true;
                    }

                    ////////////////   guest 2     ///////////////////////
                    if (inputValidation.checkNames(fNameGuest2Input.Text.ToString()) && fNameGuest2Input.Text.Length > 2)
                    {
                        validationFnameGuest2.ForeColor = Color.Black;
                        validationFnameGuest2.Text = string.Empty;
                    }
                    else
                    {
                        validationFnameGuest2.ForeColor = Color.Red;
                        validationFnameGuest2.Text = "x";
                        wrong = true;
                    }

                    if (inputValidation.checkNames(lNameGuest2Input.Text.ToString()) && lNameGuest2Input.Text.Length > 1)
                    {
                        validationLnameGuest2.ForeColor = Color.Black;
                        validationLnameGuest2.Text = string.Empty;
                    }
                    else
                    {
                        validationLnameGuest2.ForeColor = Color.Red;
                        validationLnameGuest2.Text = "x";
                        wrong = true;
                    }

                    if (dateBirthGuest2Input.Value != unselectedDateBirthGus2)
                    {
                        validationDateBirthGuest2.ForeColor = Color.Black;
                        validationDateBirthGuest2.Text = string.Empty;
                    }
                    else
                    {
                        validationDateBirthGuest2.ForeColor = Color.Red;
                        validationDateBirthGuest2.Text = "x";
                        wrong = true;
                    }
                    /////////////////////////    Guest 3   //////////////////////////////////
                    if (inputValidation.checkNames(fNameGuest3Input.Text.ToString()) && fNameGuest3Input.Text.Length > 2)
                    {
                        validationFnameGuest3.ForeColor = Color.Black;
                        validationFnameGuest3.Text = string.Empty;
                    }
                    else
                    {
                        validationFnameGuest3.ForeColor = Color.Red;
                        validationFnameGuest3.Text = "x";
                        wrong = true;
                    }

                    if (inputValidation.checkNames(lNameGuest3Input.Text.ToString()) && lNameGuest3Input.Text.Length > 1)
                    {
                        validationLnameGuest3.ForeColor = Color.Black;
                        validationLnameGuest3.Text = string.Empty;
                    }
                    else
                    {
                        validationLnameGuest3.ForeColor = Color.Red;
                        validationLnameGuest3.Text = "x";
                        wrong = true;
                    }

                    if (dateBirthGuest3Input.Value != unselectedDateBirthGus3)
                    {
                        validationDateBirthGuest3.ForeColor = Color.Black;
                        validationDateBirthGuest3.Text = string.Empty;
                    }
                    else
                    {
                        validationDateBirthGuest3.ForeColor = Color.Red;
                        validationDateBirthGuest3.Text = "x";
                        wrong = true;
                    }
                    break;
            }

            if (wrong == false)
            {

                string guest0name = null, guest1name, guest2name, guest3name, totalGuestNames = null;
                int senior = 65, numOfSenior = 0, numOfAdults = 0;
                DateTime now = DateTime.Today;
                int ageDiffGuest0, ageDiffGuest1, ageDiffGuest2, ageDiffGuest3;

                displayRes.Text = "";

                /////////////////////////   Calculate ages for all guests   //////////////////////////////
                switch (numOfGuest)
                {
                    case 0:
                        ageDiffGuest0 = now.Year - dateOfBirthGus0.Year;
                        if (ageDiffGuest0 >= senior)
                        {
                            guest0name = guest0firstNam + " " + guest0lastNam + " (Senior)";
                            numOfSenior += 1;
                        }
                        else
                        {
                            guest0name = guest0firstNam + " " + guest0lastNam + " (Adult)";
                            numOfAdults += 1;
                        }

                        break;
                    case 1:
                        ageDiffGuest0 = now.Year - dateOfBirthGus0.Year;
                        if (ageDiffGuest0 >= senior)
                        {
                            guest0name = guest0firstNam + " " + guest0lastNam + " (Senior)";
                            numOfSenior += 1;
                        }
                        else
                        {
                            guest0name = guest0firstNam + " " + guest0lastNam + " (Adult)";
                            numOfAdults += 1;
                        }
                        ageDiffGuest1 = now.Year - dateBirthGuest1Input.Value.Year;
                        if (ageDiffGuest1 >= senior)
                        {
                            guest1name = fNameGuest1Input.Text + " " + lNameGuest1Input.Text + " (Senior)";
                            totalGuestNames += "Guest 1:     " + guest1name + "\n";
                            numOfSenior += 1;
                        }
                        else
                        {
                            guest1name = fNameGuest1Input.Text + " " + lNameGuest1Input.Text + " (Adult)";
                            totalGuestNames += "Guest 1:     " + guest1name + "\n";
                            numOfAdults += 1;
                        }
                        break;
                    case 2:
                        ageDiffGuest0 = now.Year - dateOfBirthGus0.Year;
                        if (ageDiffGuest0 >= senior)
                        {
                            guest0name = guest0firstNam + " " + guest0lastNam + " (Senior)";
                            numOfSenior += 1;
                        }
                        else
                        {
                            guest0name = guest0firstNam + " " + guest0lastNam + " (Adult)";
                            numOfAdults += 1;
                        }
                        ageDiffGuest1 = now.Year - dateBirthGuest1Input.Value.Year;
                        if (ageDiffGuest1 >= senior)
                        {
                            guest1name = fNameGuest1Input.Text + " " + lNameGuest1Input.Text + " (Senior)";
                            totalGuestNames += "Guest 1:     " + guest1name + "\n";
                            numOfSenior += 1;
                        }
                        else
                        {
                            guest1name = fNameGuest1Input.Text + " " + lNameGuest1Input.Text + " (Adult)";
                            totalGuestNames += "Guest 1:     " + guest1name + "\n";
                            numOfAdults += 1;
                        }


                        ageDiffGuest2 = now.Year - dateBirthGuest2Input.Value.Year;
                        if (ageDiffGuest2 >= senior)
                        {
                            guest2name = fNameGuest2Input.Text + " " + lNameGuest2Input.Text + " (Senior)";
                            totalGuestNames += "Guest 2:     " + guest2name + "\n";
                            numOfSenior += 1;
                        }
                        else
                        {
                            guest2name = fNameGuest2Input.Text + " " + lNameGuest2Input.Text + " (Adult)";
                            totalGuestNames += "Guest 2:     " + guest2name + "\n";
                            numOfAdults += 1;
                        }
                        break;
                    case 3:
                        ageDiffGuest0 = now.Year - dateOfBirthGus0.Year;
                        if (ageDiffGuest0 >= senior)
                        {
                            guest0name = guest0firstNam + " " + guest0lastNam + " (Senior)";
                            numOfSenior += 1;
                        }
                        else
                        {
                            guest0name = guest0firstNam + " " + guest0lastNam + " (Adult)";
                            numOfAdults += 1;
                        }
                        ageDiffGuest1 = now.Year - dateBirthGuest1Input.Value.Year;
                        if (ageDiffGuest1 >= senior)
                        {
                            guest1name = fNameGuest1Input.Text + " " + lNameGuest1Input.Text + " (Senior)";
                            totalGuestNames += "Guest 1:     " + guest1name + "\n";
                            numOfSenior += 1;
                        }
                        else
                        {
                            guest1name = fNameGuest1Input.Text + " " + lNameGuest1Input.Text + " (Adult)";
                            totalGuestNames += "Guest 1:     " + guest1name + "\n";
                            numOfAdults += 1;
                        }


                        ageDiffGuest2 = now.Year - dateBirthGuest2Input.Value.Year;
                        if (ageDiffGuest2 >= senior)
                        {
                            guest2name = fNameGuest2Input.Text + " " + lNameGuest2Input.Text + " (Senior)";
                            totalGuestNames += "Guest 2:     " + guest2name + "\n";
                            numOfSenior += 1;
                        }
                        else
                        {
                            guest2name = fNameGuest2Input.Text + " " + lNameGuest2Input.Text + " (Adult)";
                            totalGuestNames += "Guest 2:     " + guest2name + "\n";
                            numOfAdults += 1;
                        }

                        ageDiffGuest3 = now.Year - dateBirthGuest3Input.Value.Year;
                        if (ageDiffGuest3 >= senior)
                        {
                            guest3name = fNameGuest3Input.Text + " " + lNameGuest3Input.Text + " (Senior)";
                            totalGuestNames += "Guest 3:     " + guest3name + "\n";
                            numOfSenior += 1;
                        }
                        else
                        {
                            guest3name = fNameGuest3Input.Text + " " + lNameGuest3Input.Text + " (Adult)";
                            totalGuestNames += "Guest 3:     " + guest3name + "\n";
                            numOfAdults += 1;
                        }
                        break;
                }

                ////////////////////////////////   room prices   //////////////////////////////////
                string totalTypeOfPass = "", displayPerPrice = "", displayTotal = "", displayPerAdultCost = "", displayPerSeniorCost = "";
                double seniorPrice = 0.00, totalCost = 0.00;
                double roomPrice = 0.00, seniorRate = 0.80, closerToDepartRate = 0.60;

                DBConnect cb = new DBConnect();
                string query = "select * from ROOM_CATEGORY where roomCat_id =" + roomTypeId+";";
                MySqlConnection conDataBase = new MySqlConnection(cb.getConnection());
                MySqlCommand cmdDataBase = new MySqlCommand(query, conDataBase);
                MySqlDataReader myReader;

                try
                {
                    conDataBase.Open();
                    myReader = cmdDataBase.ExecuteReader();
                    while (myReader.Read()) // while READING
                    {
                        roomPrice = double.Parse(myReader["roomCat_price"].ToString());
                        roomType = myReader["roomCat_name"].ToString().Trim();
                    }

                    myReader.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                conDataBase.Close();

                /////////////// Total price calculation   //////////////////
                seniorPrice = roomPrice*seniorRate;
                double adultSpecialPrice = roomPrice * closerToDepartRate, seniorSpecialPrice = seniorPrice * closerToDepartRate;
                displayPerAdultCost = String.Format("{0:0.00}", roomPrice);
                displayPerSeniorCost = String.Format("{0:0.00}", seniorPrice);
                string specialDepartPriceDesp = "close to departure special\n", seniorPriceDesp = "Senior price";
                if (numOfAdults > 0)
                {
                    totalTypeOfPass += numOfAdults + " Adult ";
                    if((departureDateForCalculate - now).TotalDays > 20)                      
                    { 
                    displayPerPrice += "1 x Adult is $" + displayPerAdultCost;
                    totalCost += numOfAdults*roomPrice;
                    }
                    else
                    {
                        displayPerAdultCost = String.Format("{0:0.00}", adultSpecialPrice);                        
                        displayPerPrice += "1 x Adult is $" + displayPerAdultCost +" (40% off) " + specialDepartPriceDesp;
                        totalCost += numOfAdults*(roomPrice*closerToDepartRate);
                    }
                }
                if (numOfSenior > 0)
                {
                    totalTypeOfPass += numOfSenior + " Senior ";
                    if ((departureDateForCalculate - now).TotalDays > 20)//special depart price will allow if less than 20days
                    {
                        displayPerPrice += " 1 x Senior is $" + displayPerSeniorCost + " (20% off) " + seniorPriceDesp;
                        totalCost += numOfSenior * seniorPrice;
                    }
                    else
                    {
                        displayPerSeniorCost = String.Format("{0:0.00}", seniorSpecialPrice);
                        displayPerPrice += "1 x Senior is $" + displayPerSeniorCost + " (60% off) " + specialDepartPriceDesp;
                        totalCost += numOfSenior * (seniorPrice * closerToDepartRate);
                    }
                }

                displayTotal = String.Format("{0:0.00}", totalCost);

                //////////////////////////////// Print receipt   ////////////////////////////////////////
                displayRes.Text = "Name:        " + guest0name + "\n" + "Itinerary:   " + tripDetails + "\n" + "Ship:        ";
                displayRes.Text += shipName + "\n" + "Depart:      " + departureDate + "\n" + "Cabin:       " + roomNumber+" ("+roomType +") " + "\n";
                displayRes.Text += "Deck Level:  " + deckName + "\n\n" + "Passenger:   " + totalTypeOfPass.Trim() + "\n";
                displayRes.Text += totalGuestNames + "\n" + displayPerPrice.Trim() + "\n" + "Overall cost(tax included): $" + displayTotal;


                //////////////// If user inputted city is found in db, do not insert. And otherwise..   ////////////////////////
                DBConnect db = new DBConnect();
                
                MySqlConnection con = new MySqlConnection(db.getConnection());
                string citySelected = null;
                con.Open();//to open sql Connection
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "select city_name from CITY inner join COUNTRY on CITY.country_id = COUNTRY.country_id ";
                comm.CommandText += "where COUNTRY.country_name = @countryName and CITY.city_name = @cityName ";
                comm.Parameters.AddWithValue("@countryName", guest0country);
                comm.Parameters.AddWithValue("@cityName", guest0city);

                comm.Connection = con;
                sqlReadCity = comm.ExecuteReader();

                while (sqlReadCity.Read())
                {
                    citySelected = (sqlReadCity["city_name"]).ToString();
                }
                sqlReadCity.Close();
                con.Close();
                                
                DBConnect d = new DBConnect();
                int incrementPhoneId = getLastPK("PHONE", "phone_id")+1;
                using (MySqlConnection conn = new MySqlConnection(d.getConnection()))
                {
                    using (MySqlCommand command = new MySqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandType = CommandType.Text;
                        command.CommandText = "";
                        insertphone(conn, command, incrementPhoneId, guest0phone);
                        command.CommandText = "";

                        string cityNameSelected = "";
                        int incrementCityId = getLastPK("CITY", "city_id") + 1;
                        if (citySelected == null)
                        {
                            insertCity(conn, command, incrementCityId, guest0country, guest0city);
                            command.CommandText = "";
                            cityNameSelected = guest0city;

                        }
                        else
                        {
                            cityNameSelected = citySelected;
                        }


                        //////////////////////// Insert Guests info into database   ///////////////////////////////
                        int getLastPhoneId = getLastPK("PHONE", "phone_id");
                        int getLastAddId = getLastPK("ADDRESS", "address_id")+1; 
                        int incrementAddressId = getLastPK("ADDRESS", "address_id")+1;
                        int incrementPassengerId = getLastPK("PASSENGER", "pass_id") + 1;

                        string dateToSqlGuest0 = dateOfBirthGus0.ToString("yyyy-MM-dd").Trim();
                       
                        DateTime dobGuest1 = dateBirthGuest1Input.Value;
                        string dateToSqlGuest1 = dobGuest1.ToString("yyyy-MM-dd").Trim();

                        DateTime dobGuest2 = dateBirthGuest2Input.Value;
                        string dateToSqlGuest2 = dobGuest2.ToString("yyyy-MM-dd").Trim();

                        DateTime dobGuest3 = dateBirthGuest3Input.Value;
                        string dateToSqlGuest3 = dobGuest3.ToString("yyyy-MM-dd").Trim();


                        switch (numOfGuest)
                        {
                            case 0://guest0 info
                                insertAddress(conn, command, incrementAddressId, guest0address, cityNameSelected);
                                command.CommandText = "";
                                insertPassenger(conn, command, incrementPassengerId, guest0firstNam, guest0lastNam, getLastPhoneId, getLastAddId, guest0email, dateToSqlGuest0);
                                command.CommandText = "";
                                break;

                            case 1:
                                insertAddress(conn, command, incrementAddressId, guest0address, cityNameSelected);
                                command.CommandText = "";
                                insertPassenger(conn, command, incrementPassengerId, guest0firstNam, guest0lastNam, getLastPhoneId, getLastAddId, guest0email, dateToSqlGuest0);
                                command.CommandText = "";

                                insertPassenger(conn, command, incrementPassengerId, fNameGuest1Input.Text, lNameGuest1Input.Text, getLastPhoneId, getLastAddId, guest0email, dateToSqlGuest1);
                                command.CommandText = "";
                                break;

                            case 2:
                                insertAddress(conn, command, incrementAddressId, guest0address, cityNameSelected);
                                command.CommandText = "";
                                insertPassenger(conn, command, incrementPassengerId, guest0firstNam, guest0lastNam, getLastPhoneId, getLastAddId, guest0email, dateToSqlGuest0);

                                insertPassenger(conn, command, incrementPassengerId, fNameGuest1Input.Text, lNameGuest1Input.Text, getLastPhoneId, getLastAddId, guest0email, dateToSqlGuest1);
                                command.CommandText = "";
                                insertPassenger(conn, command, incrementPassengerId, fNameGuest2Input.Text, lNameGuest2Input.Text, getLastPhoneId, getLastAddId, guest0email, dateToSqlGuest2);
                                command.CommandText = "";
                                break;

                            case 3:
                                insertAddress(conn, command, incrementAddressId, guest0address, cityNameSelected);
                                command.CommandText = "";
                                insertPassenger(conn, command, incrementPassengerId, guest0firstNam, guest0lastNam, getLastPhoneId, getLastAddId, guest0email, dateToSqlGuest0);
                                command.CommandText = "";

                                insertPassenger(conn, command, incrementPassengerId, fNameGuest1Input.Text, lNameGuest1Input.Text, getLastPhoneId, getLastAddId, guest0email, dateToSqlGuest1);
                                command.CommandText = "";
                                insertPassenger(conn, command, incrementPassengerId, fNameGuest2Input.Text, lNameGuest2Input.Text, getLastPhoneId, getLastAddId, guest0email, dateToSqlGuest2);
                                command.CommandText = "";
                                insertPassenger(conn, command, incrementPassengerId, fNameGuest3Input.Text, lNameGuest3Input.Text, getLastPhoneId, getLastAddId, guest0email, dateToSqlGuest3);
                                command.CommandText = "";
                                break;
                        }
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please fill up every boxes correctly");
            }
            
        }
        
        //////////////////////////////////// Methods   /////////////////////////////////////
        private void insertphone(MySqlConnection connection, MySqlCommand command, int lastPhonePk,string guestphone)
        {
            MySqlConnection connectionA = connection;
            MySqlCommand commandA = command;
            commandA.CommandText = "INSERT INTO PHONE(phone_id,phone_number) ";
            commandA.CommandText += "VALUES(@phoneId,@phone);";
            commandA.Parameters.AddWithValue("@phone", guestphone);
            commandA.Parameters.AddWithValue("@phoneId", lastPhonePk);

            connectionA.Open();
            commandA.ExecuteReader();
            connectionA.Close();
        }

        private void insertCity(MySqlConnection connection, MySqlCommand command,int incrementCityId, string guestcountry,string guestcity)
        {
            MySqlConnection connectionB = connection;
            MySqlCommand commandB = command;
            commandB.CommandText = " INSERT INTO CITY(city_id, city_name, country_id) ";
            commandB.CommandText += "SELECT  @cityId, @cityNam, COUNTRY.country_id ";
            commandB.CommandText += "FROM COUNTRY WHERE COUNTRY.country_name = @countryNam;";

            commandB.Parameters.AddWithValue("@cityId", incrementCityId);
            commandB.Parameters.AddWithValue("@countryNam", guestcountry);
            commandB.Parameters.AddWithValue("@cityNam", guestcity);

            connectionB.Open();
            commandB.ExecuteReader();
            connectionB.Close();
        }


        private void insertAddress(MySqlConnection connection, MySqlCommand command, int incrementAddressId, string add, string city)
        {
            MySqlConnection connectionD = connection;
            MySqlCommand commandD = command;
            commandD.CommandText = "INSERT INTO ADDRESS(address_id, address_street_number, city_id) ";
            commandD.CommandText += "SELECT @addressId, @address, CITY.city_id ";
            commandD.CommandText += "FROM CITY WHERE CITY.city_name = @city_name;";

            commandD.Parameters.AddWithValue("@addressId", incrementAddressId);
            commandD.Parameters.AddWithValue("@address", add);
            commandD.Parameters.AddWithValue("@city_name", city);

            connectionD.Open();
            commandD.ExecuteReader();
            connectionD.Close();
        }

        private void insertPassenger(MySqlConnection connection, MySqlCommand command, int incrementPassengerId, string guestfirstNam, string guestlastNam, int getLastPhoneId, int getLastAddId, string guestemail, string dateToSqlGuest)
        {
            MySqlConnection connectionC = connection;
            MySqlCommand commandC = command;
            commandC.CommandText = "INSERT INTO PASSENGER(pass_id, pass_firstname, pass_lastname, pass_phone, pass_email, pass_address, pass_dob) ";
            commandC.CommandText += "values ('" +incrementPassengerId + "','" + guestfirstNam+"','"+ guestlastNam+"', '" + getLastPhoneId + "','"+ guestemail+"','" + getLastAddId + "','"+ dateToSqlGuest + "') ";

            connectionC.Open();
            commandC.ExecuteReader();
            connectionC.Close();
        }

        public int getLastPK(string tableName, string fieldName)
            {
                MySqlConnection connection;
                MySqlCommand command = new MySqlCommand();
                string server = "ec2-54-226-9-216.compute-1.amazonaws.com";
                string db = "f2016_s1_user16";
                string id = "f2016_s1_user16";
                string pass = "f2016_s1_user16";
                string port = "3306";

                string connectionString = "SERVER=" + server + ";PORT=" + port + ";DATABASE=" + db + ";UID=" + id + ";PASSWORD=" + pass + ";";
                connection = new MySqlConnection(connectionString);

                connection.Open();

                int lastPK = 0;
                command.CommandText = "SELECT " + fieldName + " FROM " + tableName + " ORDER BY " + fieldName + " DESC LIMIT 1;";
                command.Connection = connection;
                MySqlDataReader sRead = command.ExecuteReader();
                while (sRead.Read())
                {
                    lastPK = Int16.Parse(sRead[0].ToString());
                }
                sRead.Close();

                return lastPK;
            }
        private void btnExit_Click(object sender, EventArgs e)
        {
            Form1 nextForm = new Form1();
            this.Hide();
            nextForm.ShowDialog();
            this.Close();
        }
    }
}
