using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerDatabase;
using ServerModel;
using ServerController;

namespace UnitTests
{
    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void LoginExistingUserTest()
        {
            bool actualResult = false;
            bool expectedResult = true;

            DbLogin dbLoginObj = new DbLogin();

            actualResult = dbLoginObj.Login("default@default.com", "default");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void LoginNonExistingUserTest()
        {
            bool actualResult = true;
            bool expectedResult = false;

            DbLogin dbLoginObj = new DbLogin();

            actualResult = dbLoginObj.Login("defaultNonExisting@default.com", "default");
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void LoginExistingUserIncorrectPasswordTest()
        {
            bool actualResult = true;
            bool expectedResult = false;

            DbLogin dbLoginObj = new DbLogin();

            actualResult = dbLoginObj.Login("default@default.com", "defaultIncorrect");
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
