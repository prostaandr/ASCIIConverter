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
        private ConsoleDrawer _consoleDrawer;
        private int _newHeight;
        private int _fps;

        public ConsoleVideoPlayer(string folderPath)
        {
            FolderPath = folderPath;
            _consoleDrawer = new ConsoleDrawer();
            _newHeight = 150;
            _fps = 60;
        }

        public ConsoleVideoPlayer(string folderPath, int fps)
        {
            FolderPath = folderPath;
            _consoleDrawer = new ConsoleDrawer();
            _newHeight = 150;
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
