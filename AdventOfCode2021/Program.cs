bool runAll = false;

if (runAll)
{
    List<Day> days = new();

    days.Add(new Day1P1(Input("Day1")));
    days.Add(new Day1P2(Input("Day1")));

    foreach (Day day in days)
    {
        Console.WriteLine("\n\n\n\n");
        Console.WriteLine($"<-------- Running {day.GetType().Name} -------->");
        day.Run();
        Console.WriteLine("\n\n\n\n");
    }
}
else
{
    var e = new Day3P1(Input("Day3"));
    e.Run();
    //var d1p2 = new Day1P2(Input("Day1"));
    //d1p2.Run();
}

static string[] Input(string day)
{
    return File.ReadAllLines(@"E:\Projects\Visual Studio\AdventOfCode\AdventOfCode2021\input\" + day + ".txt");
}