using Xunit;

namespace Tests.Aoc23;

public class Aoc23Day8Test : AocTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(6, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(22_357, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(6, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(10_371_555_451_871, Part2Answer);
}