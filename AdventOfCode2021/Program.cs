bool runAll = false;

if (runAll)
{
    List<Day> days = new();

    days.Add(new Day1P1(Input("Day1")));
    days.Add(new Day1P2(Input("Day1")));
    days.Add(new Day2P1(Input("Day2")));
    days.Add(new Day2P2(Input("Day2")));
    days.Add(new Day3P1(Input("Day3")));
    days.Add(new Day3P2(Input("Day3")));
    days.Add(new Day4P1(Input("Day4")));
    days.Add(new Day4P2(Input("Day4")));
    days.Add(new Day5P1(Input("Day5")));
    days.Add(new Day5P2(Input("Day5")));
    days.Add(new Day6P1(Input("Day6")));
    days.Add(new Day6P2(Input("Day6")));
    days.Add(new Day7P1(Input("Day7")));
    days.Add(new Day7P2(Input("Day7")));
    days.Add(new Day8P1(Input("Day8")));
    days.Add(new Day8P2(Input("Day8")));
    days.Add(new Day9P1(Input("Day9")));
    days.Add(new Day9P2(Input("Day9")));
    days.Add(new Day10P1(Input("Day10")));
    days.Add(new Day10P2(Input("Day10")));

    foreach (Day day in days)
    {
        Console.WriteLine("\n\n");
        Console.WriteLine($"<-------- Running {day.GetType().Name} -------->");
        day.Run();
        Console.WriteLine("\n\n");
    }
}
else
{
    var d = new Day11P1(Input("Day11"));
    d.Run();
}

static string[] Input(string day)
{
    return File.ReadAllLines(@"E:\Projects\Visual Studio\AdventOfCode\AdventOfCode2021\input\" + day + ".txt");
}