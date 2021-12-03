namespace AdventOfCode2021.Days;

public class Day3P1 : Day
{
    public Day3P1(string[] input) : base(input)
    {

    }

    public override void Run()
    {
        string gamma = "";
        string epsilon = "";
        for (int j = 0; j < input[0].Length; j++)
        {
            int zeros = 0;
            int ones = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i][j] == '0') zeros++;
                else ones++;
            }
            if (zeros > ones) // more zeros
            {
                gamma += '0';
                epsilon += '1';
            }
            else // more ones
            {
                gamma += '1';
                epsilon += '0';
            }
        }
        Console.WriteLine(gamma);
        Console.WriteLine(epsilon);
        Console.WriteLine(Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2));
    }
}