using Xunit;

namespace Tests.Aoc23;

public class Aoc23Day10Test : AocTest
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