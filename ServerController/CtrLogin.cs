using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerController
{
    public class CtrLogin
    {
        public bool Login(string email, string password)
        {
            ServerModel.MdlStudent mdlStudentObj = new ServerModel.MdlStudent(email, password);
            ServerModel.MdlLandlord mdlLandlordObj = new ServerModel.MdlLandlord(email, password);
            ServerDatabase.DbLogin dbLoginObj = new ServerDatabase.DbLogin();

            return dbLoginObj.LoginStudent(mdlStudentObj, mdlLandlordObj);
        }
    }
}
