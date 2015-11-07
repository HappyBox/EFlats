using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;
using ServerModel;

namespace ServerDatabase
{
    public class DbLandlord
    {
        public bool AddLandlord(MdlLandlord landordObj)
        {
            try
            {
                //CheckEmailVaild(landordObj);

                CreateCommandMain(landordObj).ExecuteNonQuery();

                // read Id from first table and make it the same in all other tables that is connected with users
                string query = "Select ID form ST_Main where email = '" + landordObj.Email + "'";
                SqlCommand sqlCommand = new SqlCommand(query, DbConnection.dbconn);
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                sqlReader.Read();
                landordObj.Id = Convert.ToInt32(sqlReader.GetValue(0));

                CreateCommandQueuebased(landordObj).ExecuteNonQuery();
                CreateCommandPersonal(landordObj).ExecuteNonQuery();

                DbConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);
                return false;
            }

        }

        private static SqlCommand CreateCommandMain(MdlLandlord landordObj)
        {
            string query = "insert into LD_Main values ('"
                + landordObj.Email + "','"
                + landordObj.Password + "',"
                + Convert.ToInt32(landordObj.Confirmed) + ")";

            Console.Write("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "Executed query: \n     " + query);

            //return SQLCommand
            return DbConnection.GetDbCommand(query);
        }

        private static SqlCommand CreateCommandQueuebased(MdlLandlord landordObj)
        {
            DateTime myDateTime = landordObj.DateOfCreation;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            string query = "insert into LD_Queue values ("
                + landordObj.Id + ",'"
                + sqlFormattedDate + "')";

            Console.Write("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "Executed query: \n     " + query);

            //return SQLCommand
            return DbConnection.GetDbCommand(query);
        }

        private static SqlCommand CreateCommandPersonal(MdlLandlord landordObj)
        {
            string query = "insert into LD_Personal values ('"
                + landordObj.Id + ",'"
                + landordObj.Name + "','"
                + landordObj.Surname + "','"
                + landordObj.Address + "','"
                + landordObj.PostCode + "','"
                + landordObj.City + "','"
                + landordObj.Country + "','"
                + landordObj.Phone + "')";

            Console.Write("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + "Executed query: \n     " + query);

            //return SQLCommand
            return DbConnection.GetDbCommand(query);
        }
    }
}
