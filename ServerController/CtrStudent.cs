using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using ServerModel;
using ServerDatabase;

namespace ServerController
{
    public class CtrStudent
    {
        public bool AddStudent(string email, string password, bool confirmed, bool student,
            int score, int numberOfChildren, bool pet, int numberOfCohabiters, bool disabled, DateTime dateOfCreation,
            string name, string surname, string address, string postCode, string city, string country, string phone)
        {
            ServerModel.MdlStudent mdlStudentObj = new ServerModel.MdlStudent(0, email, password, confirmed, student,
                score, numberOfChildren, pet, numberOfCohabiters, disabled, dateOfCreation, name, surname, address, postCode, city, country, phone);

            ServerDatabase.DbStudent dbStudentObj = new ServerDatabase.DbStudent();
            ServerDatabase.DbCheckEmailExists dbCheckEmailObj = new ServerDatabase.DbCheckEmailExists();

            if (dbCheckEmailObj.checkEmailExists(mdlStudentObj.Email))                
                return dbStudentObj.AddStudent(mdlStudentObj);

            Console.WriteLine("Registration has failed due to the existing email");
            Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + "Time: " + DateTime.Now.ToString());
            return false;
        }
    }
}
