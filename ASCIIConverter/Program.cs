using ASCIIConverter;

Console.WindowHeight = Console.LargestWindowHeight;
Console.WindowWidth = Console.LargestWindowWidth;


//var drawer = new ConsoleDrawer();
//var image = new ImageToConvert(@"C:\Users\prost\source\repos\ASCIIConverter\ASCIIConverter\test\city.jpg", 150, drawer.PixelAspect);
//drawer.SetBuffer(image);
//drawer.Draw();
var videoPath = @"C:\Users\prost\source\repos\ASCIIConverter\ASCIIConverter\test\mario\mario.mp4";
var folderPath = @"C:\Users\prost\source\repos\ASCIIConverter\ASCIIConverter\test";
var cutter = new VideoCutter(videoPath, folderPath);
cutter.Cut();
var player = new ConsoleVideoPlayer(folderPath);
player.Play();

Console.ReadLine();