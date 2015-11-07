using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

            if (dbCheckEmailObj.checkEmailExists(mdlLandlordObj.Email))
                return dbLandlordObj.AddLandlord(mdlLandlordObj);

            return false;
        }
    }
}
