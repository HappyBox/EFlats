using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerController
{
    public class CtrLandlord
    {
        public bool AddLandlord(string email, string password, bool confirmed, DateTime dateOfCreation,
            string name, string surname, string address, string postCode, string city, string country, string phone)
        {
            ServerModel.MdlLandlord mdlLandlordObj = new ServerModel.MdlLandlord(0, email, password, confirmed, 
                dateOfCreation, name, surname, address, postCode, city, country, phone);

            ServerDatabase.DbLandlord dbLandlordObj = new ServerDatabase.DbLandlord();
            ServerDatabase.DbCheckEmailExists dbCheckEmailObj = new ServerDatabase.DbCheckEmailExists();

            //if email does not exist register
            if (!dbCheckEmailObj.checkEmailExists(mdlLandlordObj.Email))
                return dbLandlordObj.AddLandlord(mdlLandlordObj);

            Console.WriteLine("Registration has failed due to the existing email");
            Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now.ToString());
            return false;
        }

        public bool AddApartment(string landlordEmail, string type, string address, string zipCode, 
            double rentPrice, double deposit, DateTime avaiable, DateTime dateFormCreation, string description)
        {
            ServerDatabase.DbFlat dbFlatObj = new ServerDatabase.DbFlat();
            ServerDatabase.DbCheckEmailExists dcCheckEmailObj = new ServerDatabase.DbCheckEmailExists();
            ServerModel.MdlFlat mdlFlat = new ServerModel.MdlFlat(landlordEmail, type, dateFormCreation, avaiable, 
                rentPrice, deposit, address, zipCode, description);
            //if email exists add flat
            if(dcCheckEmailObj.checkLandlordEmailExists(landlordEmail))
                return dbFlatObj.Add(mdlFlat);

            Console.WriteLine("Unable to add a flat due to non existing landlord email");
            Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now.ToString());
            return false;
        }
    }
}
