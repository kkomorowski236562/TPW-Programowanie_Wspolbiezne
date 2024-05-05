using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class DataTest
    {
        private DataAbstractAPI TestingAPI = DataAbstractAPI.CreateAPI();

        [TestMethod]
        public void BallCreationTest()
        {
            TestingAPI.CreatePoolWithBalls(10, 1000, 1000);
            var balls = TestingAPI.GetBalls();
            Assert.AreEqual(10, balls.Count, "Niepowodzenie.");
        }

        [TestMethod]
        public void PoolWidthTest()
        {
            TestingAPI.CreatePoolWithBalls(10, 500, 1000);
            Assert.AreEqual(500, TestingAPI.GetPoolWidth(), "Niepowodzenie.");
        }

        [TestMethod]
        public void PoolHeightTest()
        {
            TestingAPI.CreatePoolWithBalls(10, 500, 1000);
            Assert.AreEqual(1000, TestingAPI.GetPoolHeight(), "Niepowodzenie.");
        }

        [TestMethod]
        public void BallPositionTest()
        {
            TestingAPI.CreatePoolWithBalls(1, 1000, 1000);
            var ball = TestingAPI.GetBalls().First();
            bool isWithinBounds = ball.XPos >= 30 && ball.XPos <= 970 && ball.YPos >= 30 && ball.YPos <= 970;
            Assert.IsTrue(isWithinBounds, "Niepowodzenie.");
        }

    }
}