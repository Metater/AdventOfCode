namespace AdventOfCode2021.Days;

public class Day12P2 : Day
{
    public Day12P2(string[] input) : base(input)
    {

    }

    private List<string> paths = new();
    private List<Link> links = new();

    public override void Run()
    {
        foreach (string link in input)
        {
            string[] split = link.Split('-');
            links.Add(new Link(split[0], split[1]));
        }

        foreach (Link link in links)
        {
            if (link.TryFollow("start", out string to))
            {
                Trace("start," + to, to);
            }
        }

        Console.WriteLine(paths.Count);
    }

    private void Trace(string path, string from)
    {
        foreach (Link link in links)
        {
            if (link.TryFollow(from, out string to))
            {
                if (to == "start") continue;
                if (to == "end")
                {
                    paths.Add(path + ",end");
                    continue;
                }
                if (CanVisit(path, to))
                    Trace(path + "," + to, to);
            }
        }
    }

    private bool CanVisit(string path, string cave)
    {
        if (char.IsUpper(cave[0])) return true;

        string[] split = path.Split(',');

        List<string> seen = new();
        foreach (string s in split)
        {
            if (char.IsUpper(s[0])) continue;
            if (seen.Contains(s))
            {
                return !split.Contains(cave);
            }
            seen.Add(s);
        }
        return true;
    }

    public class Link
    {
        public readonly string a;
        public readonly string b;

        public Link(string a, string b)
        {
            this.a = a;
            this.b = b;
        }

        public bool TryFollow(string from, out string to)
        {
            if (a == from)
            {
                to = b;
                return true;
            }
            else if (b == from)
            {
                to = a;
                return true;
            }
            to = "";
            return false;
        }
    }
}