using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerController;
using ServerDatabase;
using ServerModel;

namespace UnitTests
{
    [TestClass]
    public class GetUserData
    {
        [TestMethod]
        public void GetStudentData()
        {
            CtrGetData ctrGetDataObj = new CtrGetData();
            Assert.IsNotNull(ctrGetDataObj.GetUserData("default2@default.com"));
        }

        [TestMethod]
        public void GetLandlordData()
        {
            CtrGetData ctrGetDataObj = new CtrGetData();
            Assert.IsNotNull(ctrGetDataObj.GetUserData("default3@default.com"));
        }

        [TestMethod]
        public void GetNonExistingUserData()
        {
            CtrGetData ctrGetDataObj = new CtrGetData();
            object[] array = new Array[19];
            ctrGetDataObj.GetUserData("defaultNonExisting@default.com").CopyTo(array, 0);

            Assert.IsNull(array[0]);
        }
    }
}
