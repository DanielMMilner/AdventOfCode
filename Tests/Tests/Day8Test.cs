using Xunit;

namespace Tests.Tests;

public class Day8Test : DayTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(6, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(22_357, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(6, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(-1, Part2Answer);
}