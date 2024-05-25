using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal class LogicBall : AbstractLogicBall, INotifyPropertyChanged
    {
        public override event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Vector2 _position;

        internal LogicBall(Data.AbstractBall b)
        {
            ball = b;
        }

        public override Vector2 Postion
        {
            get => _position;
            internal set
            {
                _position = value;
                OnPropertyChanged("Position");
            }
        }

        public override void Update(Object s, PropertyChangedEventArgs e)
        {
            Data.AbstractBall ball = (Data.AbstractBall)s;
            Postion = ball.Position;
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
