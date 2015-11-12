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
            return checkEmailExistsDBCall(email);
        }

        public bool checkLandlordEmailExists(string email)
        {
            string queryLandlord = "Select Email from LD_Main where Email='" + email + "'";
            string sqlEmailLandlord = "";
            SqlCommand sqlCommand;
            SqlDataReader sqlReader;

            DbConnection.Open();
            sqlCommand = new SqlCommand(queryLandlord, DbConnection.dbconn);
            sqlReader = sqlCommand.ExecuteReader();

            while (sqlReader.Read())
            {
                sqlEmailLandlord = sqlReader.GetValue(0).ToString().Trim();
            }

            sqlReader.Close();
            DbConnection.Close();

            if (email.Equals(sqlEmailLandlord))
                return true;

            return false;
        }

        private bool checkEmailExistsDBCall(string email)
        {
            string queryStudent = "Select Email from ST_Main where Email='" + email + "'";
            string queryLandlord = "Select Email from LD_Main where Email='" + email + "'";
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
                return true;
            }
            return false;
        }
    }
}
