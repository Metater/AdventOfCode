namespace AdventOfCode2021.Days;

public class Day13P2 : Day
{
    public Day13P2(string[] input) : base(input)
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
        //PrintPoints(maxX, maxY, points);
        /*
        foreach (Fold fold in folds)
        {
            Console.WriteLine($"X: {fold.x}, Fold At: {fold.line}");
        }
        */

        List<(int, int)> prime = new();
        foreach (Fold fold in folds)
        {
            foreach ((int, int) point in points)
            {
                if (fold.TryFoldPoint(point, out (int, int) p))
                {
                    prime.Add(p);
                }
            }
            Deduplicate(prime);
            points = new List<(int, int)>(prime);
            prime.Clear();
        }
        PrintPoints(points);
        //Console.WriteLine(prime.Count);
    }

    private void Deduplicate(List<(int, int)> points)
    {
        List<(int, int)> dupes = new();
        List<(int, int)> remove = new();
        foreach ((int, int) point in points)
        {
            if (dupes.Contains(point))
            {
                remove.Add(point);
            }
            dupes.Add(point);
        }
        foreach ((int, int) dupe in remove)
        {
            points.Remove(dupe);
        }
    }

    private static void PrintPoints(List<(int, int)> points)
    {
        int maxX = -1;
        int maxY = -1;
        foreach ((int x, int y) in points)
        {
            if (x > maxX) maxX = x;
            if (y > maxY) maxY = y;
        }
        maxX++;
        maxY++;
        for (int y = 0; y < maxY; y++)
        {
            string line = "";
            for (int x = 0; x < maxX; x++)
            {
                line += points.Contains((x, y)) ? "#" : ".";
            }
            Console.WriteLine(line);
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

        public bool TryFoldPoint((int, int) point, out (int, int) prime)
        {
            prime = (-1, -1);
            if (x) // Fold y axis
            {
                if (point.Item1 == line) return false;
                if (point.Item1 < line)
                {
                    prime = point;
                    return true;
                }
                int x = line - (point.Item1 - line);
                int y = point.Item2;
                prime = (x, y);
                return true;
            }
            else // Folding along the x axis
            {
                if (point.Item2 == line) return false;
                if (point.Item2 < line)
                {
                    prime = point;
                    return true;
                }
                int x = point.Item1;
                int y = line - (point.Item2 - line);
                prime = (x, y);
                return true;
            }
        }
    }
}