namespace AdventOfCode2021.Days;

public class Day10P2 : Day
{
    public Day10P2(string[] input) : base(input)
    {

    }

    public override void Run()
    {
        List<long> scores = new();
        foreach (string line in input)
        {
            if (GetSyntaxErrorScore(line) != 0) continue;
            Stack<char> nest = new();
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (c == '(' || c == '[' || c == '{' || c == '<')
                    nest.Push(c);
                else
                    nest.Pop();
            }
            // ints will do that to you, hmm, why are there negatives in the output? hehe
            long score = 0;
            foreach (char c in nest)
            {
                score *= 5;
                score += GetValue(c);
            }
            scores.Add(score);
        }
        scores.Sort();
        /*
        foreach (int score in scores)
        {
            Console.WriteLine(score);
        }
        */
        Console.WriteLine($"Middle Score: {scores[(scores.Count / 2)]}");
    }

    private int GetValue(char c)
    {
        return c switch
        {
            '(' => 1,
            '[' => 2,
            '{' => 3,
            '<' => 4,
            _ => 0,
        };
    }

    private int GetSyntaxErrorScore(string line)
    {
        Stack<char> nest = new();
        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];
            if (c == '(' || c == '[' || c == '{' || c == '<')
            {
                nest.Push(c);
            }
            else
            {
                if (!IsPair(nest.Peek(), c))
                {
                    return GetCharSyntaxErrorScore(c);
                }
                nest.Pop();
            }
        }
        return 0;
    }

    private bool IsPair(char a, char b)
    {
        if (a == '(' && b == ')') return true;
        if (a == '[' && b == ']') return true;
        if (a == '{' && b == '}') return true;
        if (a == '<' && b == '>') return true;
        return false;
    }

    private int GetCharSyntaxErrorScore(char c)
    {
        return c switch
        {
            ')' => 3,
            ']' => 57,
            '}' => 1197,
            '>' => 25137,
            _ => 0,
        };
    }
}