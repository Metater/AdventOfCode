namespace AdventOfCode2021.Days;

public class Day3P2 : Day
{

    public Day3P2(string[] input) : base(input)
    {

    }

    public override void Run()
    {
    }

    private int GetOxygenGeneratorRating()
    {
        List<string> l = new List<string>(input);
        List<string> temp = new List<string>();
        for (int i = 0; i < input[0].Length; i++)
        {
            foreach (string line in l)
            {
                (int, int) zo = GetZerosOnes(l, i);
                if (zo.Item1 < zo.Item2) temp.Add(line);
            }
            l = temp;
        }
    }

    private int GetLifeSupportRating(int oxyGenRating, int co2ScrubRating)
    {
        return oxyGenRating * co2ScrubRating;
    }

    private int ToInt(string s)
    {
        return Convert.ToInt32(s, 2);
    }

    private (int, int) GetZerosOnes(List<string> l, int i)
    {
        int zeros = 0;
        int ones = 0;

        int maxIndex = l[0].Length - 1;

        foreach (string line in l)
        {
            if (line[maxIndex - i] == '0') zeros++;
            else ones++;
        }

        return (zeros, ones);
    }
}