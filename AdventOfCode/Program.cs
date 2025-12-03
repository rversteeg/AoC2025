var testInput = File.ReadAllText("./Input/Day03.test.txt").Trim();
var input = File.ReadAllText("./Input/Day03.txt").Trim();

var result = Day03.Part01(input);
Console.WriteLine(result);
var result2 = Day03.Part02(input);
Console.WriteLine(result2);
