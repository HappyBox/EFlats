using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EFlatsServiceReference.WcfEFlatsServiceClient client = new EFlatsServiceReference.WcfEFlatsServiceClient();

            Console.WriteLine("CALLING ADD STUDENT");
            for(int i = 0; i < 1; i++)
            {
                bool lol = client.AddStudent("miropakanecc" + i + "@gmail.com", "pass", true, true, 100, 20, false, 25, false, DateTime.Now, "Miro", "Pakanec", "xxx", "fuck", "aalborg", "Denmark", "4546456465");
                //bool lol2 = client.AddLandlord("miropakanecc" + i + "@gmail.com", "pass", true,  DateTime.Now, "Miro", "Pakanec", "xxx", "fuck", "aalborg", "Denmark", "4546456465");
            }

            Console.ReadLine();
        }
    }
}
