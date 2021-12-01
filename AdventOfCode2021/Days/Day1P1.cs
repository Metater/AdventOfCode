namespace AdventOfCode2021.Days;

public class Day1P1 : Day
{
    public Day1P1(string[] input) : base(input)
    {

    }

    public override void Run()
    {
        int increases = 0;

        int last = int.MinValue;
        foreach (string measurement in input)
        {
            int m = int.Parse(measurement);
            if (last != int.MinValue)
            {
                if (last < m) increases++;
            }
            last = m;
        }

        Console.WriteLine(increases);
    }
}