using AdventOfCode2023.Days;
using Xunit;

namespace Tests.Tests;

public class Day4Test
{
    private readonly Day _day = new Day4
    {
        IsTest = true
    };

    [Fact]
    public void TestPart1()
    {
        Assert.Equal(13, _day.Part1Answer);
    }

    [Fact]
    public void TestPart2()
    {
        Assert.Equal(30, _day.Part2Answer);
    }
}