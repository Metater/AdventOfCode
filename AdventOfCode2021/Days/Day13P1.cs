namespace AdventOfCode2021.Days;

public class Day13P1 : Day
{
    public Day13P1(string[] input) : base(input)
    {

    }

    public override void Run()
    {
        List<(int, int)> points = new();
        int line = 0;
        int maxX = -1;
        int maxY = -1;
        while (input[line] != "")
        {
            string[] split = input[line].Split(',');
            int x = int.Parse(split[0]);
            int y = int.Parse(split[1]);
            if (x > maxX) maxX = x;
            if (y > maxY) maxY = y;
            points.Add((x, y));
            line++;
        }
        maxX++;
        maxY++;
        line++;
        List<Fold> folds = new();
        for (int i = line; i < input.Length; i++)
        {
            string[] split = input[i].Split(' ');
            string[] fold = split[2].Split('=');
            folds.Add(new Fold(fold[0] == "x", int.Parse(fold[1])));
        }



        Console.WriteLine($"Paper Size: ({maxX}, {maxY})");
        for (int y = 0; y < maxY; y++)
        {
            for (int x = 0; x < maxX; x++)
            {
                Console.Write(points.Contains((x, y)) ? "#" : ".");
            }
            Console.WriteLine();
        }
        foreach (Fold fold in folds)
        {
            Console.WriteLine($"Fold X Axis: {!fold.x}, Fold At: {fold.line}");
        }

        List<(int, int)> p1 = new();
        foreach ((int x, int y) in points)
        {

        }
    }

    public struct Fold
    {
        public readonly bool x;
        public readonly int line;

        public Fold(bool x, int line)
        {
            this.x = x;
            this.line = line;
        }

        public bool TryFoldPoint((int, int) point, out (int, int) p1)
        {
            if (x) // Fold y axis
            {

            }
            else // Folding along the x axis
            {

            }
            return (-1, -1);
        }
    }
}