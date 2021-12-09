namespace AdventOfCode2021.Days;

public class Day9P1 : Day
{
    public Day9P1(string[] input) : base(input)
    {

    }

	int[,] map;

    public override void Run()
    {
		map = new int[input[0].Length, input.Length];

		for (int y = 0; y < input.Length; y++)
		{
			for (int x = 0; x < input[0].Length; x++)
			{
				map[x, y] = int.Parse(input[y][x].ToString());
			}
		}

		List<int> riskLevels = new List<int>();

		for (int y = 0; y < input.Length; y++)
		{
			for (int x = 0; x < input[0].Length; x++)
			{
				int self = map[x, y];
				//Console.WriteLine($"({x}, {y}): {self}");
				if (TryGet(x, y + 1, out int up) && up <= self)
					continue;
				if (TryGet(x, y - 1, out int down) && down <= self)
					continue;
				if (TryGet(x - 1, y, out int left) && left <= self)
					continue;
				if (TryGet(x + 1, y, out int right) && right <= self)
					continue;
				riskLevels.Add(self + 1);
			}
		}

		int sum = 0;
		foreach (int riskLevel in riskLevels)
		{
			sum += riskLevel;
		}
		Console.WriteLine(sum);
    }

	private bool TryGet(int x, int y, out int val)
	{
		val = 0;
		if (!InRange(x, y)) return false;
		val = map[x, y];
		return true;
	}

	private bool InRange(int x, int y)
	{
		return (x >= 0 && x < input[0].Length) && (y >= 0 && y < input.Length);
	}
}