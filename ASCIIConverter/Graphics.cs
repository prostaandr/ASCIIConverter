using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIConverter
{
    public class Graphics
    {
        public float PixelAspect { get; private set; }
        public char[] Buffer { get; private set; }

        private Converter _converter = new Converter();

        public Graphics()
        {
            PixelAspect = 11f / 24f;
            Buffer = new char[0];
        }

        public void ResetCursor()
        {
            Console.SetCursorPosition(0, 0);
        }

        public void SetBuffer(Bitmap bitmap, int newHeight)
        {
            Buffer = _converter.GetBufferFromBitmap(bitmap, newHeight, PixelAspect);
        }

        public void Draw()
        {
            ResetCursor();
            Console.WriteLine(Buffer);
        }
    }
}
