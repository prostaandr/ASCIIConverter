using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIConverter
{
    public class Converter
    {
        public char[] GetBufferFromBitmap(Bitmap bitmap, int newHeight, Graphics graphics)
        {
            bitmap = ResizeBitmap(bitmap, newHeight, graphics.Aspect, graphics.PixelAspect);
            var buffer = new char[bitmap.Width * bitmap.Height];
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    var pixel = bitmap.GetPixel(i, j);
                    if (i == bitmap.Width - 1) buffer[i + j * bitmap.Width] = '\n';
                    else buffer[i + j * bitmap.Width] = GetColorChar(pixel);
                }
            }

            return buffer;
        }

        private Bitmap ResizeBitmap(Bitmap bitmap, int newHeight, float aspect, float pixelAspect)
        {
            return new Bitmap(bitmap, new Size((int)(newHeight * aspect / pixelAspect), newHeight));
        }

        private char GetColorChar(Color pixel)
        {
            if (pixel.R == 255 && pixel.G == 255 && pixel.B == 255) return '*';
            if (pixel.R == 0 && pixel.G == 0 && pixel.B == 0) return ' ';
            return 'E';
        }
    }
}
