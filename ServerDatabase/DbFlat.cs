using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ServerModel;

namespace ServerDatabase
{
    public class DbFlat
    {
        public bool Add(MdlFlat dbFlatObj)
        {
            string sqlFormattedDate = dbFlatObj.DateOfCreation.ToString("yyyy-MM-dd HH:mm:ss");
            string sqlFormattedDateAvailable = dbFlatObj.Avaiable.ToString("yyyy-MM-dd HH:mm:ss");

            try
            {
                string query = "insert into Flat_Main values ('"
                    + dbFlatObj.LandlordEmail + "','"
                    + dbFlatObj.Type + "','"
                    + dbFlatObj.PostCode + "','"
                    + dbFlatObj.Address + "',"
                    + dbFlatObj.RentPrice + ","
                    + dbFlatObj.Deposit + ",'"
                    + sqlFormattedDateAvailable + "','"
                    + sqlFormattedDate + "')";

                DbConnection.GetDbCommand(query).ExecuteNonQuery();

                DbConnection.Close();
                Console.Write("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);
                return false;
            }
        }

        public bool CheckFlatExists(int flatId)
        {
            try
            {
                string query = "select FlatId from Flat_Main where FlatId = " + flatId;

                Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);


                using (var connection = new SqlConnection(DbConnection.connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (var sqlReader = command.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);
                return false;
            }
        }
    }
}
