namespace AdventOfCode2021.Days;

public class Day3P2 : Day
{
    private List<string> oxy;
    private List<string> co2;

    public Day3P2(string[] input) : base(input)
    {
        oxy = new List<string>(input);
        co2 = new List<string>(input);
    }

    public override void Run()
    {
        int oxyRating;
        for (int j = 0; j < input[0].Length; j++)
        {
            int zeros = 0;
            int ones = 0;
            for (int i = 0; i < oxy.Count; i++)
            {
                if (input[i][j] == '0') zeros++;
                else ones++;
            }
            List<string> o = new List<string>();
            for (int i = 0; i < oxy.Count; i++)
            {

                if (oxy.Count == 1) oxyRating = Convert.ToInt32(oxy[0]);
            }
        }
    }

    private int GetLifeSupportRating(int oxyGenRating, int co2ScrubRating)
    {
        return oxyGenRating * co2ScrubRating;
    }
}