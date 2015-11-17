using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerDatabase;
using ServerModel;
using ServerController;

namespace UnitTests
{
    [TestClass]
    public class TestDbLayer
    {
        [TestMethod]
        public void AddStudentDbTest()
        {
            bool actualResult = false;
            bool expectedResult = true;

            MdlStudent mdlStudentObj = new MdlStudent(1000 ,"test@test.sk", "password", false, false, 0, 0, false, 0, false, DateTime.Now, "name", "surname", "address", "postCode", "city", "country", "phone");
            DbStudent dbStudentObj = new DbStudent();

            actualResult = dbStudentObj.AddStudent(mdlStudentObj);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddLandlordDbTest()
        {
            bool actualResult = false;
            bool expectedResult = true;

            DbConnection.Open();
            MdlLandlord mdlLandlord = new MdlLandlord(100, "test@test.sk", "password", false, DateTime.Now, "name", "surname", "address", "postCode", "city", "country", "phone");
            DbLandlord dbLandlordObj = new DbLandlord();

            actualResult = dbLandlordObj.AddLandlord(mdlLandlord);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }

    [TestClass]
    public class TestCtrLayer
    {
        [TestMethod]
        public void AddStudentCtrTest()
        {
            bool actualResult = false; 
            bool expectedResult = true;

            ServerController.CtrStudent ctrStudentObj = new CtrStudent();
            actualResult = ctrStudentObj.AddStudent("testCTR@test.sk", "password", false, false, 0, 0, false, 0, false, DateTime.Now, "name", "surname", "address", "postCode", "city", "country", "phone");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddLandlordCtrTest()
        {
            bool actualResult = false;
            bool expectedResult = true;
            string email = "test@testCTR.com";

            ServerController.CtrLandlord ctrStudentObj = new CtrLandlord();
            actualResult = ctrStudentObj.AddLandlord(email, "password", false, DateTime.Now, "name", "surname", "address", "postCode", "city", "country", "phone");
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
