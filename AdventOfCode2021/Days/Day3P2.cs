namespace AdventOfCode2021.Days;

public class Day3P2 : Day
{

    public Day3P2(string[] input) : base(input)
    {

    }

    public override void Run()
    {
        Console.WriteLine(GetOxygenGeneratorRating() * GetCO2ScrubberRating());
    }

    private int GetOxygenGeneratorRating()
    {
        List<string> l = new(input);
        List<string> temp = new();
        string rating = "";
        for (int i = 0; i < input[0].Length; i++)
        {
            int zeros = 0;
            int ones = 0;
            foreach (string line in l)
            {
                if (line[i] == '0') zeros++;
                else ones++;
            }
            char keep = '1';
            if (zeros > ones) keep = '0';
            foreach (string line in l)
            {
                if (line[i] == keep)
                {
                    temp.Add(line);
                    rating = line;
                }
            }
            l = new(temp);
            temp.Clear();
        }
        return ToInt(rating);
    }

    private int GetCO2ScrubberRating()
    {
        List<string> l = new(input);
        List<string> temp = new();
        string rating = "";
        for (int i = 0; i < input[0].Length; i++)
        {
            int zeros = 0;
            int ones = 0;
            foreach (string line in l)
            {
                if (line[i] == '0') zeros++;
                else ones++;
            }
            char keep = '0';
            if (zeros > ones) keep = '1';
            foreach (string line in l)
            {
                if (line[i] == keep)
                {
                    temp.Add(line);
                    rating = line;
                }
            }
            l = new(temp);
            temp.Clear();
        }
        return ToInt(rating);
    }

    private int ToInt(string s)
    {
        return Convert.ToInt32(s, 2);
    }

    private (int, int, bool) GetZerosOnes(List<string> l, int i)
    {
        if (l.Count == 0) return (0, 0, true);

        int zeros = 0;
        int ones = 0;

        int maxIndex = l[0].Length - 1;

        foreach (string line in l)
        {
            if (line[maxIndex - i] == '0') zeros++;
            else ones++;
        }

        return (zeros, ones, false);
    }
}