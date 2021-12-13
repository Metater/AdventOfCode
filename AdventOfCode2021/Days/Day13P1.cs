using System.Collections.Generic;
using System;

//namespace AdventOfCode2021.Days;

public class Day13P1 : Day
{
    public Day13P1(string[] input) : base(input)
    {

    }

    bool[,] paper;

    public override void Run()
    {
        List<(int, int)> points = new();
        int line = 0;
		int maxX = -1;
        int maxY = -1;
        while (input[line] != "")
        {
            string[] split = input[line].Split(',');
			int x = int.Parse(split[0]);
			int y = int.Parse(split[1]);
			if (x > maxX) maxX = x;
            if (y > maxY) maxY = y;
            points.Add((x, y));
            line++;
        }
        paper = new bool[maxX + 1, maxY + 1];
		foreach ((int x, int y) in points)
		{
			paper[x, y] = true;
		}
        Console.WriteLine($"Paper Size: ({paper.GetLength(0)}, {paper.GetLength(1)})");

		for (int y = 0; y < paper.GetLength(1); y++)
		{
			for (int x = 0; x < paper.GetLength(0); x++)
			{
				Console.Write(paper[x, y] ? "#" : ".");
			}
			Console.WriteLine();
		}
    }
}