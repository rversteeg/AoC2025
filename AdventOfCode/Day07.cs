public class Day07
{
    public static long Part01(string[] lines)
    {
        var stack = new Queue<(int X, int Y)>();
       
        stack.Enqueue((lines[0].IndexOf('S'), 0));
        var splits = new HashSet<(int X, int Y)>();

        while (stack.Count > 0)
        {
            var curPos = stack.Dequeue();

            do
            {
                curPos = curPos with{ Y = curPos.Y + 1 };
                if (lines[curPos.Y][curPos.X] == '^')
                {
                    if (!splits.Add(curPos))
                        break;

                    stack.Enqueue(curPos with{ X = curPos.X + 1 } );
                    curPos = curPos with{ X = curPos.X - 1 };
                }
            } while (curPos.Y < lines.Length - 1);
        }
        
        return splits.Count;
    }
    
    public static long Part02(string[] lines)
    {
        return NrOfTimeLines((lines[0].IndexOf('S'), 0), lines);
    }

    private static long NrOfTimeLines((int X, int Y) curPos, string[] lines)
    {
        do
        {
            curPos = curPos with{ Y = curPos.Y + 1 };
            if (lines[curPos.Y][curPos.X] == '^')
            {
                return NrOfTimeLinesFromManifold(curPos, lines);
            }
        } while (curPos.Y < lines.Length - 1);
        
        return 1;
    }
    
    private static readonly Dictionary<(int X, int Y), long> MementoCache = new();

    private static long NrOfTimeLinesFromManifold((int X, int Y) curPos, string[] lines)
    {
        if (MementoCache.TryGetValue(curPos, out var val))
            return val;

        var result = NrOfTimeLines(curPos with{ X = curPos.X + 1}, lines) + NrOfTimeLines(curPos with{ X = curPos.X - 1}, lines);
        MementoCache[curPos] = result;
        return result;
    }
}
