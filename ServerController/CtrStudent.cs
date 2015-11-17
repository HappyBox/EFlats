using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
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

            if (!dbCheckEmailObj.checkEmailExists(mdlStudentObj.Email))                
                return dbStudentObj.AddStudent(mdlStudentObj);

            Console.WriteLine("Registration has failed due to the existing email");
            Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now.ToString());
            return false;
        }
        
        public int GetScore(int studentId)
        {
            ServerDatabase.DbStudent dbStudentObj = new ServerDatabase.DbStudent();
            return dbStudentObj.GetScore(studentId);
        }

        public int GetLastQueueNumber(int flatId)
        {
            ServerDatabase.DbStudent dbStudentObj = new ServerDatabase.DbStudent();
            ServerDatabase.DbFlat dbFlatObj = new ServerDatabase.DbFlat();
            //check if FlatId exists
            if(dbFlatObj.CheckFlatExists(flatId))
                //return biggest queue number
                return dbStudentObj.GetLastQueueNumber(flatId);
        
            Console.WriteLine("Add to wishlist() has failed due to the non existing flat");
            Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now.ToString());
            return -2;
        }

        public bool AddToWishlist(int studentId, int flatId, int score, int queueNumber)
        {
            ServerDatabase.DbStudent dbStudentObj = new ServerDatabase.DbStudent();
            //check if application exists
            if(!dbStudentObj.checkApplicationExists(studentId, flatId))
                return dbStudentObj.AddToWishlist(studentId, flatId, score, queueNumber);

            Console.WriteLine("Add to wishlist() has failed due to the existing application");
            Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now.ToString());
            return false;
        }

        public bool RemoveFromWishlist(int studentId, int flatId)
        {
            ServerDatabase.DbStudent DbStudentObj = new ServerDatabase.DbStudent();
            return DbStudentObj.RemoveFromWishlist(studentId, flatId);
        }

        public int CalculateProfileScore(int id)
        {
            ServerDatabase.DbStudent dbStudentObj = new ServerDatabase.DbStudent();
            ServerDatabase.DbCheckEmailExists dbCheckEmailObj = new ServerDatabase.DbCheckEmailExists();
            object[] queueBasedArray = new object[3];

            dbStudentObj.GetQueueBasedData(id).CopyTo(queueBasedArray);
            //update score to the table and return it ONLY if update was successfult
            return dbStudentObj.UpdateScore(id, CalculateProfileScoreResult(queueBasedArray));
            
        }

        private int CalculateProfileScoreResult(object[] queueBasedArray)
        {
            int score = 0;
            int numberOfChildren = Convert.ToInt32(queueBasedArray[0]);
            bool disabled = Convert.ToBoolean(queueBasedArray[1]);
            int numberOfCohabiters = Convert.ToInt32(queueBasedArray[2]);

            score = (numberOfChildren * 40) + (numberOfCohabiters * 80);
            if (disabled)
                score += 60;

            //insert score to the table

            return score;
        }
    }
}
