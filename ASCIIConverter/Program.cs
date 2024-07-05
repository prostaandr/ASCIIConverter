using ASCIIConverter;

Console.WindowHeight = Console.LargestWindowHeight;
Console.WindowWidth = Console.LargestWindowWidth;

var videoPath = @"C:\Users\prost\source\repos\ASCIIConverter\ASCIIConverter\test\bad_apple\bad_apple.mp4";
var folderPath = @"C:\Users\prost\source\repos\ASCIIConverter\ASCIIConverter\test\bad_apple";
var cutter = new VideoCutter(videoPath, folderPath);
var player = new ConsoleVideoPlayer(folderPath, 150);

player.Play();

Console.ReadLine();