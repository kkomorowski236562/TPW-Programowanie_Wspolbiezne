using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;

namespace Logic
{
    public abstract class AbstractLogicBall
    {
        public abstract event PropertyChangedEventHandler? PropertyChanged;
        public abstract Vector2 Postion { get; internal set; }

        public abstract void Update(Object s, PropertyChangedEventArgs e);

        public abstract void ChangeXDirection();

        public abstract void ChangeYDirection();

        public abstract double GetRadius();

        public static AbstractLogicBall CreateBall(Data.AbstractBall b)
        {
            return new LogicBall(b);
        }
    }
}
