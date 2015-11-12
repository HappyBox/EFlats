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

            //register (new) Student Test
            bool registerStudentTest = false;
            registerStudentTest = client.AddStudent("miropakanec@gmail.com", "mypassword", false, false, 0, 0, false, 0, false, DateTime.Now, null, null, null, null, null, null, null);
            Console.WriteLine("register student          | result: " + registerStudentTest.ToString());

            //register (same) Student Again and fail Test
            bool registerStudentFailTest = false;
            registerStudentFailTest = client.AddStudent("miropakanec@gmail.com", "mypassword", false, false, 0, 0, false, 0, false, DateTime.Now, null, null, null, null, null, null, null);
            Console.WriteLine("register student  (fail)  | result: " + registerStudentFailTest.ToString());

            //register (new landlord with existing student email) Landlord Test
            bool registerLandlordSTTest = false;
            registerLandlordSTTest = client.AddLandlord("miropakanec@gmail.com", "mypassword", false, DateTime.Now, null, null, null, null, null, null, null);
            Console.WriteLine("register landlord (fail)  | result: " + registerLandlordSTTest.ToString());

            //register (new) Landlord Test
            bool registerLandlordTest = false;
            registerLandlordTest = client.AddLandlord("miropakanecLD@gmail.com", "mypassword", false, DateTime.Now, null, null, null, null, null, null, null);
            Console.WriteLine("register landlord         | result: " + registerLandlordTest.ToString());

            //register (same) Landlord Again and fail Test
            bool registerLandlordFailTest = false;
            registerLandlordFailTest = client.AddLandlord("miropakanecLD@gmail.com", "mypassword", false, DateTime.Now, null, null, null, null, null, null, null);
            Console.WriteLine("register landlord (fail)  | result: " + registerLandlordFailTest.ToString());

            Console.WriteLine();

            //add flat (new) with exisitng landlord email Test
            bool addFlatTest = false;
            addFlatTest = client.AddApartment("miropakanecLD@gmail.com", "flat", "address", "zipCode", 2000.0, 6000.0, DateTime.Now, DateTime.Now);
            Console.WriteLine("add flat                  | result: " + addFlatTest.ToString());

            //add flat (new) with non exisitng landlord email Test
            bool addFlatNonExistingLandlordTest = false;
            addFlatNonExistingLandlordTest = client.AddApartment("miropakanecLDNonExisting@gmail.com", "flat", "address", "zipCode", 2000.0, 6000.0, DateTime.Now, DateTime.Now);
            Console.WriteLine("add flat (fail)           | result: " + addFlatNonExistingLandlordTest.ToString());

            //very good catch to set address as PK
            Console.WriteLine();

            //login student with existing account, correct password Test
            bool loginStudentExistingTest = false;
            loginStudentExistingTest = client.Login("miropakanec@gmail.com", "mypassword");
            Console.WriteLine("login student             | result: " + loginStudentExistingTest.ToString());

            //login student with non existing account, correct password Test
            bool loginStudentNonExistingTest = false;
            loginStudentNonExistingTest = client.Login("miropakanecNonExisting@gmail.com", "mypassword");
            Console.WriteLine("login student (fail acc)  | result: " + loginStudentNonExistingTest.ToString());

            //login student with existing account, incorrect password Test
            bool loginStudentIncorrectPassTest = false;
            loginStudentIncorrectPassTest = client.Login("miropakanec@gmail.com", "mypasswordIncorrect");
            Console.WriteLine("login student (fail pass) | result: " + loginStudentIncorrectPassTest.ToString());

            Console.ReadLine();
        }
    }
}
