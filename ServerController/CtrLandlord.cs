using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerDatabase;
using ServerModel;

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

            //if (dbCheckEmailObj.checkEmailExists(mdlLandlordObj.Email))
                return dbLandlordObj.AddLandlord(mdlLandlordObj);

        }
            // int flatID
        public bool AddApartment(int landlordId, int type, string address, int zipCode, int rentPrice, int deposit, DateTime avaiable, DateTime dateFormCreation)
        {
            bool dbFeedback = false;
            switch (type)
            {
                //room
                case 1:
                    Console.WriteLine("Wrong type of flat: " + type);
                    break;
                //flat
                case 2:
                    DbFlat dbFlatObj = new DbFlat();
                    MdlFlat mdlFlat = new MdlFlat(landlordId, type, dateFormCreation, avaiable, rentPrice, deposit, address, zipCode);
                    dbFeedback = dbFlatObj.Add(mdlFlat);
                    break;
                //house
                case 3:
                    Console.WriteLine("Wrong type of flat: " + type);
                    break;
                default:
                    Console.WriteLine("Wrong type of flat: " + type);
                    break;
            }
            return dbFeedback;
        }
    }
}
