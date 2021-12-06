namespace AdventOfCode2021.Days;

public class Day6P1 : Day
{
    public Day6P1(string[] input) : base(input)
    {

    }

	private List<FishGroup> groups = new List<FishGroup>();

    public override void Run()
    {
		string[] initialState = input[0].Split(',');
		int[] initial = new int[initialState.Length];
		for (int i = 0; i < initialState.Length; i++)
		{
			initial[i] = int.Parse(initialState[i]);
		}
		foreach (int i in initial)
		{
			FishGroup g = GetFishGroup(i);
			g.count++;
		}
		for (int i = 0; i < 80; i++)
		{
			int newFish = 0;
			foreach (FishGroup g in groups)
			{
				g.state--;
				if (g.state == -1)
				{
					g.state = 6;
					newFish += g.count;
				}
			}
			FishGroup a = GetFishGroup(8);
			a.count += newFish;
		}
		int sum = 0;
		foreach (FishGroup g in groups)
		{
			sum += g.count;
		}
		Console.WriteLine(sum);
    }

	public FishGroup GetFishGroup(int state)
	{
		foreach (FishGroup g in groups)
		{
			if (g.state == state) return g;
		}
		FishGroup n = new FishGroup(state);
		groups.Add(n);
		return n;
	}

	public class FishGroup
	{
		public int count = 0;
		public int state;

		public FishGroup(int state)
		{
			this.state = state;
		}
	}
}