using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
using Data;

namespace DataTests
{
    [TestClass]
    public class DataTest
    {

        private DataAbstractAPI TestingAPI = DataAbstractAPI.CreateAPI();

        [TestMethod]
        public void CircleCreationTest()
        {
            TestingAPI.CreatePoolWithBalls(10, 1000, 1000);
            Assert.AreEqual(TestingAPI.GetBalls().Count, 10);
        }

        [TestMethod]
        public void GetWidthTest()
        {
            TestingAPI.CreatePoolWithBalls(10, 500, 1000);
            Assert.AreEqual(TestingAPI.GetPoolWidth(), 500);
        }

        [TestMethod]
        public void GetHeightTest()
        {
            TestingAPI.CreatePoolWithBalls(10, 500, 1000);
            Assert.AreEqual(TestingAPI.GetPoolHeight(), 1000);
        }


    }
}