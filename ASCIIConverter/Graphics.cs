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
        public int Width { get; private set; }
        public int Height { get; private set; }
        public char[] Buffer { get; private set; }

        public Graphics(int width, int height)
        {
            Width = width;
            Height = height;
            Buffer = new char[width * width / height * height];
        }

        public void ResetCursor()
        {
            Console.SetCursorPosition(0, 0);
        }

        public void Reset()
        {
            ResetCursor();
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Buffer[x + y * Width] = ' ';
                }
            }
        }

        public void SetBuffer(char[] buffer)
        {
            Buffer = buffer;
        }

        public void Draw()
        {
            ResetCursor();
            Console.WriteLine(Buffer);
        }
    }
}
