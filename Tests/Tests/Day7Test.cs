using AdventOfCode2023.Days;
using Xunit;

namespace Tests.Tests;

public class Day7Test : DayTest
{
    protected override Day GetDay() => new Day7();
    protected override long GetPart1SampleAnswer() => 6440;
    protected override long GetPart1Answer() => 248812215;
    protected override long GetPart2SampleAnswer() => 5905;
    protected override long GetPart2Answer() => 250057090;
}