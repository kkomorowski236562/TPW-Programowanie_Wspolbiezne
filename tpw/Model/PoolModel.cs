using Logic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PoolModel
    {
        public PoolModel(double canvasWidth, double canvasHeight, PoolAbstractAPI? poolAPI = null)
        {
            _canvasWidth = canvasWidth;
            _canvasHeight = canvasHeight;
            PoolAPI = poolAPI ?? PoolAbstractAPI.CreateLayer();
        }

        public ObservableCollection<Ball> GetStartingBallPositions(int ballCount)
        {
            Animating = true;
            return PoolAPI.CreateBalls(_canvasWidth, _canvasHeight, ballCount);
        }

        public ObservableCollection<Ball> MoveBall(ObservableCollection<Ball> balls)
        {
            return PoolAPI.UpdateBallsPosition(_canvasWidth, _canvasHeight, balls);
        }

        private bool _animating;

        public bool Animating
        {
            get => _animating; set => _animating = value;
        }

        private readonly double _canvasWidth;

        private readonly double _canvasHeight;

        private readonly PoolAbstractAPI? PoolAPI = default;
    }
}
