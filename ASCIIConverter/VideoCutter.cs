using OpenCvSharp;

namespace ASCIIConverter
{
    public class VideoCutter
    {
        private string _resultFolderPath;
        public string ResultFolderPath 
        { 
            get { return _resultFolderPath; } 
            set
            {
                _resultFolderPath = value;
                _folderClearer = new FolderClearer(value);
            }
        }

        private VideoCapture _capture;
        private FolderClearer _folderClearer;

        public VideoCutter(string videoPath)
        {
            ResultFolderPath = string.Empty;
            _capture = new VideoCapture(videoPath);
            _folderClearer = new FolderClearer();
        }

        public VideoCutter(string videoPath, string resultFolderPath)
        {
            ResultFolderPath = resultFolderPath;
            _capture = new VideoCapture(videoPath);
            _folderClearer = new FolderClearer(ResultFolderPath);
        }

        public void Cut()
        {
            CheckEmptyResultFolderPath();
            using (Mat image = new Mat())
            {
                for (int i = 0; i < _capture.FrameCount; i++)
                {
                    _capture.Read(image);
                    var saveResult = image.SaveImage($@"{ResultFolderPath}\image_{i}.png");
                }
            }
        }

        public void ClearResultFolder() => _folderClearer.ClearResultFolder();

        private void CheckEmptyResultFolderPath()
        {
            if (String.IsNullOrEmpty(ResultFolderPath))
                throw new ArgumentNullException("Result folder path is empty");
        }
    }
}
