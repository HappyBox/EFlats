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
    public class DbStudent
    {
        public bool AddStudent(MdlStudent studentObj)
        {
            try
            {
                DbStudent.CreateCommandMain(studentObj).ExecuteNonQuery();
                SetLastId(studentObj);

                DbStudent.CreateCommandQueuebased(studentObj).ExecuteNonQuery();
                DbStudent.CreateCommandPersonal(studentObj).ExecuteNonQuery();

                DbConnection.Close();
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
            string query = "Select ID from ST_Main where email = '" + studentObj.Email + "'";
            SqlCommand sqlCommand = new SqlCommand(query, DbConnection.dbconn);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            sqlReader.Read();
            studentObj.Id = Convert.ToInt32(sqlReader.GetValue(0));
            sqlReader.Close();
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
    }
}
