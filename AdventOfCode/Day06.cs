public class Day06
{
    public static long Part01(string[] lines)
    {
        var numbers = lines.SkipLast(1).Select(line=>line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(long.Parse).ToArray()).ToArray();
        var operators = lines[^1].Split(' ', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        return operators.Select((op, x) => Calc(op[0], Enumerable.Range(0, numbers.Length).Select(y => numbers[y][x]))).Sum();
    }

    private static long Calc(char op, IEnumerable<long> values)
    {
        return op switch
        {
            '+' => values.Aggregate((x, y) => x + y),
            '*' => values.Aggregate((x, y) => x * y),
            _ => throw new ArgumentException($"Unknown operator {op}")
        };
    }

    public static long Part02(string[] lines)
    {
        var opIndexes = new List<int>();
        for (int i = 0; i < lines[^1].Length; i++)
        {
            if(lines[^1][i] != ' ')
                opIndexes.Add(i);
        }

        opIndexes.Add(lines[0].Length+1);

        var result = 0L;

        for (int i = 0; i < opIndexes.Count - 1; i++)
        {
            result += Calc(lines[^1][opIndexes[i]], Enumerable.Range(opIndexes[i], opIndexes[i + 1] - opIndexes[i] - 1)
                .Select(x => GetNumberAtPos(lines, x)));
        }

        return result;
    }

    private static long GetNumberAtPos(string[] lines, int pos)
        => Int64.Parse(lines.SkipLast(1).Select(x => x[pos]).ToArray().AsSpan().Trim());
}
