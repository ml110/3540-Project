using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customerSignUp
{
    class passValuesToForm
    {
        private string fName, lName, address, city, country, email, numberOfGuest, tripId, phone, shipName, departureDate, departureDateSql, tripDetails;
        private DateTime dateOfBirthGus0, departureDateForCal;

        public string passFnameValue
        {
            get { return fName; }
            set { fName = value; }
        }
        public string passLnameValue
        {
            get { return lName; }
            set { lName = value; }
        }

        public string passAddressValue
        {
            get { return address; }
            set { address = value; }
        }

        public string passNumberOfGuestValue
        {
            get { return numberOfGuest; }
            set { numberOfGuest = value; }
        }

        public string passShipNameValue
        {
            get { return shipName; }
            set { shipName = value; }
        }

        public string passEmailValue
        {
            get { return email; }
            set { email = value; }
        }
        public string passPhoneValue
        {
            get { return phone; }
            set { phone = value; }
        }
        public string passCountryValue
        {
            get { return country; }
            set { country = value; }
        }
        public string passCityValue
        {
            get { return city; }
            set { city = value; }
        }
        public string passDepartureDateValue
        {
            get { return departureDate; }
            set { departureDate = value; }
        }
        public string passDepartureDateSqlValue
        {
            get { return departureDateSql; }
            set { departureDateSql = value; }
        }
        public DateTime passDepartureDateForCal
        {
            get { return departureDateForCal; }
            set { departureDateForCal = value; }
        }

        public DateTime passDateOfBirthGus0Value
        {
            get { return dateOfBirthGus0; }
            set { dateOfBirthGus0 = value; }
        }
        public string passTripIdValue
        {
            get { return tripId; }
            set { tripId = value; }
        }
        public string passTripDetailsValue
        {
            get { return tripDetails; }
            set { tripDetails = value; }
        }

    }
}
