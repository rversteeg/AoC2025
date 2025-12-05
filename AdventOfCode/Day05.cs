public class Day05
{
    private static readonly string Seperator = $"{Environment.NewLine}{Environment.NewLine}";
    public static long Part01(ReadOnlySpan<char> input)
    {
        var splitAt = input.IndexOf(Seperator);
        var ranges = ParseRanges(input.Slice(0, splitAt)).OrderBy(x=>x.From).ThenByDescending(x=>x.To).ToList();
        var ingredients = ParseIngredients(input.Slice(splitAt + Seperator.Length)).Order().ToList();

        var curRange = 0;
        var answer = 0L;

        foreach (var ingredient in ingredients)
        {
            while (ranges[curRange].To < ingredient)
            {
                curRange++;
                if (curRange >= ranges.Count)
                    return answer;
            }
            
            if (ranges[curRange].From <= ingredient)
                answer++;
        }

        return answer;
    }

    private static bool IsInRange(long ingredient, (long From, long To) range) => ingredient >= range.From && ingredient <= range.To;

    private static List<(long From,long To)> ParseRanges(ReadOnlySpan<char> text)
    {
        var result =  new List<(long, long)>();
        foreach(var line in text.Split(Environment.NewLine))
        {
            var splitAt = text[line].IndexOf('-');
            var left = Int64.Parse(text[line].Slice(0, splitAt));
            var right = Int64.Parse(text[line].Slice(splitAt+1));
            result.Add((left, right));
        }
        return result;
    }
    
    private static List<long> ParseIngredients(ReadOnlySpan<char> text)
    {
        var result =  new List<long>();
        foreach(var line in text.Split(Environment.NewLine))
        {
            result.Add(Int64.Parse(text[line]));
        }

        return result;
    }

    public static long Part02(ReadOnlySpan<char> input)
    {
        var splitAt = input.IndexOf(Seperator);
        var ranges = ParseRanges(input.Slice(0, splitAt))
            .OrderBy(x=>x.From);

        var count = 0L;
        var prev = 0L;

        foreach (var range in ranges)
        {
            if (range.To <= prev)
                continue;
            
            count += range.To - Math.Max(prev+1, range.From) + 1;
            prev = range.To;
        }

        return count;
    }
}
