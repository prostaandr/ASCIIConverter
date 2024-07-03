using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASCIIConverter
{
    public class ConsoleDrawer
    {
        public float PixelAspect { get; private set; }
        public char[] Buffer { get; private set; } 

        private ImageConverter _converter;

        public ConsoleDrawer()
        {
            PixelAspect = 11f / 24f;
            Buffer = new char[0];
            _converter = new ImageConverter();
        }

        public void ResetCursor()
        {
            Console.SetCursorPosition(0, 0);
        }

        public void SetBuffer(ImageToConvert imageToConvert)
        {
            Buffer = _converter.GetBuffer(imageToConvert);
        }

        public void Draw()
        {
            ResetCursor();
            Console.WriteLine(Buffer);
        }
    }
}
