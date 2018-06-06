using System;
using DataBaseAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataBaseAccessTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            DataBase dataBase = new DataBase("animal", "localhost", "root");
            bool[] test = dataBase.ConnectionTest();
            Assert.IsTrue(test[0]);
            Assert.IsTrue(test[1]);
        }
    }
}
