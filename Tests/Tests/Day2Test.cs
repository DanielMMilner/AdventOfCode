using Xunit;

namespace Tests.Tests;

public class Day2Test : DayTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(8, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(2_617, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(2_286, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(59_795, Part2Answer);
}