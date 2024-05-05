using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Data
{
    public class Ball : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Radius { get; }
        public double XPos { get; private set; }
        public double YPos { get; private set; }
        public string Color { get; private set; }
        public int XVelocity { private get; set; }
        public int YVelocity { private get; set; }

        public double Mass { get; private set; }

        public Thread Thread { get; set; }

        internal Ball(double XPos, double YPos)
        {
            Random rnd = new();
            this.Radius = 15;
            this.XPos = XPos;
            this.YPos = YPos;
            this.Color = String.Format("#{0:X6}", rnd.Next(0x1000000));
            this.Mass = 5.0;
            while (XVelocity == 0)
            {
                XVelocity = rnd.Next(-3, 4);
            }
            while (YVelocity == 0)
            {
                YVelocity = rnd.Next(-3, 4);
            }
        }

        public void Move()
        {
            this.XPos += this.XVelocity;
            this.YPos += this.YVelocity;
            OnPropertyChanged("Move");
        }

        public void ChangeDirectionX()
        {
            this.XVelocity *= -1;
        }

        public void ChangeDirectionY()
        {
            this.YVelocity *= -1;
        }
    }
}

