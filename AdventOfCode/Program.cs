using System.Diagnostics;

var testInput = File.ReadAllText("./Input/Day05.test.txt").Trim();
var input = File.ReadAllText("./Input/Day05.txt").Trim();

var start = Stopwatch.GetTimestamp();
var result = Day05.Part01(input);
var end = Stopwatch.GetTimestamp();
Console.WriteLine($"Part 1: {result} ({Stopwatch.GetElapsedTime(start, end)}");
start = Stopwatch.GetTimestamp();
var result2 = Day05.Part02(input);
end = Stopwatch.GetTimestamp();
Console.WriteLine($"Part 2: {result2} ({Stopwatch.GetElapsedTime(start, end)}");
