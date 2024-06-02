using System;
using System.Numerics;

namespace Data
{
    public abstract class AbstractBall
    {
        public abstract event EventHandler? PositionChanged;

        public int Radius { get; internal set; }
        public abstract Vector2 Position { get; internal set; }
        public abstract Vector2 Speed { get; internal set; }

        internal abstract void Move();
        public abstract void ChangeDirectionX();
        public abstract void ChangeDirectionY();
        public abstract void Update(object s, EventArgs e);

        public static AbstractBall CreateCircle(Vector2 position)
        {
            return new Ball(position);
        }
    }
}
