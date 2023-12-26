using AdventOfCode2023.Days;
using Xunit;

namespace Tests.Tests;

public class Day5Test
{
    private readonly Day _day = new Day5();

    [Fact]
    public void TestPart1() => Assert.Equal(35, _day.GetPart1Answer(true));

    [Fact]
    public void Part1() => Assert.Equal(424_490_994, _day.GetPart1Answer(false));

    [Fact]
    public void TestPart2() => Assert.Equal(46, _day.GetPart2Answer(true));

    [Fact]
    public void Part2() => Assert.Equal(15_290_096, _day.GetPart2Answer(false));
}