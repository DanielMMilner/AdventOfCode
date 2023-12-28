using Xunit;

namespace Tests.Tests;

public class Day7Test : DayTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(6_440, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(248_812_215, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(5_905, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(250_057_090, Part2Answer);
}