using ASCIIConverter;

Console.WindowHeight = Console.LargestWindowHeight;
Console.WindowWidth = Console.LargestWindowWidth;


//var drawer = new ConsoleDrawer();
//var image = new ImageToConvert(@"C:\Users\prost\source\repos\ASCIIConverter\ASCIIConverter\test.jpg", 150, drawer.PixelAspect);
//drawer.SetBuffer(image);
//drawer.Draw();
var cutter = new VideoCutter(@"C:\Users\prost\source\repos\ASCIIConverter\ASCIIConverter\test\bad_apple.mp4");
var folderPath = @"C:\Users\prost\source\repos\ASCIIConverter\ASCIIConverter\test";
var player = new ConsoleVideoPlayer(folderPath);
player.Play();

Console.ReadLine();