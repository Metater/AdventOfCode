namespace AdventOfCode2021.Days;

public class Day2P1 : Day
{
    public Day2P1(string[] input) : base(input)
    {

    }

    public override void Run()
    {
        Sub sub = new Sub();
        foreach (var line in input)
        {
            string[] parts = line.Split(' ');
            int a = int.Parse(parts[1]);
            switch (parts[0])
            {
                case "forward":
                    sub.Forward(a);
                    break;
                case "up":
                    sub.Up(a);
                    break;
                case "down":
                    sub.Down(a);
                    break;
            }
        }
        sub.Print();
    }

    public class Sub
    {
        int depth = 0;
        int x = 0;

        public void Up(int a)
        {
            depth -= a;
        }

        public void Down(int a)
        {
            depth += a;
        }

        public void Forward(int a)
        {
            x += a;
        }

        public void Print()
        {
            Console.WriteLine(x * depth);
        }
    }

}