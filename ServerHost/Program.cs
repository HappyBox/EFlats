using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread updateQueue = new Thread(new ThreadStart(TimeTestMethod));
            //updateQueue.Start();

            using (ServiceHost host = new ServiceHost(typeof(WcfEFlatsService.WcfEFlatsService)))
            {
                host.Open();
                Console.WriteLine("Host has started @ time: " + DateTime.Now.ToString());

                while (true)
                {
                    Console.ReadLine();
                    Console.WriteLine();
                }
            }
        }

        //public static void TimeTestMethod()
        //{
        //    DateTime MyDateTime;
        //    MyDateTime = new DateTime();

        //    MyDateTime = DateTime.ParseExact("2015 - 11 - 12 17:14 PM", "yyyy-MM-dd HH:mm tt", null);
        //    Console.WriteLine("TIME TEST THREAD STARTED");

        //    while (true)
        //    {
        //        if (DateTime.Now == MyDateTime)
        //        {
        //            for (int i = 0; i < 20; i++)
        //            {
        //                Console.WriteLine("IT WORKS!!!");
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Not time yet");
        //        }
        //        Thread.Sleep(5000);
        //    }
        //    Console.WriteLine("TIME TEST THREAD FINISHED");
        //}
    }
}
