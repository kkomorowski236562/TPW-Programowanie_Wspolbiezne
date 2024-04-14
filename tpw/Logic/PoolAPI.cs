using Data;
using System;
using System.Collections.ObjectModel;

namespace Logic
{
    public abstract class PoolAbstractAPI
    {
        public static PoolAbstractAPI CreateLayer(DataAbstractAPI? data = default)
        {
            return new PoolAPI(data ?? DataAbstractAPI.CreateAPI());
        }

        public abstract ObservableCollection<Ball> CreateBalls(double poolWidth, double poolHeight, int ballsCount);
        public abstract ObservableCollection<Ball> UpdateBallsPosition(double poolWidth, double poolHeight, ObservableCollection<Ball> balls);

        private class PoolAPI : PoolAbstractAPI
        {
            public PoolAPI(DataAbstractAPI dataLayer)
            {
                DataLayer = dataLayer;
            }

            public override ObservableCollection<Ball> CreateBalls(double poolWidth, double poolHeight, int ballsCount)
            {
                ObservableCollection<Ball> balls = new();
                Random rnd = new();
                for (int i = 0; i < ballsCount; i++)
                {
                    Ball ball = new(10, rnd.Next(20, (int)poolWidth - 20), rnd.Next(20, (int)poolHeight - 20));
                    balls.Add(ball);
                }
                return balls;
            }

            public override ObservableCollection<Ball> UpdateBallsPosition(double poolWidth, double poolHeight, ObservableCollection<Ball> balls)
            {
                ObservableCollection<Ball> newBalls = new();
                foreach (Ball ball in balls)
                {
                    if (ball.XPosition + ball.Radius + 1 > poolWidth || ball.XPosition - ball.Radius - 1 < 0) ball.XVelocity *= -1;
                    if (ball.YPosition + ball.Radius + 1 > poolHeight || ball.YPosition - ball.Radius - 1 < 0) ball.YVelocity *= -1;
                    ball.XPosition += ball.XVelocity;
                    ball.YPosition += ball.YVelocity;
                    newBalls.Add(ball);
                }
                return newBalls;
            }

            private readonly DataAbstractAPI DataLayer;
        }
    }
}
