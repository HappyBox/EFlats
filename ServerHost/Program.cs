using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace ServerHost
{
    class Program
    {
        static void Main(string[] args)
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
