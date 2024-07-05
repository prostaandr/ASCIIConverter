using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIConverter
{
    public class ConsoleVideoPlayer
    {
        public string FolderPath { get; private set; }
        private int _newHeight;
        private int _fps;
        private ConsoleDrawer _consoleDrawer;

        public ConsoleVideoPlayer(string folderPath)
        {
            FolderPath = folderPath;
            _newHeight = 150;
            _fps = 60;
            _consoleDrawer = new ConsoleDrawer();
        }

        public ConsoleVideoPlayer(string folderPath, int height)
        {
            FolderPath = folderPath;
            _newHeight = height;
            _fps = 60;
            _consoleDrawer = new ConsoleDrawer();
        }

        public ConsoleVideoPlayer(string folderPath, int height, int fps)
        {
            FolderPath = folderPath;
            _consoleDrawer = new ConsoleDrawer();
            _newHeight = height;
            _fps = fps;
        }

        public void Play()
        {
            var files = GetFiles();
            foreach (var file in files)
            {
                DrawFrame(file);
            }
        }

        private void DrawFrame(string file)
        {
            var image = new ImageToConvert(file, _newHeight, _consoleDrawer.PixelAspect);
            _consoleDrawer.SetBuffer(image);
            _consoleDrawer.Draw();
        }

        private ICollection<string> GetFiles()
        {
            var directoryInfo = new DirectoryInfo(FolderPath);
            var files = directoryInfo.GetFileSystemInfos();
            return files.OrderBy(f => f.CreationTimeUtc).Select(f => f.FullName).Where(f => f.Contains("image_")).ToList();
        }
    }
}
