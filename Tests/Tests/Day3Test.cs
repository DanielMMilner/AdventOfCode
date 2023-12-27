using AdventOfCode2023.Days;

namespace Tests.Tests;

public class Day3Test : DayTest
{
    protected override Day GetDay() => new Day3();
    protected override long GetPart1SampleAnswer() => 4361;
    protected override long GetPart1Answer() => 537732;
    protected override long GetPart2SampleAnswer() => 467835;
    protected override long GetPart2Answer() => 84883664;
}