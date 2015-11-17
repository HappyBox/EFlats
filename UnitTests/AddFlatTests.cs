using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerDatabase;
using ServerModel;
using ServerController;

namespace UnitTests
{
    [TestClass]
    public class AddFlatTests
    {
        [TestMethod]
        public void AddNewFlatCtr()
        {
            bool actualResult = false;
            bool expectedResult = true;

            CtrLandlord ctrLandlordObj = new CtrLandlord();
            actualResult = ctrLandlordObj.AddApartment("default3@default.com", "flat", "address", "zipCode", 2000.0, 6000.0, DateTime.Now, DateTime.Now);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddNewFlatWrongLandlordCtr()
        {
            bool actualResult = true;
            bool expectedResult = false;

            CtrLandlord ctrLandlordObj = new CtrLandlord();
            actualResult = ctrLandlordObj.AddApartment("default3Wrong@default.com", "flat", "address", "zipCode", 2000.0, 6000.0, DateTime.Now, DateTime.Now);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddNewFlatDb()
        {
            bool actualResult = false;
            bool expectedResult = true;

            DbFlat dbFlatObj = new DbFlat();
            MdlFlat mdlFlatObj = new MdlFlat("default3@default.com", "flat", DateTime.Now, DateTime.Now, 2000.0, 6000.0, "address", "zipCode");
            actualResult = dbFlatObj.Add(mdlFlatObj);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
