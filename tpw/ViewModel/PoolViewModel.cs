using Logic;
using Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ViewModel
{
    public class PoolViewModel : ViewModelBase
    {
        public PoolViewModel()
        {
            viewModelBalls = new ObservableCollection<ModelBall>();
            WindowHeight = 640;
            WindowWidth = 1230;
            PoolModel = new PoolModel(WindowWidth, WindowHeight);
            StartCommand = new CommandBase(Start);
            StopCommand = new CommandBase(Stop);
        }

        public ICommand StartCommand { get; set; }
        public ICommand StopCommand { get; set; }

        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                _count = value;
                OnPropertyChanged(nameof(Count));
            }
        }

        private async void Start()
        {
            foreach (AbstractLogicBall logicBall in PoolModel.GetStartingBallPositions(Count))
            {
                ModelBall ball = new ModelBall(logicBall.Position.X, logicBall.Position.Y, logicBall.GetRadius());
                viewModelBalls.Add(ball);
                logicBall.PositionChanged += ball.Update!;
            }
            PoolModel.StartThreads();
            while (PoolModel.Animating)
            {
                await Task.Delay(10);
                Balls = new ObservableCollection<ModelBall>(viewModelBalls);
            }
        }

        private void Stop()
        {
            PoolModel.Animating = false;
            PoolModel.InterruptThreads();
            viewModelBalls.Clear();
        }

        private ObservableCollection<ModelBall> viewModelBalls;
        public ObservableCollection<ModelBall> Balls
        {
            get => viewModelBalls;
            set
            {
                viewModelBalls = value;
                OnPropertyChanged(nameof(Balls));
            }
        }

        public int WindowHeight { get; }
        public int WindowWidth { get; }

        public PoolModel PoolModel { get; set; }
    }
}
