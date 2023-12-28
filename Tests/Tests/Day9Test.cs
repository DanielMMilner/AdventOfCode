using Xunit;

namespace Tests.Tests;

public class Day9Test : DayTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(114, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(1995001648, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(2, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(988, Part2Answer);
}