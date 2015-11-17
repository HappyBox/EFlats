using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using ServerModel;

namespace ServerDatabase
{
    public class DbUpdate
    {
        public Array UpdateScore(int lastRowId)
        {
            try
            {

                MdlApplication mdlApplicationObj;

                //create appropriate array
                MdlApplication[] applicationList = new MdlApplication[lastRowId];
                string query = "select * from Applications";
                Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);

                using (var connection = new SqlConnection(DbConnection.connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var sqlReader = command.ExecuteReader())
                    {
                        int i = 0;
                        while (sqlReader.Read() && i <= lastRowId)
                        {
                            mdlApplicationObj = new MdlApplication();
                            //while reads initialize and populate list
                            mdlApplicationObj.Id = Convert.ToInt32(sqlReader.GetValue(0));
                            mdlApplicationObj.StudentId = Convert.ToInt32(sqlReader.GetValue(1));
                            mdlApplicationObj.FlatId = Convert.ToInt32(sqlReader.GetValue(2));
                            mdlApplicationObj.DateOfCreation = Convert.ToDateTime(sqlReader.GetValue(3));
                            mdlApplicationObj.Score = Convert.ToInt32(sqlReader.GetValue(4));
                            mdlApplicationObj.QueueNumber = Convert.ToInt32(sqlReader.GetValue(5));

                            applicationList[i] = mdlApplicationObj;
                        }
                    }
                }
                return applicationList;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);
                return null; 
            }
        }

        public int GetLastRowId()
        {
            try
            {
                string query = "SELECT TOP 1 * FROM Applications ORDER BY ID DESC";
                Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);

                using (var connection = new SqlConnection(DbConnection.connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var sqlReader = command.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            return Convert.ToInt32(sqlReader.GetValue(0));
                        }
                    }
                }
                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);
                return 0;
            }
        }

        public bool UpdateApplicationScore(int id, int score)
        {
            try
            {
                string query = "UPDATE [Applications] set [Score] = " + score + " where id = " + id;

                Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);

                using (var connection = new SqlConnection(DbConnection.connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);
                return false;
            }
        }
    }
}
