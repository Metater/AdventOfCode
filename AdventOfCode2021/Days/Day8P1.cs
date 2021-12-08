namespace AdventOfCode2021.Days;

public class Day8P1 : Day
{
    public Day8P1(string[] input) : base(input)
    {

    }

    public override void Run()
    {
		int occur = 0;
		foreach (string l in input)
		{
			string[] ls = l.Split('|', StringSplitOptions.TrimEntries);
			string[] four = ls[1].Split(' ', StringSplitOptions.TrimEntries);
			for (int i = 0; i < 4; i++)
			{
				int e = four[i].Length;
				if (e == 2 || e == 3 || e == 7 || e == 4)
					occur++;
			}
		}
		Console.WriteLine(occur);
    }
}