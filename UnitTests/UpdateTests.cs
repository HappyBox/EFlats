using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using ServerController;
using ServerDatabase;
using ServerModel;

namespace UnitTests
{
    [TestClass]
    public class UpdateTests
    {
        [TestMethod]
        public void CalculateScoreDateTest()
        {
            int actualResult = -2;
            int expectedResult = -24; //0 - 1 * 24
            actualResult = CtrApplications.CalculateScoreDate(DateTime.Now);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void GetProfileScoreTest()
        {
            int actualResult = 0;
            int expectedResult = 100;
            actualResult = CtrStudent.GetScore(360);
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SumScoresTest()
        {
            int actualResult = 0;
            int expectedResult = 76; //100 - 24
            actualResult = CtrApplications.SumScores(CtrApplications.CalculateScoreDate(DateTime.Now), CtrStudent.GetScore(360));
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DbRecieveListOfStudents()
        {
            int actualResult = -1;
            int expectedResult = ApplicationsTests.GetFlatId(); ;

            ServerDatabase.DbUpdate dbUpdateObject = new ServerDatabase.DbUpdate();
            List<MdlApplication> applicationList = dbUpdateObject.UpdateScore();

            actualResult = applicationList[applicationList.Count - 1].FlatId;
            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        public void DbUpdateApplicationScore()
        {
            bool actualResult = false;
            bool expectedResult = true;

            ServerDatabase.DbUpdate dbUpdateObject = new ServerDatabase.DbUpdate();
            actualResult = dbUpdateObject.UpdateApplicationScore(getApplicationId(), 500);
            
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DbUpdateApplicationQueue()
        {
            bool actualResult = false;
            bool expectedResult = true;

            ServerDatabase.DbUpdate dbUpdateObject = new ServerDatabase.DbUpdate();
            actualResult = dbUpdateObject.UpdateApplicationScore(getApplicationId(), 2);

            Assert.AreEqual(expectedResult, actualResult);
        }


        [TestMethod]
        public void CtrUpdateQueue()
        {

            int actualResult = 0;
            int expectedResult = 2; //2 applications after all tests ran

            ServerDatabase.DbUpdate dbUpdateObject = new ServerDatabase.DbUpdate();
            List<MdlApplication> applicationList = dbUpdateObject.UpdateScore();
            CtrUpdate.UpdateQueue(applicationList);
            actualResult = applicationList[applicationList.Count - 1].QueueNumber;

            expectedResult = applicationList.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        public int getApplicationId()
        {
            try
            {
                string query = "select id from Applications";

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
