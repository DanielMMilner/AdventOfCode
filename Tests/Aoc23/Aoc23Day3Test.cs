using Xunit;

namespace Tests.Aoc23;

public class Aoc23Day3Test : AocTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(4_361, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(537_732, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(467_835, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(84_883_664, Part2Answer);
}