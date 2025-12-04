var testInput = File.ReadAllText("./Input/Day04.test.txt").Trim();
var input = File.ReadAllText("./Input/Day04.txt").Trim();

var result = Day04.Part01(input);
Console.WriteLine(result);
var result2 = Day04.Part02(input);
Console.WriteLine(result2);
