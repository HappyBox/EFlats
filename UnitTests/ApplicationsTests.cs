using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerController;
using ServerDatabase;
using ServerModel;
using System.Data;
using System.Data.SqlClient;

namespace UnitTests
{
    [TestClass]
    public class ApplicationsTests
    {
        [TestMethod]
        public void AddToWishList()
        {
            bool actualResult = false;
            bool expectedResult = true;

            CtrStudent ctrStudentObj = new CtrStudent();

            actualResult = ctrStudentObj.AddToWishlist(360, GetFlatId(), 0, -1);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddToWishListRepeatSameFail()
        {
            bool actualResult = true;
            bool expectedResult = false;

            CtrStudent ctrStudentObj = new CtrStudent();

            actualResult = ctrStudentObj.AddToWishlist(360, GetFlatId(), 0, -1);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetLastQueueNumber()
        {
            int actualResult = 0;

            CtrStudent ctrStudentObj = new CtrStudent();

            actualResult = ctrStudentObj.GetLastQueueNumber(GetFlatId());
            Assert.IsNotNull(actualResult);
        }

        [TestMethod]
        public void GetLastQueueNumberFlatFail()
        {
            int actualResult=0;

            CtrStudent ctrStudentObj = new CtrStudent();

            actualResult = ctrStudentObj.GetLastQueueNumber(1);
            Assert.AreEqual(actualResult, -2);
        }

        [TestMethod]
        public void RemoveFromWishList()
        {
            bool actualResult = false;
            bool expectedResult = true;

            CtrStudent ctrStudentObj = new CtrStudent();

            actualResult = ctrStudentObj.RemoveFromWishlist(361, GetFlatId());
            Assert.AreEqual(expectedResult, actualResult);
        }

        

        public static int GetFlatId()
        {
            try
            {
                string query = "select FlatId from Flat_Main";

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
                return 0;
            }
        }
    }


}
