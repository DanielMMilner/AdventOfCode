using AdventOfCode2023.Days;
using Xunit;

namespace Tests.Tests;

public class Day6Test
{
    private readonly Day _day = new Day6();

    [Fact]
    public void TestPart1() => Assert.Equal(288, _day.GetPart1Answer(true));

    [Fact]
    public void Part1() => Assert.Equal(160816, _day.GetPart1Answer(false));

    [Fact]
    public void TestPart2() => Assert.Equal(71503, _day.GetPart2Answer(true));

    [Fact]
    public void Part2() => Assert.Equal(46561107, _day.GetPart2Answer(false));
}