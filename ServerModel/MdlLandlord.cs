using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ServerModel
{
    [DataContract]
    public class MdlLandlord
    {
        //main attributes
        private int _id;
        private string _email;
        private string _password;
        private bool _confirmed;

        //queue based attributes
        private DateTime _dateOfCreation;

        //personal attributes
        private string _name;
        private string _surname;
        private string _address;
        private string _postCode;
        private string _city;
        private string _country;
        private string _phone;

        //full constructor
        public MdlLandlord(int id, string email, string password, bool confirmed, DateTime dateOfCreation,
                string name, string surname, string address, string postCode, string city, string country, string phone)
        {
            //initialize main
            _id = id;
            _email = email;
            _password = password;
            _confirmed = confirmed;

            //initialize queue based
            _dateOfCreation = dateOfCreation;

            //initialize personal
            _name = name;
            _surname = surname;
            _address = address;
            _postCode = postCode;
            _city = city;
            _country = country;
            _phone = phone;
        }

        [DataMember(Name = "ID", Order = 1)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember(Name = "Email", Order = 2)]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [DataMember(Order = 3)]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        [DataMember(Order = 4)]
        public bool Confirmed
        {
            get { return _confirmed; }
            set { _confirmed = value; }
        }
        
        [DataMember(Name = "Date_of_creation", Order = 5)]
        public DateTime DateOfCreation
        {
            get { return _dateOfCreation; }
            set { _dateOfCreation = value; }
        }

        [DataMember(Order = 6)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember(Order = 7)]
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        [DataMember(Order = 8)]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        [DataMember(Order = 9)]
        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }

        [DataMember(Order = 10)]
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        [DataMember(Order = 11)]
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        [DataMember(Order = 12)]
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
    }
}
