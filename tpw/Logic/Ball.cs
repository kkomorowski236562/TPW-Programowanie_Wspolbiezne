using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Ball
    {
        public int Radius { get; }
        public double XPosition { get; set; }
        public double YPosition { get; set; }
        public string Color { get; set; }
        public int XVelocity { get; set; }
        public int YVelocity { get; set; }

        public Ball(int Radius, double XPosition, double YPosition)
        {
            Random rnd = new();
            this.Radius = Radius;
            this.XPosition = XPosition;
            this.YPosition = YPosition;
            this.Color = "#ff0000";
            while (XVelocity == 0)
            {
                XVelocity = rnd.Next(-5, 6);
            }
            while (YVelocity == 0)
            {
                YVelocity = rnd.Next(-5, 6);
            }
        }
    }
}

