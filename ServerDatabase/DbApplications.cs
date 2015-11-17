using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ServerDatabase
{
    public class DbApplications
    {
        public string GetDate(int studentId, int flatId)
        {
            try
            {
                string query = "select DateOfCreation from Applications where StudentId = " + studentId + " and FlatId = " + flatId;
                Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);

                using (var connection = new SqlConnection(DbConnection.connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (var sqlReader = command.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            return sqlReader.GetValue(0).ToString();
                        }
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);
                return null;
            }
        }
    }
}
