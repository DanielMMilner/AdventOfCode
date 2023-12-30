using Xunit;

namespace Tests.Aoc23;

public class Aoc23Day12Test : AocTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(21, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(7916, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(525152, SamplePart2Answer);

    [Fact(Skip = "Not implemented")]
    public void Part2() => Assert.Equal(-1, Part2Answer);
}