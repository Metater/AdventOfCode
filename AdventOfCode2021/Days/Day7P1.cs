namespace AdventOfCode2021.Days;

public class Day7P1 : Day
{
    public Day7P1(string[] input) : base(input)
    {

    }

    public override void Run()
    {
        string[] strNums = input[0].Split(',');
		int[] nums = new int[strNums.Length];
		int lowest = int.MaxValue;
		int highest = int.MinValue;
		for (int i = 0; i < strNums.Length; i++)
		{
			int num = int.Parse(strNums[i]);
			if (num > highest) highest = num;
			if (num < lowest) lowest = num;
			nums[i] = int.Parse(strNums[i]);
		}
		int moveToPos = lowest;
		int leastFuel = int.MaxValue;
		for (int i = lowest; i <= highest; i++)
		{
			int fuelRequired = 0;
			foreach (int num in nums)
			{
				fuelRequired += Math.Abs(num - i);
			}
			if (fuelRequired < leastFuel)
			{
				moveToPos = i;
				leastFuel = fuelRequired;
			}
		}
		Console.WriteLine($"Least fuel required at {moveToPos} with {leastFuel} spent");

    }
}