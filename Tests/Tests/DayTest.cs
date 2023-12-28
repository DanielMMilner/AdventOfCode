using System.Reflection;
using AdventOfCode2023.Days;

namespace Tests.Tests;

public abstract class DayTest
{
    private Day GetDay()
    {
        var newClass = Assembly.GetAssembly(typeof(Day))!
            .CreateInstance($"AdventOfCode2023.Days.{GetType().Name.Replace("Test", string.Empty)}");
        return (Day)newClass!;
    }

    protected long SamplePart1Answer => GetDay().GetPart1Answer(true);
    protected long Part1Answer => GetDay().GetPart1Answer(false);
    protected long SamplePart2Answer => GetDay().GetPart2Answer(true);
    protected long Part2Answer => GetDay().GetPart2Answer(false);
}