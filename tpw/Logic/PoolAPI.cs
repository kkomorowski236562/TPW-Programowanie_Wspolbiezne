using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Logic
{
    public abstract class PoolAbstractAPI
    {
        public static PoolAbstractAPI CreateLayer(DataAbstractAPI? data = default)
        {
            return new PoolAPI(data ?? DataAbstractAPI.CreateAPI());
        }

        public abstract ObservableCollection<AbstractLogicBall> CreateBalls(double poolWidth, double poolHeight, int ballsCount);

        public abstract void InterruptThreads();

        public abstract void StartThreads();

        public abstract void CheckBoundariesCollision(AbstractLogicBall ball);

        public abstract void CheckCollisionsWithCircles(AbstractLogicBall ball);

        private class PoolAPI : PoolAbstractAPI
        {
            public PoolAPI(DataAbstractAPI dataLayer)
            {
                DataLayer = dataLayer;
            }

            public override ObservableCollection<AbstractLogicBall> CreateBalls(double poolWidth, double poolHeight, int ballsCount)
            {
                List<AbstractBall> balls = new();
                ObservableCollection<AbstractLogicBall> logicBalls = new();
                DataLayer.CreatePoolWithBalls(ballsCount, poolWidth, poolHeight);
                height = DataLayer.GetPoolHeight();
                width = DataLayer.GetPoolWidth();
                balls = DataLayer.GetBalls();
                foreach (AbstractBall b in balls)
                {
                    AbstractLogicBall logicBall = AbstractLogicBall.CreateBall(b);
                    b.PositionChanged += logicBall.Update!;
                    ballsCollection.Add(logicBall);
                    logicBalls.Add(logicBall);
                }
                return logicBalls;
            }

            public override void CheckBoundariesCollision(AbstractLogicBall ball)
            {
                UpdateBallSpeed(ball);
            }

            public override void CheckCollisionsWithCircles(AbstractLogicBall ball)
            {
                BallsCollision(ball);
            }

            public override void InterruptThreads()
            {
                DataLayer.InterruptThreads();
                ballsCollection.Clear();
            }

            public override void StartThreads()
            {
                DataLayer.StartThreads();
            }

            private readonly DataAbstractAPI DataLayer;
            private static Collection<AbstractLogicBall> ballsCollection = new();
            private static double height;
            private static double width;

            private static void ChangeXDirection(AbstractLogicBall ball)
            {
                ball.ChangeXDirection();
            }

            private static void ChangeYDirection(AbstractLogicBall ball)
            {
                ball.ChangeYDirection();
            }

            private static void UpdateBallSpeed(AbstractLogicBall ball)
            {
                if (ball.Position.Y - ball.GetRadius() <= 0 || ball.Position.Y + ball.GetRadius() >= height)
                {
                    ChangeYDirection(ball);
                }
                if (ball.Position.X + ball.GetRadius() >= width || ball.Position.X - ball.GetRadius() <= 0)
                {
                    ChangeXDirection(ball);
                }
            }

            private static bool BallsCollision(AbstractLogicBall ball)
            {
                foreach (AbstractLogicBall b in ballsCollection)
                {
                    double distance = Math.Ceiling(Math.Sqrt(Math.Pow((b.Position.X - ball.Position.X), 2) + Math.Pow((b.Position.Y - ball.Position.Y), 2)));
                    if (b != ball && distance <= (b.GetRadius() + ball.GetRadius()) && checkBallBoundary(ball))
                    {
                        ball.ChangeXDirection();
                        ball.ChangeYDirection();
                        return true;
                    }
                }
                return false;
            }

            private static bool checkBallBoundary(AbstractLogicBall ball)
            {
                return ball.Position.Y - ball.GetRadius() <= 0 || ball.Position.X + ball.GetRadius() >= width || ball.Position.Y + ball.GetRadius() >= height || ball.Position.X - ball.GetRadius() <= 0 ? false : true;
            }
        }
    }
}
