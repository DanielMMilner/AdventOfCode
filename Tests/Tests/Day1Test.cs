using AdventOfCode2023.Days;
using Xunit;

namespace Tests.Tests;

public class Day1Test
{
    private readonly Day _day = new Day1
    {
        IsTest = true
    };

    [Fact]
    public void TestPart1()
    {
        Assert.Equal(142, _day.Part1Answer);
    }

    [Fact]
    public void TestPart2()
    {
        Assert.Equal(281, _day.Part2Answer);
    }
}