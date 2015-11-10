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
        private int _landlordId;
        private int _type;
        private string _email;
        private DateTime _dateFormCreation;
        private DateTime _avaiable;
        private string _address;
        private int _rentPrice;
        private int _deposit;
        private int _postCode;

        //full constructor
        public MdlFlat(int landlordId, int type, DateTime dateFormCreation, DateTime avaiable, int rentPrice, int deposit, string address, int postCode)
        {
            //_email = email;
            _landlordId = landlordId;
            _type = type;
            _dateFormCreation = dateFormCreation;
            _avaiable = avaiable;
            _rentPrice = rentPrice;
            _address = address;
            _postCode = postCode;
            _deposit = deposit;
        }

        [DataMember(Name = "ID", Order = 1)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        [DataMember(Name = "LandlordID", Order = 2)]
        public int LandlordId
        {
            get { return _id; }
            set { _id = value; }
        }
        [DataMember(Name = "Email", Order = 3)]
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [DataMember(Order = 4)]
        public int Type
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
        public int RentPrice
        {
            get { return _rentPrice; }
            set { _rentPrice = value; }
        }

        [DataMember(Order = 8)]
        public int Deposit
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
        public int PostCode
        {
            get { return _postCode; }
            set { _postCode = value; }
        }
    }
}
