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
            ServerDatabase.DbLogin dbLoginObj = new ServerDatabase.DbLogin();
            return dbLoginObj.Login(email, password);
        }
    }
}
