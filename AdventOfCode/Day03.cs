public class Day03
{
    public static string Part01(ReadOnlySpan<char> input)
    {
        var answer = 0L;
        foreach (var range in input.Split('\r'))
        {
            var line = input[range].Trim();
            if (line.Length == 0)
                continue;

            answer += MaxJoltage(line);
        }
        return answer.ToString();
    }

    private static long MaxJoltage(ReadOnlySpan<char> line)
    {
        int max = 0, second = 0;
        for (int i = 0; i < line.Length; i++)
        {
            var val = line[i] - '0';
            if (val > max && i != line.Length - 1)
            {
                max = val;
                second = 0;
            }
            else if (val > second)
            {
                second = val;
            }
        }

        return max * 10 + second;
    }

    public static string Part02(ReadOnlySpan<char> input)
    {
        var answer = 0L;
        foreach (var range in input.Split('\r'))
        {
            var line = input[range].Trim();
            if (line.Length == 0)
                continue;

            answer += MaxJoltage(line, 12);
        }
        return answer.ToString();
    }
    
    private static long MaxJoltage(ReadOnlySpan<char> line, int num)
    {
        if (num <= 0 || num > line.Length)
            return 0;
        
        long max = 0;
        int maxPos = 0;
        
        for (int i = 0; i <= line.Length - num; i++)
        {
            var val = line[i] - '0';
            if (val > max)
            {
                max = val;
                maxPos = i;
            }
        }

        return max * (long)Math.Pow(10, num - 1) + MaxJoltage(line[(maxPos+1)..], num - 1);
    }
}
