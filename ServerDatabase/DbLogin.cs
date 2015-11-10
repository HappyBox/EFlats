using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using ServerModel;

namespace ServerDatabase
{
    public class DbLogin
    {
        public bool LoginStudent(MdlStudent mdlStudentObj, MdlLandlord mdlLandlordObj)
        {
            string queryStudent = "Select email, [password] from LD_Main  where email = '" + mdlStudentObj.Email
                + "' AND [Password] = '" + mdlStudentObj.Password + "'";
            string queryLandlord = "Select email, [password] from SD_Main  where email = '" + mdlLandlordObj.Email
                + "' AND [Password] = '" + mdlLandlordObj.Password + "'";

            try
            {
                SqlCommand sqlCommand = new SqlCommand(queryStudent, DbConnection.dbconn);
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                sqlReader.Read();

                if(sqlReader.GetValue(0).ToString() == mdlStudentObj.Email)
                    return true;

                sqlReader.Close();
                sqlCommand = new SqlCommand(queryLandlord, DbConnection.dbconn);
                sqlReader = sqlCommand.ExecuteReader();
                sqlReader.Read();

                if (sqlReader.GetValue(0).ToString() == mdlLandlordObj.Email)
                    return true;

                return false;

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);
                return false;
            }
        }
    }
}
