using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Data.SqlClient;

namespace ServerDatabase
{
    public class DbCheckEmailExists
    {
        public bool checkEmailExists(string email)
        {
            return (checkLandlordEmailExists(email) || checkStudentEmailExists(email));
        }
        private bool checkStudentEmailExists(string email)
        {
            string query = "Select * form ST_Main where Email='" + email + "'";

            SqlCommand sqlCommand = new SqlCommand(query, DbConnection.dbconn);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            sqlReader.Read();
            string sqlEmail = sqlReader.GetValue(1).ToString().Trim();
            if(email == sqlEmail)
            {
                return true;
            }
            return false;
        }

        private bool checkLandlordEmailExists(string email)
        {
            string query = "Select * form LD_Main where Email='" + email + "'";

            SqlCommand sqlCommand = new SqlCommand(query, DbConnection.dbconn);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            sqlReader.Read();
            string sqlEmail = sqlReader.GetValue(1).ToString().Trim();
            if (email == sqlEmail)
            {
                return true;
            }
            return false;
        }
    }
}
