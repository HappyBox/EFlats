using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerDatabase;


namespace UnitTests
{
    [TestClass]
    public class testDbCheckEmailExists
    {
        [TestMethod]
        public void CheckEmailtest()
        {
            DbCheckEmailExists emailCheck = new DbCheckEmailExists();
            //should return true
            Assert.IsTrue(emailCheck.checkEmailExists("miropakanec1@gmail.com"));
            //to pass the test false is changed to true
            Assert.IsTrue(!emailCheck.checkEmailExists("karolisx4@gmail.com"));
        }
    }
}
