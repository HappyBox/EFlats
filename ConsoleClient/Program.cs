using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            EFlatsServiceReference.WcfEFlatsServiceClient client = new EFlatsServiceReference.WcfEFlatsServiceClient();
/*
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

            //get data from existing user (student)
            object[] listStudent = new object[18];
            client.GetData("default2@default.com").CopyTo(listStudent, 0);
            Console.Write("\n\nFetching student data from database: \n");
            for (int i = 0; i < listStudent.Length; i++)
            {
                Console.Write(listStudent[i] + " ,");
            }
            //userData = initialize...(userData)

            //get data from existing user (landlord)
            object[] listLandlord = new object[18];
            client.GetData("default3@default.com").CopyTo(listLandlord, 0);
            Console.Write("\n\nFetching landlord data from database: \n");
            for (int i = 0; i < listLandlord.Length; i++)
            {
                Console.Write(listLandlord[i] + " ,");
            }

            //get data from nonexisting user
            object[] list = new object[18];
            client.GetData("nonExisting@default.com").CopyTo(list, 0);
            Console.Write("\n\nFetching user data from database: \n");
            for (int i = 0; i < list.Length; i++)
            {
                Console.Write(list[i] + " ,");
            }

            Console.WriteLine();
            Console.WriteLine();

            //CHANGE FLAT ID

            //add to wish list
            bool AddToWishlist = false;
            AddToWishlist = client.AddToWishlist(360, "miropakanec@gmail.com", 60);
            Console.WriteLine("add to wishlist           | result: " + AddToWishlist);

            //add to wishlist existing application
            bool AddToWishlistExistingApplication = false;
            AddToWishlistExistingApplication = client.AddToWishlist(360, "miropakanec@gmail.com", 60);
            Console.WriteLine("add to wishlist (fail APP)| result: " + AddToWishlistExistingApplication);

            //add to wish list non existing student
            bool AddToWishlistNonExistingStudent = false;
            AddToWishlistNonExistingStudent = client.AddToWishlist(5000, "miropakanecNonExisting@gmail.com", 60);
            Console.WriteLine("add to wishlist (fail ST) | result: " + AddToWishlistNonExistingStudent);

            //add to wish list non existing flat
            bool AddToWishlistNonExistingFlat = false;
            AddToWishlistNonExistingStudent = client.AddToWishlist(360, "miropakanec@gmail.com", 5000);
            Console.WriteLine("add to wishlist (fail FL) | result: " + AddToWishlistNonExistingFlat);

            //remove from wish list
            bool removeFromWishlist = false;
            removeFromWishlist = client.RemoveFromWishlist(360, 60);
            Console.WriteLine("remove from wishlist     | result: " + removeFromWishlist);


            //calculate score (3, 1, 0)
            int score = 0;
            score = client.CalculateProfileScore(500, "default5@default.com");
            Console.WriteLine("calculate profile score    | result: " + score );
*/
            int score = -1;
            score = client.CalculateApplicationScore(400, "default@default.com", 60);
            Console.WriteLine("Calculate application score() | result: " + score);


            Console.ReadLine();
        }
    }
}
