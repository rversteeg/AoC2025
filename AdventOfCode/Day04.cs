public class Day04
{
    public static long Part01(ReadOnlySpan<char> input)
    {
        var field = new Field(input);
        var result = 0;

        (int xOffset, int yOffset)[] offsets = [
            (-1, -1),
            (0, -1),
            (1, -1),
            (-1, 0),
            (1, 0),
            (-1, 1),
            (0, 1),
            (1, 1),
        ];

        for (int x = 0; x < field.Width; x++)
        for (int y = 0; y < field.Height; y++)
        {
            if (field.GetValue(x, y) != '@')
                continue;
            
            var count = 0;
            foreach (var offset in offsets)
            {
                if (field.GetValue(x - offset.xOffset, y - offset.yOffset) == '@')
                    count++;
            }

            if (count < 4)
                ++result;
        }
        
        return result;
    }
    
    public static long Part02(ReadOnlySpan<char> input)
    {
        var field = new Field(input);

        (int xOffset, int yOffset)[] offsets = [
            (-1, -1),
            (0, -1),
            (1, -1),
            (-1, 0),
            (1, 0),
            (-1, 1),
            (0, 1),
            (1, 1),
        ];

        HashSet<(int x, int y)> removed = new HashSet<(int x, int y)>();

        bool removedNew;
        do
        {
            removedNew = false;
            for (int x = 0; x < field.Width; x++)
            for (int y = 0; y < field.Height; y++)
            {
                if (removed.Contains((x,y)) || field.GetValue(x, y) != '@')
                    continue;
                
                var count = 0;
                foreach (var offset in offsets)
                {
                    var index = (x: x - offset.xOffset, y: y - offset.yOffset);
                    if (!removed.Contains(index) && field.GetValue(index.x, index.y) == '@')
                    {
                        count++;
                    }
                }

                if (count < 4)
                {
                    removed.Add((x, y));
                    removedNew = true;
                }
            }
        } while (removedNew);
        
        return removed.Count;
    }

    private readonly ref struct Field(ReadOnlySpan<char> input)
    {
        public readonly int Width = input.IndexOf(Environment.NewLine[0]);
        public readonly int Height = (input.Length+Environment.NewLine.Length) / (input.IndexOf(Environment.NewLine[0]) + Environment.NewLine.Length);
        private readonly ReadOnlySpan<char> _input = input;

        public char GetValue(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
                return '.';

            return _input[x + Width * y + y * Environment.NewLine.Length];
        }
    }
}
