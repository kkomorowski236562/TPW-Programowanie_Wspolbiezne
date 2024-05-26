using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace Data
{
    public abstract class AbstractBall
    {
        public abstract event PropertyChangedEventHandler? PropertyChanged;
        public int Radius { get; internal set; }
        public Vector2 Position { get; internal set; }
        public Vector2 Speed { get; internal set; }

        internal abstract void Move();
        public abstract void ChangeDirectionX();
        public abstract void ChangeDirectionY();

        public static AbstractBall CreateCircle(Vector2 position)
        {
            return new Ball(position);
        }
    }
}
