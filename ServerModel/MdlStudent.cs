using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ServerModel
{
    [DataContract]
    public class MdlStudent
    {
        //main attributes
        private int _id;
        private string _email;
        private string _password;
        private bool _confirmed;
        private bool _student;

        //queue based attributes
        private int _score;
        private int _numberOfChildren;
        private bool _pet;
        private int _numberOfCohabiters;
        private bool _disabled;
        private DateTime _dateOfCreation;

        //personal attributes
        private string _name;
        private string _surname;
        private string _address;
        private string _postCode;
        private string _city;
        private string _country;
        private string _phone;

        //empty constructor
        public MdlStudent()
        {

        }

        //login constructor
        public MdlStudent(string email, string password)
        {
            _email = email;
            _password = password;
        }

        //full constructor
        public MdlStudent(int id, string email, string password, bool confirmed, bool student,
                int score, int numberOfChildren, bool pet, int numberOfCohabiters, bool disabled, DateTime dateOfCreation,
                string name, string surname, string address, string postCode, string city, string country, string phone)
        {
            //initialize main
            _id = id;
            _email = email;
            _password = password;
            _confirmed = confirmed;
            _student = student;

            //initialize queue based
            _score = score;
            _numberOfChildren = numberOfChildren;
            _pet = pet;
            _numberOfCohabiters = numberOfCohabiters;
            _disabled = disabled;
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
        
        [DataMember (Order = 5)]
        public bool Student
        {
            get { return _student; }
            set { _student = value; }
        }

        [DataMember(Order = 6)]
        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        [DataMember(Name = "Number_of_children", Order = 7)]
        public int NumberOfChildren
        {
            get { return _numberOfChildren; }
            set { _numberOfChildren = value; }
        }

        [DataMember(Order = 8)]
        public bool Pet
        {
            get { return _pet; }
            set { _pet = value; }
        }

        [DataMember(Name = "Number_of_cohabiters", Order = 9)]
        public int NumberOfCohabiters
        {
            get { return _numberOfCohabiters; }
            set { _numberOfCohabiters = value; }
        }

        [DataMember(Order = 11)]
        public bool Disabled
        {
            get { return _disabled; }
            set { _disabled = value; }
        }

        [DataMember(Name = "Date_of_creation", Order = 12)]
        public DateTime DateOfCreation
        {
            get { return _dateOfCreation; }
            set { _dateOfCreation = value; }
        }

        [DataMember (Order = 13)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [DataMember (Order = 14)]
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        [DataMember (Order = 15)]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        [DataMember (Order = 16)]
        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }

        [DataMember (Order = 17)]
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        [DataMember (Order =18)]
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        [DataMember (Order = 19)]
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
    }
}
