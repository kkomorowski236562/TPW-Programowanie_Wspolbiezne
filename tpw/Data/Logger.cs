using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Threading;

namespace Data
{
    internal class Logger
    {
        private static Logger? _instance;
        private readonly ConcurrentQueue<InformationAboutBall> _logBuffer;
        private readonly Timer _timer;
        private readonly string _filePath;

        private Logger()
        {
            _logBuffer = new ConcurrentQueue<InformationAboutBall>();
            _filePath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName}/ballData.yaml";
            _timer = new Timer(FlushBuffer, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }
            return _instance;
        }

        public void EnqueueData(InformationAboutBall info)
        {
            _logBuffer.Enqueue(info);
        }

        private void FlushBuffer(object? state)
        {
            if (_logBuffer.IsEmpty)
                return;

            using StreamWriter file = new(_filePath, append: true, encoding: Encoding.UTF8);

            while (_logBuffer.TryDequeue(out InformationAboutBall? info))
            {
                file.Write(info.ToString());
            }
        }
    }
}
