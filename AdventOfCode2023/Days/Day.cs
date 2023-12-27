﻿namespace AdventOfCode2023.Days;

public abstract class Day
{
    public void Solve()
    {
        Console.WriteLine($"Part 1 Sample: {GetPart1Answer(true)}");
        Console.WriteLine($"Part 1: {GetPart1Answer(false)}");
        Console.WriteLine($"Part 2 Sample: {GetPart2Answer(true)}");
        Console.WriteLine($"Part 2: {GetPart2Answer(false)}");
    }

    public long GetPart1Answer(bool isTest) => SolvePart1(GetLines(isTest, false));
    public long GetPart2Answer(bool isTest) => SolvePart2(GetLines(isTest, true));

    private int GetDayNum => int.Parse(GetType().Name.Replace("Day", string.Empty));
    private const string Path = @"F:\Documents\Code\AdventOfCode2023\AdventOfCode2023\Data\day";

    private List<string> GetLines(bool isTest, bool isPart2)
    {
        var fileName = "data.txt";
        if (isTest)
        {
            fileName = isPart2 && File.Exists($@"{Path}{GetDayNum}\sample2.txt") ? "sample2.txt" : "sample.txt";
        }

        return File.ReadLines($@"{Path}{GetDayNum}\{fileName}").ToList();
    }

    protected abstract long SolvePart1(List<string> lines);
    protected abstract long SolvePart2(List<string> lines);
}