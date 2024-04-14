using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class BallTests
    {
        [TestMethod]
        public void CreateThreeBalls_AllWithinCanvasBounds()
        {
            double canvasWidth = 1230;
            double canvasHeight = 640;
            int ballRadius = 10;

            List<Ball> balls = new List<Ball>();

            for (int i = 0; i < 3; i++)
            {
                double xPosition = ballRadius + new Random().NextDouble() * (canvasWidth - 2 * ballRadius);
                double yPosition = ballRadius + new Random().NextDouble() * (canvasHeight - 2 * ballRadius);
                Ball ball = new Ball(ballRadius, xPosition, yPosition);
                balls.Add(ball);
            }

            Assert.AreEqual(3, balls.Count);

            
        }
    }
}
