using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ServerDatabase
{
    public class DbConnection
    {
        public static readonly string connectionString = @"Data Source=MPJ-HP\SQLEXPRESS;Initial Catalog=EFlats;Integrated Security=True";
        public static readonly SqlConnection dbconn = new SqlConnection(connectionString);
        private static SqlCommand dbCmd;

        public static void Open()
        {
            if (dbconn.State.ToString().CompareTo("Open") != 0)
                dbconn.Open();
        }

        public static SqlCommand GetDbCommand(string sql)
        {
            if (dbconn.State.ToString().CompareTo("Open") != 0)
                Open();
            if (dbCmd == null)
            {
                dbCmd = new SqlCommand(sql, dbconn);
            }
            dbCmd.CommandText = sql;
            return dbCmd;
        }

        public static void Close()
        {
            dbconn.Close();
        }
    }
}
