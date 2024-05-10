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
        public char[] GetBufferFromBitmap(Bitmap bitmap, int newHeight, float pixelAspect)
        {
            float aspect = (float)bitmap.Width / (float)bitmap.Height;
            bitmap = ResizeBitmap(bitmap, newHeight, aspect, pixelAspect);
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
            var possibleChars = new char[] { ' ', '.', '*', '#', '%', '@' };
            return possibleChars[Convert.ToInt32(pixel.GetBrightness() * (possibleChars.Length - 1))];
        }
    }
}
