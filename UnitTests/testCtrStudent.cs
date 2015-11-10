using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServerController;
namespace UnitTests
{
    [TestClass]
    class testCtrStudent
    {
        [TestMethod]
        public void CheckEmailTest()
        {
            CtrStudent ctrStudent = new CtrStudent();
            //should return true
            Assert.IsTrue(ctrStudent.AddStudent("miropakanecc@gmail.com", "pass", true, true, 100, 20, false, 25, false, DateTime.Now, "Miro", "Pakanec", "xxx", "fuck", "aalborg", "Denmark", "4546456465"));
        }
    }
}

