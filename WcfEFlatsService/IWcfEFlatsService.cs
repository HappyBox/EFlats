using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfEFlatsService
{
    [ServiceContract]
    public interface IWcfEFlatsService
    {
        [OperationContract]
        bool AddStudent(string email, string password, bool confirmed, bool student,
            int score, int numberOfChildren, bool pet, int numberOfCohabiters, bool disabled, DateTime dateOfCreation,
            string name, string surname, string address, string postCode, string city, string country, string phone);

        [OperationContract]
        bool AddLandlord(string email, string password, bool confirmed, DateTime dateOfCreation,
            string name, string surname, string address, string postCode, string city, string country, string phone);
    }
}
