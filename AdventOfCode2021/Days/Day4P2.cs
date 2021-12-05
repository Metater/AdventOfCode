namespace AdventOfCode2021.Days;

public class Day4P2 : Day
{
    public Day4P2(string[] input) : base(input)
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

        List<(int[,], bool[,])> remove = new();
        for (int i = 0; i < nums.Count; i++)
        {
            foreach (var board in boards)
            {
                MarkBoard(board, nums[i]);
                if (CheckBoard(board.Item2))
                {
                    Console.WriteLine(GetUnmarkedSum(board) * nums[i]);
                    remove.Add(board);
                }
            }
            foreach (var board in remove) boards.Remove(board);
            remove.Clear();
        }
    }

    private int GetUnmarkedSum((int[,], bool[,]) board)
    {
        int sum = 0;
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                if (!board.Item2[x, y])
                {
                    sum += board.Item1[x, y];
                }
            }
        }
        return sum;
    }

    private void MarkBoard((int[,], bool[,]) board, int num)
    {
        for (int y = 0; y < 5; y++)
        {
            for (int x = 0; x < 5; x++)
            {
                if (board.Item1[x, y] == num)
                {
                    board.Item2[x, y] = true;
                }
            }
        }
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
        // horizontal
        for (int y = 0; y < 5; y++)
        {
            int row = 0;
            for (int x = 0; x < 5; x++)
            {
                if (board[x, y]) row++;
            }
            if (row == 5) return true;
        }

        // vertical
        for (int x = 0; x < 5; x++)
        {
            int col = 0;
            for (int y = 0; y < 5; y++)
            {
                if (board[x, y]) col++;
            }
            if (col == 5) return true;
        }
        return false;
    }
}