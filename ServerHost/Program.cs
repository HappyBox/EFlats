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
            Thread updateQueue = new Thread(new ThreadStart(ServerController.CtrUpdate.UpdateQueue));
            Thread host = new Thread(new ThreadStart(RunHost));

            host.Start();
            updateQueue.Start();


        }

        public static void RunHost()
        {
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
    }
}
