using ASCIIConverter;
using System.Drawing;

Console.WindowHeight = Console.LargestWindowHeight;
Console.WindowWidth = Console.LargestWindowWidth;

var bitmap = (Bitmap)Image.FromFile(@"C:\Users\prost\source\repos\ASCIIConverter\ASCIIConverter\test.jpg");
var converter = new Converter();
var graphics = new ASCIIConverter.Graphics(bitmap.Width, bitmap.Height);
graphics.SetBuffer(converter.GetBufferFromBitmap(bitmap, 150, graphics));
graphics.Draw();
Console.ReadLine();