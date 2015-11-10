using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EFlatsServiceReference.WcfEFlatsServiceClient client = new EFlatsServiceReference.WcfEFlatsServiceClient();
            bool test = false, test2 = false;

            //for (int i = 0; i < 20; i++)
            //{

            //Thread newThread = new Thread(() =>
            //{
            //    test2 = client.AddLandlord("miropakanecc@gmail.com", "pass", true, DateTime.Now, "Miro", "Pakanec", "xxx", "fuck", "aalborg", "Denmark", "4546456465");
            //});
            //newThread.Start();
            //newThread.Join();

            //if (test == false)
            //{
            //    Console.WriteLine("Unable to log in - email already exists");
            //}
            //else
            //{
            //    Console.WriteLine("Registration was successful");
            //}

            //Console.WriteLine("Calling add student");
            //test = client.AddStudent("miropakanecc@gmail.com", "pass", true, true, 100, 20, false, 25, false, DateTime.Now, "Miro", "Pakanec", "xxx", "fuck", "aalborg", "Denmark", "4546456465");

            for(int i = 0; i < 10; i++)
            {
                Console.WriteLine("Calling add landlord");
                test = client.AddLandlord("miropakanecc@gmail.com", "pass", true, DateTime.Now, "Miro", "Pakanec", "xxx", "fuck", "aalborg", "Denmark", "4546456465");

                if (test == true)
                {
                    Console.WriteLine("Registration was successful");
                }
                else
                {
                    Console.WriteLine("Unable to log in - email already exists");
                }

            }

            //}




            Console.ReadLine();
        }
    }
}
