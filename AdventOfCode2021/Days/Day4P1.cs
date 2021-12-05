namespace AdventOfCode2021.Days;

public class Day4P1 : Day
{
    public Day4P1(string[] input) : base(input)
    {

    }

    private List<int> nums = new();
    private List<(int[,], bool[,])> boards = new();

    public override void Run()
    {
        string[] strNums = input[0].Split(',');
        foreach (string num in strNums)
            nums.Add(int.Parse(num));
        int line = 1;
        while (GetBoard(line))
        {
            line += 6;
        }
        Console.WriteLine(boards.Count);
    }

    private bool GetBoard(int startLine)
    {
        if (startLine + 5 < input.Length)
        {
            int[,] board = new int[5, 5];
            int l = 0;
            for (int i = startLine + 1; i <= startLine + 5; i++)
            {
                string line = input[i];
                string[] nums = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < 5; j++)
                {
                    board[j, l] = int.Parse(nums[j]);
                }
                l++;
            }
            boards.Add((board, new bool[5, 5]));
        }
        else return false;
        return true;
    }

    private bool CheckBoard(bool[,] board)
    {
        bool 
        for (int i = 0; i < 5; i++)
        {

        }
    }
}