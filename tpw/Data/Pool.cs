using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Numerics;
using System.Threading;

namespace Data
{
    internal class Pool
    {
        private readonly object _lock = new();
        private List<AbstractBall> _balls = new();
        private List<Thread> _threads = new();
        private double _poolHeight;
        private double _poolWidth;

        public Pool(int amount, double poolWidth, double poolHeight)
        {
            _poolWidth = poolWidth;
            _poolHeight = poolHeight;
            CreateBalls(amount);
            CreateThreads();
        }

        public void CreateBalls(int amount)
        {
            Random rnd = new();
            for (int i = 0; i < amount; i++)
            {
                int x = rnd.Next(30, (int)_poolWidth - 30);
                int y = rnd.Next(30, (int)_poolHeight - 30);
                while (!CanCreate(x, y))
                {
                    x = rnd.Next(30, (int)_poolWidth - 30);
                    y = rnd.Next(30, (int)_poolHeight - 30);
                }
                _balls.Add(AbstractBall.CreateCircle(new Vector2(x, y)));
            }
        }

        private bool CanCreate(int x, int y)
        {
            if (_balls.Count == 0) return true;
            foreach (var ball in _balls)
            {
                double distance = Math.Sqrt(Math.Pow(ball.Position.X - x, 2) + Math.Pow(ball.Position.Y - y, 2));
                if (distance <= 2 * ball.Radius + 20)
                {
                    return false;
                }
            }
            return true;
        }

        private void CreateThreads()
        {
            foreach (var ball in _balls)
            {
                var thread = new Thread(() =>
                {
                    while (true)
                    {
                        try
                        {
                            lock (_lock)
                            {
                                ball.Update(this, EventArgs.Empty);
                                ball.Move();
                            }
                            Thread.Sleep(15);
                        }
                        catch (ThreadInterruptedException)
                        {
                            break;
                        }
                    }
                });
                _threads.Add(thread);
            }
        }

        public void StartThreads()
        {
            foreach (var thread in _threads)
            {
                thread.Start();
            }
        }

        public void InterruptThreads()
        {
            foreach (var thread in _threads)
            {
                thread.Interrupt();
            }
            _threads.Clear();
        }

        public List<AbstractBall> GetBalls()
        {
            return _balls;
        }

        public double GetPoolHeight()
        {
            return _poolHeight;
        }

        public double GetPoolWidth()
        {
            return _poolWidth;
        }
    }
}
