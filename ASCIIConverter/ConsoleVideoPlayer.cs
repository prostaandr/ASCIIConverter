using System.Timers;

namespace ASCIIConverter
{
    public class ConsoleVideoPlayer
    {
        public string FolderPath { get; private set; }
        private int _newHeight;
        private int _fps;
        private Queue<string> _framesName = new Queue<string>();
        private Queue<ImageToConvert> _framesImage = new Queue<ImageToConvert>();
        private ConsoleDrawer _consoleDrawer;
        private System.Timers.Timer _drawTimer;
        private Thread _framesImageThread;
        private Thread _drawThread;

        public ConsoleVideoPlayer(string folderPath)
        {
            FolderPath = folderPath;
            _newHeight = 150;
            _fps = 60;
            _consoleDrawer = new ConsoleDrawer();
            _drawTimer = new System.Timers.Timer();
            var deltaTime = TimeSpan.FromSeconds(1) / _fps;
            _drawTimer.Interval = deltaTime.Milliseconds;
        }

        public ConsoleVideoPlayer(string folderPath, int height)
        {
            FolderPath = folderPath;
            _newHeight = height;
            _fps = 60;
            _consoleDrawer = new ConsoleDrawer();
            _drawTimer = new System.Timers.Timer();
            var deltaTime = TimeSpan.FromSeconds(1) / _fps;
            _drawTimer.Interval = deltaTime.Milliseconds;
        }

        public ConsoleVideoPlayer(string folderPath, int height, int fps)
        {
            FolderPath = folderPath;
            _newHeight = height;
            _fps = fps;
            _consoleDrawer = new ConsoleDrawer();
            _drawTimer = new System.Timers.Timer();
            var deltaTime = TimeSpan.FromSeconds(1) / _fps;
            _drawTimer.Interval = deltaTime.Milliseconds;
        }

        private ICollection<string> GetFiles()
        {
            var directoryInfo = new DirectoryInfo(FolderPath);
            var files = directoryInfo.GetFileSystemInfos();
            return files.OrderBy(f => f.CreationTimeUtc).Select(f => f.FullName).Where(f => f.Contains("image_")).ToList();
        }

        public void Play()
        {
            _framesName = new Queue<string>(GetFiles());
            _framesImageThread = new Thread(FillFramesImageQuery);
            _framesImageThread.Start();
            Thread.Sleep(1000);
            _drawThread = new Thread(DrawAllFrames);
            _drawThread.Start();
        }

        private void FillFramesImageQuery()
        {
            while (_framesName.Count > 0)
            {
                var currentImage = _framesName.Dequeue();
                var image = new ImageToConvert(currentImage, _newHeight, _consoleDrawer.PixelAspect);
                _framesImage.Enqueue(image);
            }
        }

        private void DrawAllFrames()
        {
            while (_framesImage.Count > 0)
                DrawFrame();
        }

        private void DrawFrame()
        {
            SetDrawerBuffer();
            _consoleDrawer.Draw();
        }

        private void SetDrawerBuffer()
        {
            var currentImage = _framesImage.Dequeue();
            _consoleDrawer.SetBuffer(currentImage);
        }
    }
}
