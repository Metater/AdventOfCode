namespace AdventOfCode2021.Days;

public class Day9P2 : Day
{
    public Day9P2(string[] input) : base(input)
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

		List<(int, int)> lowPoints = new List<(int, int)>();

		for (int y = 0; y < input.Length; y++)
		{
			for (int x = 0; x < input[0].Length; x++)
			{
				int self = map[x, y];
				if (TryGet(x, y + 1, out int up) && up <= self)
					continue;
				if (TryGet(x, y - 1, out int down) && down <= self)
					continue;
				if (TryGet(x - 1, y, out int left) && left <= self)
					continue;
				if (TryGet(x + 1, y, out int right) && right <= self)
					continue;
				lowPoints.Add((x, y));
			}
		}

		List<int> basinSizes = new List<int>();
		foreach ((int, int) lowPoint in lowPoints)
		{
			//Console.WriteLine($"Searching Basin {basinSizes.Count}");
			InitiateRecursiveSearch(lowPoint);
			basinSizes.Add(basinCells.Count);
		}
		basinSizes.Sort();

		Console.WriteLine(basinSizes[basinSizes.Count-3] * basinSizes[basinSizes.Count-2] * basinSizes[basinSizes.Count-1]);
    }

	private List<(int, int)> searchedCells = new List<(int, int)>();
	private List<(int, int)> basinCells = new List<(int, int)>();

	private void InitiateRecursiveSearch((int, int) lowPoint)
	{
		searchedCells.Clear();
		basinCells.Clear();
		SearchBasinCells(lowPoint);
	}

	private void SearchBasinCells((int, int) search)
	{
		foreach ((int, int) searchedCell in searchedCells)
		{
			if (searchedCell.Item1 == search.Item1 && searchedCell.Item2 == search.Item2) return;
		}
		searchedCells.Add(search);
		if (map[search.Item1, search.Item2] != 9)
			basinCells.Add(search);
		else
			return;

		//Console.WriteLine($"Searching ({search.Item1}, {search.Item2}): {map[search.Item1, search.Item2]}");

		if (InRange(search.Item1, search.Item2 + 1)) // up
		{
			SearchBasinCells((search.Item1, search.Item2 + 1));
		}
		if (InRange(search.Item1, search.Item2 - 1)) // down
		{
			SearchBasinCells((search.Item1, search.Item2 - 1));
		}
		if (InRange(search.Item1 - 1, search.Item2)) // left
		{
			SearchBasinCells((search.Item1 - 1, search.Item2));
		}
		if (InRange(search.Item1 + 1, search.Item2)) // right
		{
			SearchBasinCells((search.Item1 + 1, search.Item2));
		}
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