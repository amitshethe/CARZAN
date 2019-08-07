using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using BusinessEntities;
namespace DALUnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            UserEntities e = new UserEntities
            {
                FirstName = "ayush"
            };
            UserDAL d = new UserDAL();
            int res = d.AddUser(e);
            Assert.AreEqual(1, res);
        }
        [TestMethod]
        public void TestMethod2()
        {
            UserEntities e = new UserEntities
            {
                UserID=13
            };
            UserDAL d = new UserDAL();
            int res = d.DeleteUser(e);
            Assert.AreEqual(1, res);
        }
        [TestMethod]
        public void TestMethod3()
        {
            UserEntities e=new UserEntities
            {
                UserID = 6
            };
            UserDAL d = new UserDAL();
            int res = d.UpdateUser(e);
            Assert.AreEqual(1, res);
        }
    }
}
