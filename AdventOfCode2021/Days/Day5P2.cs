namespace AdventOfCode2021.Days;

public class Day5P2 : Day
{
    public Day5P2(string[] input) : base(input)
    {

    }

    private List<(int, int, int, int)> lines = new();

    public override void Run()
    {
        foreach (string line in input)
        {
            string[] a = line.Split(' ');
            string[] b = a[0].Split(',');
            string[] c = a[2].Split(',');
            int x1 = int.Parse(b[0]);
            int y1 = int.Parse(b[1]);
            int x2 = int.Parse(c[0]);
            int y2 = int.Parse(c[1]);
            lines.Add((x1, y1, x2, y2));
        }

        foreach (var line in lines)
        {
            Console.WriteLine($"({line.Item1}, {line.Item2}) ({line.Item3}, {line.Item4})");
        }

        int[,] grid = new int[1000, 1000];
        foreach (var line in lines)
        {
            if (line.Item1 == line.Item3) // x1 == x2, vertical line
            {
                int start = Math.Min(line.Item2, line.Item4);
                int end = Math.Max(line.Item2, line.Item4);
                for (int i = start; i <= end; i++)
                {
                    grid[line.Item1, i]++;
                }
            }
            else if (line.Item2 == line.Item4) // y1 == y2, horizontal line
            {
                int start = Math.Min(line.Item1, line.Item3);
                int end = Math.Max(line.Item1, line.Item3);
                for (int i = start; i <= end; i++)
                {
                    grid[i, line.Item2]++;
                }
            }
            else // diagonal
            {
                int rise = Math.Abs(line.Item4 - line.Item2);
                int run = Math.Abs(line.Item3 - line.Item1);
                bool right = line.Item3 > line.Item1;
                bool up = line.Item4 > line.Item2;
                if (right && up) // North East
                {
                    for (int i = 0; i <= rise; i++)
                    {
                        grid[line.Item1 + i, line.Item2 + i]++;
                    }
                }
                else if (right && !up) // South East
                {
                    for (int i = 0; i <= rise; i++)
                    {
                        grid[line.Item1 + i, line.Item2 - i]++;
                    }
                }
                else if (!right && up) // North West
                {
                    for (int i = 0; i <= rise; i++)
                    {
                        grid[line.Item1 - i, line.Item2 + i]++;
                    }
                }
                else // South West
                {
                    for (int i = 0; i <= rise; i++)
                    {
                        grid[line.Item1 - i, line.Item2 - i]++;
                    }
                }
            }
        }

        int moreThan2 = 0;
        for (int y = 0; y < 1000; y++)
        {
            for (int x = 0; x < 1000; x++)
            {
                if (grid[x, y] >= 2) moreThan2++;
            }
        }
        Console.WriteLine($"Points with >= 2 overlaps: {moreThan2}");

    }
}