using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021;

public abstract class Day
{
    protected readonly string[] input;

    public Day() { }

    public Day(string[] input)
    {
        this.input = input;
    }

    public abstract void Run();
}