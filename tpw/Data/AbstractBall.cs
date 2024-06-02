using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class AbstractBall
    {
        public abstract event PropertyChangedEventHandler? PropertyChanged;
        public int Radius { get; internal set; }
        public Vector2 Position { get; internal set; }
        public Vector2 Speed { get; internal set; }

        internal abstract void Move(Stopwatch timer);
        public abstract void ChangeDirectionX();
        public abstract void ChangeDirectionY();
        public abstract void Update(Object s, PropertyChangedEventArgs e);

        public static AbstractBall CreateBall(Vector2 position)
        {
            return new Ball(position);
        }
    }
}
