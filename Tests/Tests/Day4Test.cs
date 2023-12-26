using AdventOfCode2023.Days;
using Xunit;

namespace Tests.Tests;

public class Day4Test
{
    private readonly Day _day = new Day4();

    [Fact]
    public void TestPart1() => Assert.Equal(13, _day.GetPart1Answer(true));
    
    [Fact]
    public void Part1() => Assert.Equal(22674, _day.GetPart1Answer(false));

    [Fact]
    public void TestPart2() => Assert.Equal(30, _day.GetPart2Answer(true));
    
    [Fact]
    public void Part2() => Assert.Equal(5747443, _day.GetPart2Answer(false));
}