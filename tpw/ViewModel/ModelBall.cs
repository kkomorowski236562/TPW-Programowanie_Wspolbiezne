using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace ViewModel
{
    public class ModelBall : ViewModelBase
    {
        public float X => Position.X;
        public float Y => Position.Y;

        public Vector2 Position { get; internal set; }

        public double Radius { get; internal set; }

        public String Color { get; internal set; }

        public ModelBall(double x, double y, double radius)
        {
            Random rnd = new();
            this.Position = new Vector2((float)x, (float)y);
            this.Radius = radius;
            this.Color = String.Format("#{0:X6}", rnd.Next(0x1000000));
        }

        public void Update(object s, EventArgs e)
        {
            Logic.AbstractLogicBall ball = (Logic.AbstractLogicBall)s;
            this.Position = ball.Position;
            OnPropertyChanged(nameof(X));
            OnPropertyChanged(nameof(Y));
        }
    }
}
