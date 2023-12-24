namespace AdventOfCode2023.Days;

public abstract class Day
{
    public bool IsTest { get; set; }
    public int Part1Answer => IsTest ? SolvePart1(GetPart1Lines()) : SolvePart1(GetLines());
    public int Part2Answer => IsTest ? SolvePart2(GetPart2Lines()) : SolvePart2(GetLines());
    protected abstract int SolvePart1(List<string> lines);
    protected abstract int SolvePart2(List<string> lines);
    protected abstract int GetDayNum();
    private const string Path = @"F:\Documents\Code\AdventOfCode2023\AdventOfCode2023\Data\day";
    private List<string> GetLines() => File.ReadLines($@"{Path}{GetDayNum()}\data.txt").ToList();
    private List<string> GetPart1Lines() => File.ReadLines($@"{Path}{GetDayNum()}\part1-test.txt").ToList();
    private List<string> GetPart2Lines() => File.ReadLines($@"{Path}{GetDayNum()}\part2-test.txt").ToList();
}