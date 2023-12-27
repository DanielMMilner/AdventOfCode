using AdventOfCode2023.Days;

namespace Tests.Tests;

public class Day2Test : DayTest
{
    protected override Day GetDay() => new Day2();
    protected override long GetPart1SampleAnswer() => 8;
    protected override long GetPart1Answer() => 2617;
    protected override long GetPart2SampleAnswer() => 2286;
    protected override long GetPart2Answer() => 59795;
}