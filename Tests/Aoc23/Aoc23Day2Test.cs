using Xunit;

namespace Tests.Aoc23;

public class Aoc23Day2Test : AocTest
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