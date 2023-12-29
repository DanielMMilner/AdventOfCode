using System.Reflection;
using AdventOfCode;

namespace Tests;

public abstract class AocTest
{
    private string ClassName => GetType().Name.Replace("Test", string.Empty);
    private int YearNum => int.Parse(string.Concat(ClassName.Skip(3).Take(2)));
    private int DayNum => int.Parse(string.Concat(ClassName.Skip(8)));
    private Aoc GetAocDay()
    {
        var newClass = Assembly
            .GetAssembly(typeof(Aoc))!
            .CreateInstance($"AdventOfCode.Years.Aoc{YearNum}.Day{DayNum}.{ClassName}");
        return (Aoc)newClass!;
    }

    protected long SamplePart1Answer => GetAocDay().GetPart1Answer(true);
    protected long Part1Answer => GetAocDay().GetPart1Answer(false);
    protected long SamplePart2Answer => GetAocDay().GetPart2Answer(true);
    protected long Part2Answer => GetAocDay().GetPart2Answer(false);
}