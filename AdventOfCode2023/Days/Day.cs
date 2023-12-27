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

    public long GetPart1Answer(bool isTest) => isTest ? SolvePart1(GetPart1Lines()) : SolvePart1(GetLines());
    public long GetPart2Answer(bool isTest) => isTest ? SolvePart2(GetPart2Lines()) : SolvePart2(GetLines());

    protected abstract long SolvePart1(List<string> lines);
    protected abstract long SolvePart2(List<string> lines);
    protected abstract int GetDayNum();
    private const string Path = @"F:\Documents\Code\AdventOfCode2023\AdventOfCode2023\Data\day";
    private List<string> GetLines() => File.ReadLines($@"{Path}{GetDayNum()}\data.txt").ToList();
    private List<string> GetPart1Lines() => File.ReadLines($@"{Path}{GetDayNum()}\part1-test.txt").ToList();
    private List<string> GetPart2Lines() => File.ReadLines($@"{Path}{GetDayNum()}\part2-test.txt").ToList();
}