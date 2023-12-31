using Xunit;

namespace Tests.Aoc23;

public class Aoc23Day12Test : AocTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(21, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(7_916, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(525_152, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(37_366_887_898_686, Part2Answer);
}