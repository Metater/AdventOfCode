namespace AdventOfCode2021.Days;

public class Day14P1 : Day
{
    public Day14P1(string[] input) : base(input)
    {

    }

	private string polymer;
	private List<Rule> rules = new();

    public override void Run()
    {
		polymer = input[0];

		for (int i = 2; i < input.Length; i++)
		{
			string line = input[i];
			rules.Add(new Rule(line[0], line[1], line[6]));
		}

		for (int i = 0; i < 10; i++)
		{
			int c = 0;
			while (c < polymer.Length - 1)
			{
				char a = polymer[c];
				char b = polymer[c + 1];
				foreach (Rule rule in rules)
				{
					if (a == rule.a && b == rule.b)
					{
						polymer = polymer.Insert(c + 1, rule.z.ToString());
						c++;
						break;
					}
				}
				c++;
			}
			//Console.WriteLine($"{i + 1}: {polymer}");
		}

		Dictionary<char, int> occur = new();
		foreach (char c in polymer)
		{
			if (occur.ContainsKey(c))
			{
				occur[c]++;
			}
			else
			{
				occur.Add(c, 1);
			}
		}

		List<int> vals = new(occur.Values);
		vals.Sort();
		Console.WriteLine(vals[vals.Count - 1] - vals[0]);
    }

	public class Rule
	{
		public char a;
		public char b;
		public char z;

		public Rule(char a, char b, char z)
		{
			this.a = a;
			this.b = b;
			this.z = z;
		}
	}
}