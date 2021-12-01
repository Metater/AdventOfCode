namespace AdventOfCode2021.Days;

public class Day1P2 : Day
{
    public Day1P2(string[] input) : base(input)
    {

    }

    public override void Run()
    {
        int increases = 0;

        int last = int.MinValue;
        for (int i = 0; i < input.Length; i++)
        {
            int winSum = GetWindowSum(i);
            if (last != int.MinValue)
            {
                if (last < winSum) increases++;
            }
            last = winSum;
        }

        Console.WriteLine(increases);
    }

    private int GetWindowSum(int index)
    {
        int sum = 0;
        if (TryGet(index, out int m1))
        {
            sum += m1;
            if (TryGet(index + 1, out int m2))
            {
                sum += m2;
                if (TryGet(index + 2, out int m3))
                {
                    sum += m3;
                }
            }
        }
        return sum;
    }

    private bool TryGet(int index, out int m)
    {
        m = -1;
        if (index >= input.Length) return false;
        m = int.Parse(input[index]);
        return true;
    }
}