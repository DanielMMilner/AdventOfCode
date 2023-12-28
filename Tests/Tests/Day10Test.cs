using Xunit;

namespace Tests.Tests;

public class Day10Test : DayTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(8, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(7012, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(10, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(395, Part2Answer);
}