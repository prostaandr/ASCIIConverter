using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIConverter
{
    public class VideoCutter
    {
        private VideoCapture _capture;

        public VideoCutter(string videoPath)
        {
            _capture = new VideoCapture(videoPath);
        }

        public void Cut(string resultFolderPath)
        {
            ClearResultFolder(resultFolderPath);
            using (Mat image = new Mat())
            {
                for (int i = 0; i < _capture.FrameCount; i++)
                {
                    _capture.Read(image);
                    var saveResult = image.SaveImage($@"{resultFolderPath}\image_{i}.png");
                }
            }
        }

        private void ClearResultFolder(string resultFolderPath)
        {
            var files = Directory.GetFiles(resultFolderPath);
            foreach (var file in files) 
                if (file.EndsWith("png")) File.Delete(file);
        }
    }
}
