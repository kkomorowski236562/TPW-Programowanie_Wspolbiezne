using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class LogicBall : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private double _x;
        public double X
        {
            get => _x;
            set
            {
                _x = value;
                OnPropertyChanged("X");
            }
        }
        private double _y;
        public double Y
        {
            get => _y;
            set
            {
                _y = value;
                OnPropertyChanged("Y");
            }
        }

        public void Update(Object s, PropertyChangedEventArgs e)
        {
            Data.Ball ball = (Data.Ball)s;
            X = this.ball.XPos;
            Y = this.ball.YPos;
            PoolAbstractAPI.CreateLayer().CheckBoundariesCollision(this);
        }


        private readonly Data.Ball ball;

        public LogicBall(Data.Ball c)
        {
            ball = c;
        }

        public void ChangeXDirection()
        {
            ball.ChangeDirectionX();
        }

        public void ChangeYDirection()
        {
            ball.ChangeDirectionY();
        }

        public double GetX()
        {
            return X;
        }

        public double GetY()
        {
            return Y;
        }

        public double GetRadius()
        {
            return ball.Radius;
        }

        public String GetColor()
        {
            return ball.Color;
        }
    }
}