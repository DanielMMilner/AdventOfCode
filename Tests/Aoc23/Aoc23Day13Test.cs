using Xunit;

namespace Tests.Aoc23;

public class Aoc23Day13Test : AocTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(405, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(33520, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(400, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(34824, Part2Answer);
}