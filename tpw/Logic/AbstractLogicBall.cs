using System;
using System.Numerics;

namespace Logic
{
    public abstract class AbstractLogicBall
    {
        public abstract event EventHandler? PositionChanged;
        public abstract Vector2 Position { get; internal set; }

        public abstract void Update(Object s, EventArgs e);

        public abstract void ChangeXDirection();

        public abstract void ChangeYDirection();

        public abstract double GetRadius();

        public static AbstractLogicBall CreateBall(Data.AbstractBall b)
        {
            return new LogicBall(b);
        }
    }
}
