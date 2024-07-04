using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIConverter
{
    public class ImageToConvert
    {
        public Bitmap Bitmap { get; private set; }
        private float _aspect;
        private int _newHeight;

        public ImageToConvert(string imagePath, int newHeight, float pixelAspect)
        {
            Bitmap = (Bitmap)Image.FromFile(imagePath);
            _aspect = (float)Bitmap.Width / (float)Bitmap.Height;
            _newHeight = newHeight;
            ResizeBitmapByNewHeight(pixelAspect);
        }

        private void ResizeBitmapByNewHeight(float pixelAspect)
        {
            Bitmap = new Bitmap(Bitmap, new Size((int)(_newHeight * _aspect / pixelAspect), _newHeight));
        }
    }
}