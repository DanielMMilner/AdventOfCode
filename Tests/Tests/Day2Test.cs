using AdventOfCode2023.Days;
using Xunit;

namespace Tests.Tests;

public class Day2Test
{
    private readonly Day _day = new Day2
    {
        IsTest = true
    };

    [Fact]
    public void TestPart1()
    {
        Assert.Equal(8, _day.Part1Answer);
    }

    [Fact]
    public void TestPart2()
    {
        Assert.Equal(2286, _day.Part2Answer);
    }
}