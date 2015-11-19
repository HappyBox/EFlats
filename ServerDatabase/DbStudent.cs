using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;
using System.Data.SqlClient;
using ServerModel;

namespace ServerDatabase
{
    public class DbStudent
    {
        public bool AddStudent(MdlStudent studentObj)
        {
            try
            {
                DateTime myDateTime = studentObj.DateOfCreation;
                string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

                studentObj.Email = studentObj.Email + "T" + Thread.CurrentThread.ManagedThreadId.ToString();
                //DbConnection.Open();
                //DbStudent.CreateCommandMain(studentObj).ExecuteNonQuery();
                //SetLastId(studentObj);

                //DbStudent.CreateCommandQueuebased(studentObj).ExecuteNonQuery();
                //DbStudent.CreateCommandPersonal(studentObj).ExecuteNonQuery();

                //DbConnection.Close();
                //Console.WriteLine("REGISTRATION : true");
                //return true;

                string query1 = "insert into ST_Main values ('"
    + studentObj.Email + "','"
    + studentObj.Password + "',"
    + Convert.ToInt32(studentObj.Confirmed) + ","
    + Convert.ToInt32(studentObj.Student) + ")";

 

                using (var connection = new SqlConnection(DbConnection.connectionString))
                using (var command = new SqlCommand(query1, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                SetLastId(studentObj);

                string query2 = "insert into ST_Queue values ("
+ studentObj.Id + ","
+ studentObj.Score + ","
+ studentObj.NumberOfChildren + ","
+ Convert.ToInt32(studentObj.Pet) + ","
+ studentObj.NumberOfCohabiters + ","
+ Convert.ToInt32(studentObj.Disabled) + ",'"
+ sqlFormattedDate + "')";

                string query3 = "insert into ST_Personal values ("
    + studentObj.Id + ",'"
    + studentObj.Name + "','"
    + studentObj.Surname + "','"
    + studentObj.Address + "','"
    + studentObj.PostCode + "','"
    + studentObj.City + "','"
    + studentObj.Country + "','"
    + studentObj.Phone + "')";

                using (var connection = new SqlConnection(DbConnection.connectionString))
                using (var command = new SqlCommand(query2, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                using (var connection = new SqlConnection(DbConnection.connectionString))
                using (var command = new SqlCommand(query3, connection))
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

        private static void SetLastId(MdlStudent studentObj) 
        {
            // read Id from first table and make it the same in all other tables that is connected with users
            try
            {
                int score = 0;
                string query = "Select ID from ST_Main where email = '" + studentObj.Email + "'";

                Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);

                using (var connection = new SqlConnection(DbConnection.connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (var sqlReader = command.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            studentObj.Id = Convert.ToInt32(sqlReader.GetValue(0));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);
                DbConnection.Close();
            }



        }

        private static SqlCommand CreateCommandMain(MdlStudent studentObj)
        {
            string query = "insert into ST_Main values ('"
                + studentObj.Email + "','"
                + studentObj.Password + "',"
                + Convert.ToInt32(studentObj.Confirmed) + ","
                + Convert.ToInt32(studentObj.Student) + ")";

            Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);

            //return SQLCommand
            return DbConnection.GetDbCommand(query);
        }

        private static SqlCommand CreateCommandQueuebased(MdlStudent studentObj)
        {
            DateTime myDateTime = studentObj.DateOfCreation;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            string query = "insert into ST_Queue values ("
                + studentObj.Id + ","
                + studentObj.Score + ","
                + studentObj.NumberOfChildren + ","
                + Convert.ToInt32(studentObj.Pet) + ","
                + studentObj.NumberOfCohabiters + ","
                + Convert.ToInt32(studentObj.Disabled) + ",'"
                + sqlFormattedDate + "')";

            Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);
           
            //return SQLCommand
            return DbConnection.GetDbCommand(query);
        }

        private static SqlCommand CreateCommandPersonal(MdlStudent studentObj)
        {
            string query = "insert into ST_Personal values ("
                + studentObj.Id + ",'"
                + studentObj.Name + "','"
                + studentObj.Surname + "','"
                + studentObj.Address + "','"
                + studentObj.PostCode + "','"
                + studentObj.City + "','"
                + studentObj.Country + "','"
                + studentObj.Phone + "')";

            Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);

            //return SQLCommand
            return DbConnection.GetDbCommand(query);
        }

        public int GetScore(int studentId)
        {
            try
            {
                int score = 0;
                string query = "select Score from ST_Queue where Id = " + studentId;

                Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);

                using (var connection = new SqlConnection(DbConnection.connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (var sqlReader = command.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            score = Convert.ToInt32(sqlReader.GetValue(0));
                        }
                    }
                }

                return score;
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);
                DbConnection.Close();
                return 0;
            }

        }

        public int GetLastQueueNumber(int flatId)
        {
            try
            {
                IList<int> queueNumbersList = new List<int>();
                string query = "select QueueNumber from Applications where FlatId = " + flatId;

                Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);


                using (var connection = new SqlConnection(DbConnection.connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (var sqlReader = command.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            queueNumbersList.Add(Convert.ToInt32(sqlReader.GetValue(0)));
                        }
                    }
                }
               
                return queueNumbersList.Max();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);
                DbConnection.Close();
                return -1;
            }
        }

        public bool AddToWishlist(int studentId, int flatId, int score, int queueNumber)
        {
            try
            {
                string sqlFormattedDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string query = "insert into Applications values (" +
                     +studentId + "," + flatId + ",'" + sqlFormattedDate + "'," + score + "," + queueNumber + ")";
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
            catch(Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);
                DbConnection.Close();
                return false;
            }
        }

        public bool checkApplicationExists(int studentId, int flatId)
        {
            try
            {
                string query = "select * from Applications where StudentId = " + studentId + " and FlatId = " + flatId;

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
                DbConnection.Close();
                //return oposit as expected
                return true;
            }
        }

        public bool RemoveFromWishlist(int studentId, int flatId)
        {
            try
            {
                string query = "delete from Applications where StudentId = " + studentId + " and FlatId = " + flatId; 
   
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
            catch(Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);                
                return false;
            }
        }

        public ArrayList GetQueueBasedData(int id)
        {
            ArrayList queueBasedArrayList = new ArrayList();

            try
            {
                string query = "select NumberOfChildren, Disabled, NumberOfCohabitors from ST_Queue where id = " + id;

                Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);

                using (var connection = new SqlConnection(DbConnection.connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (var sqlReader = command.ExecuteReader())
                    {
                        while (sqlReader.Read())
                        {
                            queueBasedArrayList.Add(Convert.ToInt32(sqlReader.GetValue(0)));
                            queueBasedArrayList.Add(Convert.ToBoolean(sqlReader.GetValue(1)));
                            queueBasedArrayList.Add(Convert.ToInt32(sqlReader.GetValue(2)));
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);                
            }

            return queueBasedArrayList;
        }

        public int UpdateScore(int id, int score)
        {
            try
            {
                string query = "UPDATE [ST_Queue] set [Score] = " + score + "where id = " + id;

                Console.WriteLine("Thread " + Thread.CurrentThread.ManagedThreadId.ToString() + " Executed query: \n     " + query);

                using (var connection = new SqlConnection(DbConnection.connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                return score;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception catched: " + e + " Thread: " + Thread.CurrentThread.ManagedThreadId.ToString() + " Time: " + DateTime.Now);
                return -2;
            }
        }
    }
}
