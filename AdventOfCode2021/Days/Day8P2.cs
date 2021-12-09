namespace AdventOfCode2021.Days;

public class Day8P2 : Day
{
	public Day8P2(string[] input) : base(input)
	{

	}

	public override void Run()
	{
		int sum = 0;
		foreach (string line in input)
		{
			sum += GetDisplayValue(line);
		}
		Console.WriteLine("Display Sum: " + sum);
	}

	public int GetDisplayValue(string line)
	{
		Dictionary<string, int> segmentValues = new();

		string[] patternsAndOutputs = line.Split('|', StringSplitOptions.TrimEntries);
		string[] patterns = patternsAndOutputs[0].Split(' ', StringSplitOptions.TrimEntries);
		string[] outputs = patternsAndOutputs[1].Split(' ', StringSplitOptions.TrimEntries);

		string one = "";
		string seven = "";

		foreach (string p in patterns)
		{
			if (p.Length == 2)
            {
				one = p;
				segmentValues.Add(p, 1);
			}
			else if (p.Length == 3)
            {
				seven = p;
				segmentValues.Add(p, 7);
			}
			else if (p.Length == 4)
            {
				segmentValues.Add(p, 4);
			}
			else if (p.Length == 7)
            {
				segmentValues.Add(p, 8);
			}

		}

		char s1 = ' ';
        for (int i = 0; i < 3; i++)
        {
			if (!one.Contains(seven[i]))
				s1 = seven[i];
        }

		char s3 = ' ';
		string six = "";
		List<string> zeroNine = new List<string>();
		foreach (string p in patterns)
        {
			if (p.Length != 6) continue;
			zeroNine.Add(p);
			// either 0, 6, 9
			if (!p.Contains(one[0]))
            {
				segmentValues.Add(p, 6);
				s3 = one[0];
				six = p;
			}
			if (!p.Contains(one[1]))
			{
				segmentValues.Add(p, 6);
				s3 = one[1];
				six = p;
			}
		}

		zeroNine.Remove(six);

		Console.WriteLine(six);

		char s6 = one.Replace(s3, ' ').Trim()[0];

		// 4 3 diff

		// 3, 2, 5 out of them, only 3 has full back bar, use that, then 4-3 diff

		string two = "";
		string three = "";
		string five = "";

		foreach (string p in patterns)
        {
			if (p.Length != 5) continue;
			// is 3, 2, 5
			if (!p.Contains(s3))
            {
				five = p;
				segmentValues.Add(p, 5);
            }
			else if (!p.Contains(s6))
            {
				two = p;
				segmentValues.Add(p, 2);
            }
			else
            {
				three = p;
				segmentValues.Add(p, 3);
			}
        }

		// total decoded
		// 1, 2, 3, 4, 5, 6, 7, 8

		// missing
		// 0, 9

		// find s4


		List<char> threeL = new List<char>();
		foreach (char c in three)
			threeL.Add(c);

		threeL.Remove(s1);
		threeL.Remove(s3);
		threeL.Remove(s6);

		// s4, s7 in list

		// 9 will have s4, s7 0 will not have both
		string zero = "";
		foreach (string zn in zeroNine)
        {
			foreach (char s4s7 in threeL)
            {
				if (!zn.Contains(s4s7))
                {
					zero = zn;
                }
            }
        }

		zeroNine.Remove(zero);
		string nine = zeroNine[0];

		segmentValues.Add(zero, 0);

		Console.WriteLine("S:" + six);
		Console.WriteLine("N:" + nine);

		segmentValues.Add(nine, 9);


		// 3-0,9 diff later

		Console.WriteLine("2: " + two);
		Console.WriteLine("3: " + three);
		Console.WriteLine("5: " + five);


		string strNum = "";
		foreach (string ssd in outputs)
        {
			foreach (var kvp in segmentValues)
            {
				if (ContainsAll(ssd, kvp.Key))
                {
					strNum += kvp.Value.ToString();
					break;
                }
			}
        }
		return int.Parse(strNum);
	}

	private static bool ContainsAll(string a, string b)
    {
		if (a.Length != b.Length) return false;
		foreach (char c in a)
        {
			if (!b.Contains(c)) return false;
        }
		return true;
    }
}