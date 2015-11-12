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
        public bool Login(string email, string password)
        {
            string queryStudent = "Select email, [password] from ST_Main  where email = '" + email
                + "' AND [Password] = '" + password + "'";
            string queryLandlord = "Select email, [password] from LD_Main  where email = '" + email
                + "' AND [Password] = '" + password + "'";

            try
            {
                string sqlEmailStudent = "";
                string sqlEmailLandlord = "";
                SqlCommand sqlCommand;
                SqlDataReader sqlReader;

                DbConnection.Open();
                sqlCommand = new SqlCommand(queryStudent, DbConnection.dbconn);
                sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    sqlEmailStudent = sqlReader.GetValue(0).ToString().Trim();
                }
                sqlReader.Close();

                sqlCommand = new SqlCommand(queryLandlord, DbConnection.dbconn);
                sqlReader = sqlCommand.ExecuteReader();

                while (sqlReader.Read())
                {
                    sqlEmailLandlord = sqlReader.GetValue(0).ToString().Trim();
                }

                sqlReader.Close();
                DbConnection.Close();

                if (email.Equals(sqlEmailStudent) || email.Equals(sqlEmailLandlord))
                {
                    Console.WriteLine("User {0} was successfully logged in.", email);
                    Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now.ToString());

                    return true;
                }

                Console.WriteLine("User {0} was unable to login due to incorrect email or password.", email);
                Console.WriteLine("Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now.ToString());
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
