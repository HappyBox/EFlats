using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
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
    }
}
