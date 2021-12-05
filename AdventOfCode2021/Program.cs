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
    var d = new Day5P2(Input("Day5"));
    d.Run();
}

static string[] Input(string day)
{
    return File.ReadAllLines(@"E:\Projects\Visual Studio\AdventOfCode\AdventOfCode2021\input\" + day + ".txt");
}