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
    public class DbFlat
    {
        public bool Add(MdlFlat dbFlatObj)
        {
            try
            {
                string query = "insert into Flats values ("
                    + dbFlatObj.LandlordId + ","
                    + dbFlatObj.Type + ",'"
                    + dbFlatObj.Address + "',"
                    + dbFlatObj.PostCode + ","
                    + dbFlatObj.RentPrice + ","
                    + dbFlatObj.Deposit + ",'"
                    + dbFlatObj.Avaiable + "','"
                    + dbFlatObj.DateOfCreation + "')";

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
    }
}
