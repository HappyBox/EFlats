using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace ServerDatabase
{
    public class DbGetData
    {
        public static ServerModel.MdlStudent GetStudentData(ServerModel.MdlStudent mdlStudentObj)
        {
            mdlStudentObj = GetStudentDataMain(mdlStudentObj);
            mdlStudentObj = GetStudentDataQueue(mdlStudentObj);
            mdlStudentObj = GetStudentDataPersonal(mdlStudentObj);
            return mdlStudentObj;
        }

        public static ServerModel.MdlLandlord GetLandlordData(ServerModel.MdlLandlord mdlLandlordObj)
        {
            mdlLandlordObj = GetLandlordDataMain(mdlLandlordObj);
            mdlLandlordObj = GetLandlordDataQueue(mdlLandlordObj);
            mdlLandlordObj = GetLandlordDataPersonal(mdlLandlordObj);

            return mdlLandlordObj;
        }

        private static ServerModel.MdlLandlord GetLandlordDataMain(ServerModel.MdlLandlord mdlLandlordOnj)
        {
            string queryLandlord = "Select * from LD_Main where email = '" + mdlLandlordOnj.Email + "'";
            DbConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(queryLandlord, DbConnection.dbconn);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                mdlLandlordOnj.Id = Convert.ToInt32(sqlReader.GetValue(0));
                //mdlLandlordOnj.Password = sqlReader.GetValue(2).ToString().Trim();
                mdlLandlordOnj.Confirmed = Convert.ToBoolean(sqlReader.GetValue(3));
            }

            sqlReader.Close();
            DbConnection.Close();
            return mdlLandlordOnj;
        }

        private static ServerModel.MdlLandlord GetLandlordDataQueue(ServerModel.MdlLandlord mdlLandlordObj)
        {
            string queryLandlord = "Select * from LD_Queue where id = '" + mdlLandlordObj.Id + "'";
            DbConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(queryLandlord, DbConnection.dbconn);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                mdlLandlordObj.DateOfCreation = Convert.ToDateTime(sqlReader.GetValue(1).ToString().Trim());
            }

            sqlReader.Close();
            DbConnection.Close();
            return mdlLandlordObj;
        }

        private static ServerModel.MdlLandlord GetLandlordDataPersonal(ServerModel.MdlLandlord mdlLandlordObj)
        {
            string queryLandlord = "Select * from LD_Personal where id = '" + mdlLandlordObj.Id + "'";
            DbConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(queryLandlord, DbConnection.dbconn);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                mdlLandlordObj.Name = sqlReader.GetValue(1).ToString().Trim();
                mdlLandlordObj.Surname = sqlReader.GetValue(2).ToString().Trim();
                mdlLandlordObj.Address = sqlReader.GetValue(3).ToString().Trim();
                mdlLandlordObj.PostCode = sqlReader.GetValue(4).ToString().Trim();
                mdlLandlordObj.City = sqlReader.GetValue(5).ToString().Trim();
                mdlLandlordObj.Country = sqlReader.GetValue(6).ToString().Trim();
                mdlLandlordObj.Phone = sqlReader.GetValue(7).ToString().Trim();
            }

            sqlReader.Close();
            DbConnection.Close();
            return mdlLandlordObj;
        }

        private static ServerModel.MdlStudent GetStudentDataMain(ServerModel.MdlStudent mdlStudentObj)
        {
            string queryStudent = "Select * from ST_Main where email = '" + mdlStudentObj.Email + "'";
            DbConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(queryStudent, DbConnection.dbconn);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                mdlStudentObj.Id = Convert.ToInt32(sqlReader.GetValue(0));
                //mdlStudentObj.Password = sqlReader.GetValue(2).ToString().Trim();
                mdlStudentObj.Confirmed = Convert.ToBoolean(sqlReader.GetValue(3));
                mdlStudentObj.Student = Convert.ToBoolean(sqlReader.GetValue(4));
            }

            sqlReader.Close();
            DbConnection.Close();
            return mdlStudentObj;
        }

        private static ServerModel.MdlStudent GetStudentDataQueue(ServerModel.MdlStudent mdlStudentObj)
        {
            string queryStudent = "Select * from ST_Queue where id = '" + mdlStudentObj.Id + "'";
            DbConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(queryStudent, DbConnection.dbconn);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                mdlStudentObj.Score = Convert.ToInt32(sqlReader.GetValue(1));
                mdlStudentObj.NumberOfChildren = Convert.ToInt32(sqlReader.GetValue(2));
                mdlStudentObj.Pet = Convert.ToBoolean(sqlReader.GetValue(3));
                mdlStudentObj.NumberOfCohabiters = Convert.ToInt32(sqlReader.GetValue(4));
                mdlStudentObj.Disabled = Convert.ToBoolean(sqlReader.GetValue(5));
                mdlStudentObj.DateOfCreation = Convert.ToDateTime(sqlReader.GetValue(6).ToString().Trim());
            }

            sqlReader.Close();
            DbConnection.Close();
            return mdlStudentObj;
        }

        private static ServerModel.MdlStudent GetStudentDataPersonal(ServerModel.MdlStudent mdlStudentObj)
        {
            string queryStudent = "Select * from ST_Personal where id = '" + mdlStudentObj.Id + "'";
            DbConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(queryStudent, DbConnection.dbconn);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();
            while (sqlReader.Read())
            {
                mdlStudentObj.Name = sqlReader.GetValue(1).ToString().Trim();
                mdlStudentObj.Surname = sqlReader.GetValue(2).ToString().Trim();
                mdlStudentObj.Address = sqlReader.GetValue(3).ToString().Trim();
                mdlStudentObj.PostCode = sqlReader.GetValue(4).ToString().Trim();
                mdlStudentObj.City = sqlReader.GetValue(5).ToString().Trim();
                mdlStudentObj.Country = sqlReader.GetValue(6).ToString().Trim();
                mdlStudentObj.Phone = sqlReader.GetValue(7).ToString().Trim();
            }

            sqlReader.Close();
            DbConnection.Close();
            return mdlStudentObj;
        }

        public static string GetUserType(string email)
        {
            if (SearchType(email, "ST_Main"))
                return "student";

            if (SearchType(email, "LD_Main"))
                return "landlord";

            return "notFound";
        }

        private static bool SearchType(string email, string tableName)
        {
            string queryStudent = "Select * from "+ tableName +" where email = '" + email + "'";
            bool found = false;

            DbConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(queryStudent, DbConnection.dbconn);
            SqlDataReader sqlReader = sqlCommand.ExecuteReader();

            while (sqlReader.Read())
            {
                found = true;
            }
            sqlReader.Close();
            DbConnection.Close();
            return found;
        }


    }
}
