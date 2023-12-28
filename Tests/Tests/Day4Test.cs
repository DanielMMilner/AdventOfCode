using Xunit;

namespace Tests.Tests;

public class Day4Test : DayTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(13, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(22_674, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(30, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(5_747_443, Part2Answer);
}