using AdventOfCode2023.Days;
using Xunit;

namespace Tests.Tests;

public class Day3Test
{
    private readonly Day _day = new Day3();

    [Fact]
    public void TestPart1() => Assert.Equal(4361, _day.GetPart1Answer(true));
    [Fact]
    public void Part1() => Assert.Equal(537732, _day.GetPart1Answer(false));

    [Fact]
    public void TestPart2() => Assert.Equal(467835, _day.GetPart2Answer(true));
    
    [Fact]
    public void Part2() => Assert.Equal(84883664, _day.GetPart2Answer(false));
}