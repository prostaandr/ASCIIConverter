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
        public char[] GetBufferFromBitmap(Bitmap bitmap)
        {
            bitmap = ResizeBitmap(bitmap);
            var buffer = new char[bitmap.Width * bitmap.Height];
            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    var pixel = bitmap.GetPixel(x, y);
                    if (x == bitmap.Width - 1) buffer[x + y * bitmap.Width] = '\n';
                    else buffer[x + y * bitmap.Width] = GetColorChar(pixel);
                }
            }

            return buffer;
        }

        private Bitmap ResizeBitmap(Bitmap bitmap)
        {
            var newHeight = bitmap.Height / 1 * 200 / bitmap.Width;
            if (bitmap.Width > 200 || bitmap.Height > newHeight)
                bitmap = new Bitmap(bitmap, new Size(200 * 2, (int)newHeight));
            return bitmap;
        }

        private char GetColorChar(Color pixel)
        {
            if (pixel.R == 255 && pixel.G == 255 && pixel.R == 255) return '*';
            if (pixel.R == 0 && pixel.G == 0 && pixel.R == 0) return ' ';
            return 'E';
        }
    }
}
