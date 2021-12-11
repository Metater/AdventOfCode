namespace AdventOfCode2021.Days;

public class Day11P2 : Day
{
    public Day11P2(string[] input) : base(input)
    {

    }

    int[,] energyLevels = new int[10, 10];

    public override void Run()
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                energyLevels[x, y] = int.Parse(input[y][x].ToString());
            }
        }

        int step = 1;
        while (!Step())
        {
            step++;
        }
        Console.WriteLine($"All flashed on step {step}");
    }

    private bool Step()
    {
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                energyLevels[x, y]++;
            }
        }
        List<(int, int)> flashed = new();
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                Flash(x, y, flashed);
            }
        }
        int flashes = 0;
        foreach ((int x, int y) in flashed)
        {
            flashes++;
            energyLevels[x, y] = 0;
        }
        return flashed.Count == 100;
    }

    private void Flash(int x, int y, List<(int, int)> flashed)
    {
        if (energyLevels[x, y] <= 9) return;
        foreach (var flash in flashed)
        {
            if (flash.Item1 == x && flash.Item2 == y) return;
        }
        flashed.Add((x, y));

        if (InRange(x, y + 1))
        {
            energyLevels[x, y + 1]++;
            Flash(x, y + 1, flashed);
        }
        if (InRange(x + 1, y + 1))
        {
            energyLevels[x + 1, y + 1]++;
            Flash(x + 1, y + 1, flashed);
        }
        if (InRange(x + 1, y))
        {
            energyLevels[x + 1, y]++;
            Flash(x + 1, y, flashed);
        }
        if (InRange(x + 1, y - 1))
        {
            energyLevels[x + 1, y - 1]++;
            Flash(x + 1, y - 1, flashed);
        }
        if (InRange(x, y - 1))
        {
            energyLevels[x, y - 1]++;
            Flash(x, y - 1, flashed);
        }
        if (InRange(x - 1, y - 1))
        {
            energyLevels[x - 1, y - 1]++;
            Flash(x - 1, y - 1, flashed);
        }
        if (InRange(x - 1, y))
        {
            energyLevels[x - 1, y]++;
            Flash(x - 1, y, flashed);
        }
        if (InRange(x - 1, y + 1))
        {
            energyLevels[x - 1, y + 1]++;
            Flash(x - 1, y + 1, flashed);
        }
    }

    private bool InRange(int x, int y)
    {
        return x >= 0 && x <= 9 && y >= 0 && y <= 9;
    }
}