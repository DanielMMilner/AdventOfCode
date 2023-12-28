﻿using Xunit;

namespace Tests.Tests;

public class Day6Test : DayTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(288, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(160_816, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(71_503, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(46_561_107, Part2Answer);
}