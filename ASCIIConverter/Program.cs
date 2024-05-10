using ASCIIConverter;
using System.Drawing;

Console.WindowHeight = Console.LargestWindowHeight;
Console.WindowWidth = Console.LargestWindowWidth;

var bitmap = (Bitmap)Image.FromFile(@"C:\Users\prost\source\repos\ASCIIConverter\ASCIIConverter\test.jpg");
var graphics = new ASCIIConverter.Graphics();
graphics.SetBuffer(bitmap, 200);
graphics.Draw();
Console.ReadLine();