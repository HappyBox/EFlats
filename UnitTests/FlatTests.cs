using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ServerDatabase;
using ServerModel;
using ServerController;

namespace UnitTests
{
    [TestClass]
    public class FlatTests
    {
        [TestMethod]
        public void AddNewFlatCtr()
        {
            bool actualResult = false;
            bool expectedResult = true;

            CtrLandlord ctrLandlordObj = new CtrLandlord();
            actualResult = ctrLandlordObj.AddApartment("default3@default.com", "flat", "address", "zipCode", 2000.0, 6000.0, DateTime.Now, DateTime.Now, "Flat description");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddNewFlatWrongLandlordCtr()
        {
            bool actualResult = true;
            bool expectedResult = false;

            CtrLandlord ctrLandlordObj = new CtrLandlord();
            actualResult = ctrLandlordObj.AddApartment("default3Wrong@default.com", "flat", "address", "zipCode", 2000.0, 6000.0, DateTime.Now, DateTime.Now, "Flat description");

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void AddNewFlatDb()
        {
            bool actualResult = false;
            bool expectedResult = true;

            DbFlat dbFlatObj = new DbFlat();
            MdlFlat mdlFlatObj = new MdlFlat("default3@default.com", "flat", DateTime.Now, DateTime.Now, 2000.0, 6000.0, "address", "zipCode", "Flat description");
            actualResult = dbFlatObj.Add(mdlFlatObj);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DbRecieveListOfFlatTest()
        {
            ServerDatabase.DbFlat dbFlatObj = new ServerDatabase.DbFlat();
            List<MdlFlat> applicationList = dbFlatObj.GetFlats();

            Assert.IsNotNull(applicationList[applicationList.Count - 1].Id);
        }
    }
}
