using AdventOfCode2023.Days;
using Xunit;

namespace Tests.Tests;

public class Day2Test
{
    private readonly Day _day = new Day2();

    [Fact]
    public void TestPart1() => Assert.Equal(8, _day.GetPart1Answer(true));

    [Fact]
    public void Part1() => Assert.Equal(2617, _day.GetPart1Answer(false));

    [Fact]
    public void TestPart2() => Assert.Equal(2286, _day.GetPart2Answer(true));

    [Fact]
    public void Part2() => Assert.Equal(59795, _day.GetPart2Answer(false));
}