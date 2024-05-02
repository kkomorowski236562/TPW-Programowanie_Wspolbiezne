using Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

namespace Logic
{
    public abstract class PoolAbstractAPI
    {
        public static PoolAbstractAPI CreateLayer(DataAbstractAPI? data = default)
        {
            return new PoolAPI(data ?? DataAbstractAPI.CreateAPI());
        }

        public abstract ObservableCollection<LogicBall> CreateBalls(double poolWidth, double poolHeight, int circleCount);

        public abstract void InterruptThreads();

        public abstract void StartThreads();

        public abstract void CheckBoundariesCollision(LogicBall cirle);

        public abstract void CheckCollisionsWithBalls(LogicBall cirle);

        private class PoolAPI : PoolAbstractAPI
        {
            public PoolAPI(DataAbstractAPI dataLayer)
            {
                DataLayer = dataLayer;
            }

            public override ObservableCollection<LogicBall> CreateBalls(double poolWidth, double poolHeight, int ballCount)
            {
                List<Ball> balls = new();
                ObservableCollection<LogicBall> logicBalls = new();
                DataLayer.CreatePoolWithBalls(ballCount, poolWidth, poolHeight);
                height = DataLayer.GetPoolHeight();
                width = DataLayer.GetPoolWidth();
                balls = DataLayer.GetBalls();
                foreach (Ball c in balls)
                {
                    LogicBall logicBall = new LogicBall(c);
                    c.PropertyChanged += logicBall.Update!;
                    ballsCollection.Add(logicBall);
                    logicBalls.Add(logicBall);
                }
                return logicBalls;
            }

            private static bool BallsCollision(LogicBall ball)
            {
                foreach (LogicBall c in ballsCollection)
                {
                    double distance = Math.Ceiling(Math.Sqrt(Math.Pow((c.GetX() - ball.GetX()), 2) + Math.Pow((c.GetY() - ball.GetY()), 2)));
                    if (c != ball && distance <= (c.GetRadius() + ball.GetRadius()) && checkBallBoundary(ball))
                    {
                        ball.ChangeXDirection();
                        ball.ChangeYDirection();
                        return true;
                    }
                }
                return false;
            }

            public static void UpdateBallSpeed(LogicBall ball)
            {
                if (ball.GetY() - ball.GetRadius() <= 0 || ball.GetY() + ball.GetRadius() >= height)
                {
                    ball.ChangeYDirection();
                }
                if (ball.GetX() + ball.GetRadius() >= width || ball.GetX() - ball.GetRadius() <= 0)
                {
                    ball.ChangeXDirection();
                }
            }

            private static bool checkBallBoundary(LogicBall ball)
            {
                return ball.GetY() - ball.GetRadius() <= 0 || ball.GetX() + ball.GetRadius() >= width || ball.GetY() + ball.GetRadius() >= height || ball.GetX() - ball.GetRadius() <= 0 ? false : true;
            }

            public override void CheckBoundariesCollision(Logic.LogicBall ball)
            {
                UpdateBallSpeed(ball);
            }

            public override void CheckCollisionsWithBalls(Logic.LogicBall cirle)
            {
                BallsCollision(cirle);
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
            private static Collection<LogicBall> ballsCollection = new();
            private static double height;
            private static double width;
        }
    }
}