using System.Diagnostics;

var readStart = Stopwatch.GetTimestamp();
var testInput = File.ReadAllLines("./Input/Day06.test.txt");
var input = File.ReadAllLines("./Input/Day06.txt");
Console.WriteLine($"Read input in ({Stopwatch.GetElapsedTime(readStart)})");

var start = Stopwatch.GetTimestamp();
var result = Day06.Part01(input);
var end = Stopwatch.GetTimestamp();
Console.WriteLine($"Part 1: {result} ({Stopwatch.GetElapsedTime(start, end)})");
start = Stopwatch.GetTimestamp();
var result2 = Day06.Part02(input);
end = Stopwatch.GetTimestamp();
Console.WriteLine($"Part 2: {result2} ({Stopwatch.GetElapsedTime(start, end)})");
