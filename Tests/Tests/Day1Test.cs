using AdventOfCode2023.Days;
using Xunit;

namespace Tests.Tests;

public class Day1Test
{
    private readonly Day _day = new Day1();

    [Fact]
    public void TestPart1() => Assert.Equal(142, _day.GetPart1Answer(true));
    
    [Fact]
    public void Part1() => Assert.Equal(54239, _day.GetPart1Answer(false));

    [Fact]
    public void TestPart2() => Assert.Equal(281, _day.GetPart2Answer(true));
    
    [Fact]
    public void Part2() => Assert.Equal(55343, _day.GetPart2Answer(false));
}