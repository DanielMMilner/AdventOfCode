using AdventOfCode2023.Days;
using Xunit;

namespace Tests.Tests;

public class Day3Test
{
    private readonly Day _day = new Day3
    {
        IsTest = true
    };

    [Fact]
    public void TestPart1()
    {
        Assert.Equal(4361, _day.Part1Answer);
    }

    [Fact]
    public void TestPart2()
    {
        Assert.Equal(467835, _day.Part2Answer);
    }
}