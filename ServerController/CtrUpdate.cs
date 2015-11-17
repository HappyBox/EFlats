using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServerModel;

namespace ServerController
{
    //24/02/2013 dd/MM/yyyy 
    public class CtrUpdate
    {
        public static void UpdateQueue()
        {
            DateTime MyDateTime = DateTime.ParseExact("23:07", "HH:mm", null);

            Thread.Sleep(5000);
            Console.WriteLine("Update queue has started @ time: " + DateTime.Now.ToString());

            while (true)
            {
                //if (DateTime.Now >= MyDateTime && DateTime.Now <= MyDateTime.AddSeconds(10)) //from x to x + 10sec
                if(true)
                {
                    Console.WriteLine("Updating the queue...");
                    Console.WriteLine("Time: " + DateTime.Now.ToString());

                    //update score
                    UpdateScore();

                    Thread.Sleep(20000); //20
                }
                Thread.Sleep(2000); //2
            }
        }

        private static void UpdateScore()
        {
            try
            {
                ServerDatabase.DbUpdate dbUpdateObject = new ServerDatabase.DbUpdate();

                Console.WriteLine("Updating Users Appication Scores...");
                MdlApplication[] applicationArray = new MdlApplication[dbUpdateObject.GetLastRowId()];

                dbUpdateObject.UpdateScore(dbUpdateObject.GetLastRowId()).CopyTo(applicationArray, 0);

                //Console.WriteLine(Convert.ToInt32(applicationArray[0].Id), applicationArray[1].Id, applicationArray[2].Id);

                foreach(MdlApplication element in applicationArray)
                {
                    Thread t, t1, t2, t3;
                    //switch(element.Id % 4)
                    //{
                    //    case 0: {  t  = new Thread(() => CalculateInsertScore(element)); t.Start();  Console.WriteLine("Thread: " + t.ManagedThreadId.ToString());  break; }
                    //    case 1: {  t1 = new Thread(() => CalculateInsertScore(element)); t1.Start(); Console.WriteLine("Thread: " + t1.ManagedThreadId.ToString()); break; }
                    //    case 2: {  t2 = new Thread(() => CalculateInsertScore(element)); t2.Start(); Console.WriteLine("Thread: " + t2.ManagedThreadId.ToString()); break; }
                    //    case 3: {  t3 = new Thread(() => CalculateInsertScore(element)); t3.Start(); Console.WriteLine("Thread: " + t3.ManagedThreadId.ToString()); break; }
                    //}

                    Console.WriteLine(element.Id);
                    //CalculateInsertScore(element);
                    Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString());
                }                
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void CalculateInsertScore(MdlApplication element)
        {
            ServerDatabase.DbUpdate dbUpdateObject = new ServerDatabase.DbUpdate();
            Console.WriteLine("ID: " + element.Id + "SCORE: " + element.Score);
            Console.WriteLine("ID: " + element.Id + "SCORE: " + element.Score);
            Console.WriteLine("ID: " + element.Id + "SCORE: " + element.Score);
            Console.WriteLine("ID: " + element.Id + "SCORE: " + element.Score);
            Console.WriteLine("ID: " + element.Id + "SCORE: " + element.Score);
            if (!dbUpdateObject.UpdateApplicationScore(element.Id, CtrApplications.CalculateScoreDate(Convert.ToDateTime(element.DateOfCreation))))
                Console.WriteLine("Error while updating Application score. ID: " + element.Id + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + "\n Time: " + DateTime.Now);
        }
    }
}
