using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace tpw_test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            tpw.Calculator cal = new tpw.Calculator();
            int result = cal.add(3, 3);
            Assert.AreEqual(6, result);
        }
    }
}
