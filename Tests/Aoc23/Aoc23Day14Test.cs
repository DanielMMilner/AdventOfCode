using Xunit;

namespace Tests.Aoc23;

public class Aoc23Day14Test : AocTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(136, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(107142, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(64, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(104815, Part2Answer);
}