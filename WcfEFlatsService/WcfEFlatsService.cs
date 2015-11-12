using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace WcfEFlatsService
{
    [ServiceBehavior (InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class WcfEFlatsService : IWcfEFlatsService
    {
        private readonly object LockObject = new object();
        private static ServerController.CtrLandlord ctrLandlordObj;
        private static ServerController.CtrStudent ctrStudentObj;
        private static ServerController.CtrLogin ctrLoginObj;

        public bool AddStudent(string email, string password, bool confirmed, bool student,
            int score, int numberOfChildren, bool pet, int numberOfCohabiters, bool disabled, DateTime dateOfCreation,
            string name, string surname, string address, string postCode, string city, string country, string phone)
        {
            ctrStudentObj = new ServerController.CtrStudent();

            lock (LockObject)
            {
                Console.WriteLine();
                Console.WriteLine("AddStudent() executed by Thread: {0}, at: {1}",
                     Thread.CurrentThread.ManagedThreadId.ToString(), DateTime.Now.ToString());

                //call add student method
                return ctrStudentObj.AddStudent(email, password, confirmed, student,
            score, numberOfChildren, pet, numberOfCohabiters, disabled, dateOfCreation,
            name, surname, address, postCode, city, country, phone);
            }
        }

        public bool AddLandlord(string email, string password, bool confirmed, DateTime dateOfCreation,
            string name, string surname, string address, string postCode, string city, string country, string phone)
        {
            ctrLandlordObj = new ServerController.CtrLandlord();

            lock (LockObject)
            {

                Console.WriteLine();
                Console.WriteLine("AddLandlord() executed by Thread: {0}, at: {1}",
                     Thread.CurrentThread.ManagedThreadId.ToString(), DateTime.Now.ToString());

                //call add student method
                return ctrLandlordObj.AddLandlord(email, password, confirmed, dateOfCreation,
                    name, surname, address, postCode, city, country, phone);
            }
        }

        public bool Login(string email, string password)
        {
             ctrLoginObj = new ServerController.CtrLogin();

            lock (LockObject)
            {

                Console.WriteLine();
                Console.WriteLine("LoginStudent() executed by Thread: {0}, at: {1}",
                     Thread.CurrentThread.ManagedThreadId.ToString(), DateTime.Now.ToString());

                return ctrLoginObj.Login(email, password);
            }
        }

        public bool AddApartment(string landlordEmail, string type, string address, string zipCode, double rentPrice, double deposit, DateTime avaiable, DateTime dateFormCreation)
        {
            ctrLandlordObj = new ServerController.CtrLandlord();

            lock (LockObject)
            {

                Console.WriteLine();
                Console.WriteLine("AddApartment() executed by Thread: {0}, at: {1}",
                     Thread.CurrentThread.ManagedThreadId.ToString(), DateTime.Now.ToString());

                //call add appartment method
                return ctrLandlordObj.AddApartment(landlordEmail, type, address, zipCode, rentPrice, deposit, avaiable, dateFormCreation);
            }
        }
    }
}
