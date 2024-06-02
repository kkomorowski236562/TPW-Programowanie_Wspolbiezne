using System;
using System.Numerics;

namespace Logic
{
    internal class LogicBall : AbstractLogicBall
    {
        public override event EventHandler? PositionChanged;

        private Vector2 _position;

        internal LogicBall(Data.AbstractBall b)
        {
            ball = b;
        }

        public override Vector2 Position
        {
            get => _position;
            internal set
            {
                _position = value;
                PositionChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public override void Update(Object s, EventArgs e)
        {
            Data.AbstractBall ball = (Data.AbstractBall)s;
            Position = ball.Position;
            PoolAbstractAPI.CreateLayer().CheckBoundariesCollision(this);
            PoolAbstractAPI.CreateLayer().CheckCollisionsWithCircles(this);
        }

        private readonly Data.AbstractBall ball;

        public override void ChangeXDirection()
        {
            ball.ChangeDirectionX();
        }

        public override void ChangeYDirection()
        {
            ball.ChangeDirectionY();
        }

        public override double GetRadius()
        {
            return ball.Radius;
        }
    }
}
