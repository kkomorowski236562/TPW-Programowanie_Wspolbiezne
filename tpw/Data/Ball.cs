using System;
using System.Numerics;

namespace Data
{
    internal class Ball : AbstractBall
    {
        private Vector2 _position;
        private Vector2 _speed;
        private EventHandler? _positionChanged;

        public override event EventHandler? PositionChanged
        {
            add
            {
                _positionChanged += value;
            }
            remove
            {
                _positionChanged -= value;
            }
        }

        internal Ball(Vector2 position)
        {
            Random rnd = new();
            Radius = 15;
            _position = position;
            _speed = new Vector2(rnd.Next(-3, 4), rnd.Next(-3, 4));

            while (_speed.X == 0 || _speed.Y == 0)
            {
                _speed = new Vector2(rnd.Next(-3, 4), rnd.Next(-3, 4));
            }
        }

        public override Vector2 Position
        {
            get => _position;
            internal set
            {
                _position = value;
                _positionChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public override Vector2 Speed
        {
            get => _speed;
            internal set => _speed = value;
        }

        internal override void Move()
        {
            _position += _speed;
            _positionChanged?.Invoke(this, EventArgs.Empty);
        }

        public override void ChangeDirectionX()
        {
            _speed = new Vector2(_speed.X * -1, _speed.Y);
        }

        public override void ChangeDirectionY()
        {
            _speed = new Vector2(_speed.X, _speed.Y * -1);
        }

        public override void Update(object s, EventArgs e)
        {
            Logger.GetInstance().SaveDataAsYaml(new InformationAboutBall(_position.X, _position.Y, _speed.X, _speed.Y, GetHashCode()));
        }
    }
}
