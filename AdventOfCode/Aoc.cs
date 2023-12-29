namespace AdventOfCode;

public abstract class Aoc
{
    public long GetPart1Answer(bool useSample) => SolvePart1(GetLines(useSample, false));
    public long GetPart2Answer(bool useSample) => SolvePart2(GetLines(useSample, true));

    private int YearNum => int.Parse(string.Concat(GetType().Name.Skip(3).Take(2)));
    private int DayNum => int.Parse(string.Concat(GetType().Name.Skip(8)));
    private string Path => $"./Years/Aoc{YearNum}/Day{DayNum}";

    private List<string> GetLines(bool useSample, bool isPart2)
    {
        var fileName = "data.txt";
        if (useSample)
        {
            fileName = isPart2 && File.Exists($@"{Path}\sample2.txt") ? "sample2.txt" : "sample.txt";
        }

        return File.ReadLines($@"{Path}\{fileName}").ToList();
    }

    protected abstract long SolvePart1(List<string> lines);
    protected abstract long SolvePart2(List<string> lines);
}