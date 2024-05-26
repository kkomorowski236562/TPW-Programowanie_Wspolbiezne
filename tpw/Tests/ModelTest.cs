using Model;

namespace Tests
{
    [TestClass]
    public class ModelTest
    {
        private PoolModel Model = new(1000, 1000);

        [TestMethod]
        public void AnimatingStartTest()
        {
            Assert.AreEqual(Model.Animating, false);
            Model.GetStartingBallPositions(10);
            Assert.AreEqual(Model.Animating, true);
        }

        [TestMethod]
        public void AnimatingFalseTest()
        {
            Assert.AreEqual(Model.Animating, false);
        }
    }
}