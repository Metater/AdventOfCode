namespace AdventOfCode2021.Days;

public class Day12P1 : Day
{
    public Day12P1(string[] input) : base(input)
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
                if (to == "end")
                {
                    paths.Add(path + ",end");
                    continue;
                }
                if (to == "start") continue;
                if (char.IsLower(to[0]) && PathContains(path, to))
                {
                    continue;
                }
                Trace(path + "," + to, to);
            }
        }
    }

    private bool PathContains(string path, string cave)
    {
        string[] split = path.Split(',');
        return split.Contains(cave);
    }

    /*
     *         foreach (string link in input)
        {
            string[] split = link.Split('-');
            string start = split[0];
            string end = split[1];
            if (start == from)
            {
                path += "," + end;
                if (end == "end")
                {
                    paths.Add(path);
                }
                else
                    Trace(path, end);
            }
        }
    */

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