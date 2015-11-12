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
        public bool AddLandlord(MdlLandlord landlordObj)
        {
            try
            {
                CreateCommandMain(landlordObj).ExecuteNonQuery();
                SetLastId(landlordObj);

                CreateCommandQueuebased(landlordObj).ExecuteNonQuery();
                CreateCommandPersonal(landlordObj).ExecuteNonQuery();

                DbConnection.Close();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);
                return false;
            }

        }
        private static void SetLastId(MdlLandlord landlordObj)
        {
            // read Id from first table and make it the same in all other tables that is connected with users
            string query = "Select ID from LD_Main where email = '" + landlordObj.Email + "'";
            SqlCommand sqlCommand = new SqlCommand(query, DbConnection.dbconn);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            sqlReader.Read();
            landlordObj.Id = Convert.ToInt32(sqlReader.GetValue(0));
            sqlReader.Close();
        }

        private static SqlCommand CreateCommandMain(MdlLandlord landlordObj)
        {
            string query = "insert into LD_Main values ('"
                + landlordObj.Email + "','"
                + landlordObj.Password + "',"
                + Convert.ToInt32(landlordObj.Confirmed) + ")";

            Console.Write("\n\nThread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);

            //return SQLCommand
            return DbConnection.GetDbCommand(query);
        }

        private static SqlCommand CreateCommandQueuebased(MdlLandlord landlordObj)
        {
            DateTime myDateTime = landlordObj.DateOfCreation;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            string query = "insert into LD_Queue values ("
                + landlordObj.Id + ",'"
                + sqlFormattedDate + "')";

            Console.Write("\n\nThread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);

            //return SQLCommand
            return DbConnection.GetDbCommand(query);
        }

        private static SqlCommand CreateCommandPersonal(MdlLandlord landlordObj)
        {
            string query = "insert into LD_Personal values ("
                + landlordObj.Id + ",'"
                + landlordObj.Name + "','"
                + landlordObj.Surname + "','"
                + landlordObj.Address + "','"
                + landlordObj.PostCode + "','"
                + landlordObj.City + "','"
                + landlordObj.Country + "','"
                + landlordObj.Phone + "')";

            Console.Write("\n\nThread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);

            //return SQLCommand
            return DbConnection.GetDbCommand(query);
        }
    }
}
