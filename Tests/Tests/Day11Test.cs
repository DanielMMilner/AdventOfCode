using Xunit;

namespace Tests.Tests;

public class Day11Test : DayTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(374, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(9_805_264, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(82_000_210, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(779_032_247_216, Part2Answer);
}