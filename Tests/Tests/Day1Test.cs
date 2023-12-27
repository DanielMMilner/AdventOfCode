using AdventOfCode2023.Days;

namespace Tests.Tests;

public class Day1Test : DayTest
{
    protected override Day GetDay() => new Day1();
    protected override long GetPart1SampleAnswer() => 142;
    protected override long GetPart1Answer() => 54239;
    protected override long GetPart2SampleAnswer() => 281;
    protected override long GetPart2Answer() => 55343;
}