using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Collections;
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

        [OperationContract]
        bool Login(string email, string password);

        [OperationContract]
        bool AddApartment(string landlordEmail, string type, string address, string zipCode, double rentPrice, double deposit, DateTime avaiable, DateTime dateFormCreation, string description);

        [OperationContract]
        ArrayList GetData(string email);

        [OperationContract]
        bool AddToWishlist(int studentId, int flatId);

        [OperationContract]
        bool RemoveFromWishlist(int studentId, int FlatId);

        [OperationContract]
        int CalculateProfileScore(int id);

        //[OperationContract]
        //int CalculateApplicationScore(int studentId, string studentEmail, int flatId);


    }
}
