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
        private float aspect;
        private int newHeight;

        public ImageToConvert(string imagePath, int newHeight, float pixelAspect)
        {
            Bitmap = (Bitmap)Image.FromFile(imagePath);
            aspect = (float)Bitmap.Width / (float)Bitmap.Height;
            this.newHeight = newHeight;
            ResizeBitmapByNewHeight(pixelAspect);
        }

        private void ResizeBitmapByNewHeight(float pixelAspect)
        {
            Bitmap = new Bitmap(Bitmap, new Size((int)(newHeight * aspect / pixelAspect), newHeight));
        }
    }
}