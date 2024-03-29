﻿using Xunit;

namespace Tests.Aoc23;

public class Aoc23Day5Test : AocTest
{
    [Fact]
    public void SamplePart1() => Assert.Equal(35, SamplePart1Answer);

    [Fact]
    public void Part1() => Assert.Equal(424_490_994, Part1Answer);

    [Fact]
    public void SamplePart2() => Assert.Equal(46, SamplePart2Answer);

    [Fact]
    public void Part2() => Assert.Equal(15_290_096, Part2Answer);
}