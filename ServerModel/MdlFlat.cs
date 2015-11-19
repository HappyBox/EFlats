using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ServerModel
{
    [DataContract]
    public class MdlFlat
    {
        //main attributes
        private int _id;
        private string _landlordEmail;
        private string _type;
        private DateTime _dateFormCreation;
        private DateTime _avaiable;
        private string _address;
        private double _rentPrice;
        private double _deposit;
        private string _postCode;
        private string _description;

        //full constructor
        public MdlFlat(string landlordEmail, string type, DateTime dateFormCreation, DateTime avaiable, double rentPrice, double deposit, string address, string postCode, string description)
        {
            //_email = email;
            _landlordEmail = landlordEmail;
            _type = type;
            _dateFormCreation = dateFormCreation;
            _avaiable = avaiable;
            _rentPrice = rentPrice;
            _address = address;
            _postCode = postCode;
            _deposit = deposit;
            _description = description;
        }

        public MdlFlat()
        {

        }

        [DataMember(Name = "ID", Order = 1)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [DataMember(Name = "Landlord_Email", Order = 2)]
        public string LandlordEmail
        {
            get { return _landlordEmail; }
            set { _landlordEmail = value; }
        }

        [DataMember(Order = 4)]
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        [DataMember(Name = "Date_Form_Creation", Order = 5)]
        public DateTime DateOfCreation
        {
            get { return _dateFormCreation; }
            set { _dateFormCreation = value; }
        }

        [DataMember(Name = "Avaiable", Order = 6)]
        public DateTime Avaiable
        {
            get { return _avaiable; }
            set { _avaiable = value; }
        }

        [DataMember(Order = 7)]
        public double RentPrice
        {
            get { return _rentPrice; }
            set { _rentPrice = value; }
        }

        [DataMember(Order = 8)]
        public double Deposit
        {
            get { return _deposit; }
            set { _deposit = value; }
        }

        [DataMember(Order = 9)]
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        [DataMember(Order = 10)]
        public string PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }

        [DataMember(Order = 11)]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
