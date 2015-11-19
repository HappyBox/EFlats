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
        public static void Update()
        {
            DateTime MyDateTime = DateTime.ParseExact("21:08", "HH:mm", null);

            Thread.Sleep(5000);
            Console.WriteLine("Update queue has started @ time: " + DateTime.Now.ToString());

            while (true)
            {
                if (DateTime.Now >= MyDateTime && DateTime.Now <= MyDateTime.AddSeconds(10)) //from x to x + 10sec
                //if(true)
                {
                    Console.WriteLine("Updating the queue...");
                    Console.WriteLine("START Time: " + DateTime.Now.ToString());

                    //update score
                    UpdateScoreQueue();

                    Console.WriteLine("TOTAL FINISH Time: " + DateTime.Now.ToString());
                    Thread.Sleep(20000); //20
                }
                Thread.Sleep(2000); //2
            }
        }

        private static void UpdateScoreQueue()
        {
            try
            {
                ServerDatabase.DbUpdate dbUpdateObject = new ServerDatabase.DbUpdate();
                List<MdlApplication> applicationList = dbUpdateObject.UpdateScore();

                //score will be updated
                applicationList = UpdateScore(applicationList);
                UpdateQueue(applicationList);

            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void UpdateQueue(List<MdlApplication> applicationList)
        {
            Console.WriteLine("Started Updating Users Appication Queues... @ " + DateTime.Now);
            applicationList.Sort();

            int lastId = applicationList.First().FlatId;
            List<MdlApplication> SingleFlatList = new List<MdlApplication>();

            foreach(MdlApplication element in applicationList)
            {
                //equal to previous flat
                if(lastId == element.FlatId)
                {
                    SingleFlatList.Add(element);
                    Console.WriteLine("single flat element added " + element.Id);
                    //if last value in list execute update function
                    if(applicationList[applicationList.Count -1] == element)
                    {
                        Console.WriteLine("updating queue sf...");
                        UpdateQueueOneFlat(SingleFlatList);
                        SingleFlatList.RemoveAll(FlatIdPredicate);
                    }

                }
                else
                {
                    Console.WriteLine("updating queue sf...");
                    UpdateQueueOneFlat(SingleFlatList);
                    SingleFlatList.RemoveAll(FlatIdPredicate);

                    SingleFlatList.Add(element);
                    Console.WriteLine("single flat element added " + element.Id);
                    lastId++;
                }
            }
            Console.WriteLine("Started Updating Users Appication Queues... @ " + DateTime.Now);
        }

        private static bool FlatIdPredicate(MdlApplication element)
        {
            return true;
        }

        private static void UpdateQueueOneFlat(List<MdlApplication> singleFlatList)
        {
            ServerDatabase.DbUpdate dbUpdateObj = new ServerDatabase.DbUpdate();
            SortByScore sortObj = new SortByScore();
            int queue = 1;
            //sort by score
            singleFlatList.Sort(sortObj);

            foreach(MdlApplication element in singleFlatList)
            {
                element.QueueNumber = queue;
                dbUpdateObj.UpdateQueue(element.Id, element.QueueNumber);
                queue++;
            }
        }

        private static List<MdlApplication> UpdateScore(List<MdlApplication> applicationList)
        {
            Console.WriteLine("Started Updating Users Appication Scores @ " + DateTime.Now);
            Parallel.ForEach(applicationList, element =>
            {
                CalculateInsertScore(element);
            });
            Console.WriteLine("Finished Updating Users Appication Scores @ " + DateTime.Now);
            return applicationList;
        }

        private static MdlApplication CalculateInsertScore(MdlApplication element)
        {
            ServerDatabase.DbUpdate dbUpdateObject = new ServerDatabase.DbUpdate();
            //return bool, pass calculated score and ID
            int dateScore = CtrApplications.CalculateScoreDate(Convert.ToDateTime(element.DateOfCreation));
            int profileScore = CtrStudent.GetScore(element.StudentId);
            element.Score = CtrApplications.SumScores(dateScore, profileScore);

            if (!dbUpdateObject.UpdateApplicationScore(element.Id, element.Score))
                Console.WriteLine("Error while updating Application score. ID: " + element.Id + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + "\n Time: " + DateTime.Now);

            return element;
        }
    }
}
