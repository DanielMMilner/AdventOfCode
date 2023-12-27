using AdventOfCode2023.Days;
using Xunit;

namespace Tests.Tests;

public abstract class DayTest
{
    protected abstract Day GetDay();
    protected abstract long GetPart1SampleAnswer();
    protected abstract long GetPart1Answer();
    protected abstract long GetPart2SampleAnswer();
    protected abstract long GetPart2Answer();

    [Fact]
    public void TestPart1() => Assert.Equal(GetPart1SampleAnswer(), GetDay().GetPart1Answer(true));

    [Fact]
    public void Part1() => Assert.Equal(GetPart1Answer(), GetDay().GetPart1Answer(false));

    [Fact]
    public void TestPart2() => Assert.Equal(GetPart2SampleAnswer(), GetDay().GetPart2Answer(true));

    [Fact]
    public void Part2() => Assert.Equal(GetPart2Answer(), GetDay().GetPart2Answer(false));
}