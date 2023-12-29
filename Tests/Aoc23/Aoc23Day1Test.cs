using Xunit;

namespace Tests.Aoc23;

public class Aoc23Day1Test : AocTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(142, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(54_239, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(281, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(55_343, Part2Answer);
}