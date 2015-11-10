using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerController;
namespace UnitTests
{
    [TestClass]
    class testCtrLandlord
    {
        [TestMethod]
        public void CheckEmailTest()
        {
            CtrLandlord ctrLandlord = new CtrLandlord();
            //should return true
            Assert.IsTrue(ctrLandlord.AddLandlord("miropakanecc@gmail.com", "pass", true, DateTime.Now, "Miro", "Pakanec", "xxx", "fuck", "aalborg", "Denmark", "4546456465"));
        }
    }
}

