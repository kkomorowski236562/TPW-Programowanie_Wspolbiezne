using Logic;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class PoolViewModel : ViewModelBase
    {
        public PoolViewModel()
        {
            _balls = new();
            WindowHeight = 640;
            WindowWidth = 1230;
            PoolModel = new PoolModel(WindowWidth, WindowHeight);
            StartCommand = new CommandBase(() => Start());
            StopCommand = new CommandBase(() => Stop());
        }
        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }

        private int _count;
        public int Count
        {
            get { return _count; }
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        private async void Start()
        {
            Balls = PoolModel.GetStartingBallPositions(Count);
            while (PoolModel.Animating)
            {
                await Task.Delay(15);
                Balls = PoolModel.MoveBall(_balls);
            }
        }

        private void Stop()
        {
            PoolModel.Animating = false;
        }

        private ObservableCollection<Ball> _balls;
        public ObservableCollection<Ball> Balls
        {
            get => _balls;
            set
            {
                _balls = value;
                OnPropertyChanged(nameof(Balls));
            }
        }
        public int WindowHeight { get; }
        public int WindowWidth { get; }

        public PoolModel PoolModel { get; set; }
    }
}
