using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Collections;

namespace WcfEFlatsService
{
    [ServiceBehavior (InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class WcfEFlatsService : IWcfEFlatsService
    {
        private readonly object LockObject = new object();
        private static ServerController.CtrLandlord ctrLandlordObj;
        private static ServerController.CtrStudent ctrStudentObj;
        private static ServerController.CtrLogin ctrLoginObj;
        private static ServerController.CtrGetData ctrGetDataObj;
        private static ServerController.CtrApplications ctrApplicationsObj;

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
                Console.WriteLine("Login() executed by Thread: {0}, at: {1}",
                     Thread.CurrentThread.ManagedThreadId.ToString(), DateTime.Now.ToString());

                return ctrLoginObj.Login(email, password);
            }
        }

        public bool AddApartment(string landlordEmail, string type, string address, string zipCode, double rentPrice, double deposit, DateTime avaiable, DateTime dateFormCreation, string description)
        {
            ctrLandlordObj = new ServerController.CtrLandlord();

            lock (LockObject)
            {

                Console.WriteLine();
                Console.WriteLine("AddApartment() executed by Thread: {0}, at: {1}",
                     Thread.CurrentThread.ManagedThreadId.ToString(), DateTime.Now.ToString());

                //call add appartment method
                return ctrLandlordObj.AddApartment(landlordEmail, type, address, zipCode, rentPrice, deposit, avaiable, dateFormCreation, description);
            }
        }

        public ArrayList GetData(string email)
        {
            ctrGetDataObj = new ServerController.CtrGetData();

            Console.WriteLine();
            Console.WriteLine("GetData() executed by Thread: {0}, at: {1}",
                 Thread.CurrentThread.ManagedThreadId.ToString(), DateTime.Now.ToString());

            return ctrGetDataObj.GetUserData(email);
        }

        public bool AddToWishlist(int studentId, int flatId)
        {
            ctrStudentObj = new ServerController.CtrStudent();
            int queueNumber = -2;

            Console.WriteLine();
            Console.WriteLine("AddToWishlist() executed by Thread: {0}, at: {1}",
                Thread.CurrentThread.ManagedThreadId.ToString(), DateTime.Now.ToString());           

            //critical section (read + write)
            lock (LockObject)
            {
                queueNumber = ctrStudentObj.GetLastQueueNumber(flatId);
                Console.WriteLine("GetLastQueue() executed by Thread: {0}, at: {1}",
                    Thread.CurrentThread.ManagedThreadId.ToString(), DateTime.Now.ToString());

                if (queueNumber > -2)
                    return ctrStudentObj.AddToWishlist(studentId, flatId, 0, queueNumber + 1);

                Console.WriteLine("FAILED");
                return false;
            }
        }

        public bool RemoveFromWishlist(int studentId, int flatId)
        {
            ctrStudentObj = new ServerController.CtrStudent();
            Console.WriteLine();
            Console.WriteLine("RemoveFromWishlist() executed by Thread: {0}, at: {1}",
                Thread.CurrentThread.ManagedThreadId.ToString(), DateTime.Now.ToString());

            return ctrStudentObj.RemoveFromWishlist(studentId, flatId);
        }

        public int CalculateProfileScore(int studentId)
        {
            ctrStudentObj = new ServerController.CtrStudent();
            Console.WriteLine();
            Console.WriteLine("CalculateProfileScore() executed by Thread: {0}, at: {1}",
                Thread.CurrentThread.ManagedThreadId.ToString(), DateTime.Now.ToString());
            return ctrStudentObj.CalculateProfileScore(studentId);
        } 

       /* public int CalculateApplicationScore(int studentId, int flatId)
        {
            ctrStudentObj = new ServerController.CtrStudent();
            ctrApplicationsObj = new ServerController.CtrApplications();
            int scoreProfile = -1;
            int scoreDate = -1;

            Console.WriteLine();
            Console.WriteLine("CalculateProfileScore() executed by Thread: {0}, at: {1}",
                Thread.CurrentThread.ManagedThreadId.ToString(), DateTime.Now.ToString());
            //using threads to speed things up
            Thread scoreThread = new Thread(() => { scoreProfile = ctrStudentObj.GetScore(studentId); });
            Thread numberOfDaysThread = new Thread(() => { scoreDate = ctrApplicationsObj.CalculateScoreDate(studentId, flatId); });

            numberOfDaysThread.Start();
            Console.WriteLine("CalculateScoreDate() executed by Thread: {0}, at: {1}",
                numberOfDaysThread.ManagedThreadId.ToString(), DateTime.Now.ToString());

            scoreThread.Start();
            Console.WriteLine("GetScore() executed by Thread: {0}, at: {1}",
                scoreThread.ManagedThreadId.ToString(), DateTime.Now.ToString());

            numberOfDaysThread.Join();
            scoreThread.Join();

            return scoreProfile + scoreDate;
        }*/
    }
}
