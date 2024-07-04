using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIConverter
{
    public class ImageConverter
    {
        private ImageToConvert _imageToConvert;
        private char[] _buffer;

        public void SetNewImage(ImageToConvert imageToConvert)
        {
            _imageToConvert = imageToConvert;
            var bufferSize = imageToConvert.Bitmap.Width * imageToConvert.Bitmap.Height;
            _buffer = new char[bufferSize];
        }

        public char[] GetBuffer(ImageToConvert imageToConvert)
        {
            SetNewImage(imageToConvert);
            CheckNullImage();
            FillBuffer();
            return _buffer;
        }

        private void FillBuffer()
        {
            var bitmap = _imageToConvert.Bitmap;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    if (i == bitmap.Width - 1) _buffer[i + j * bitmap.Width] = '\n';
                    else _buffer[i + j * bitmap.Width] = GetColorChar(pixel);
                }
            }
        }

        private void CheckNullImage()
        {
            if (_imageToConvert is null) throw new NullReferenceException("Converter Image is null");
        }

        private char GetColorChar(Color pixel)
        {
            var possibleChars = new char[] { ' ', '.', '*', '#', '%', '@' };
            return possibleChars[Convert.ToInt32(pixel.GetBrightness() * (possibleChars.Length - 1))];
        }
    }
}
