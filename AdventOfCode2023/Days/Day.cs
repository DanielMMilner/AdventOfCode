namespace AdventOfCode2023.Days;

public abstract class Day
{
    public void Solve()
    {
        Console.WriteLine($"Part 1 Test: {GetPart1Answer(true)}");
        Console.WriteLine($"Part 1: {GetPart1Answer(false)}");
        Console.WriteLine($"Part 2 Test: {GetPart2Answer(true)}");
        Console.WriteLine($"Part 2: {GetPart2Answer(false)}");
    }

    public long GetPart1Answer(bool isTest) =>
        isTest ? SolvePart1(GetLines("part1-test.txt")) : SolvePart1(GetLines("data.txt"));

    public long GetPart2Answer(bool isTest) =>
        isTest ? SolvePart2(GetLines("part2-test.txt")) : SolvePart2(GetLines("data.txt"));

    private int GetDayNum => int.Parse(GetType().Name.Replace("Day", string.Empty));
    private const string Path = @"F:\Documents\Code\AdventOfCode2023\AdventOfCode2023\Data\day";
    private List<string> GetLines(string fileName) => File.ReadLines($@"{Path}{GetDayNum}\{fileName}").ToList();

    protected abstract long SolvePart1(List<string> lines);
    protected abstract long SolvePart2(List<string> lines);
}