using System.Diagnostics;
using AdventOfCode2023.Days;

var day = new Day11();
var stopWatch = Stopwatch.StartNew();
Console.WriteLine($"Part 1 Sample: {day.GetPart1Answer(true)}");
Console.WriteLine($"Part 1: {day.GetPart1Answer(false)}");
Console.WriteLine($"Part 2 Sample: {day.GetPart2Answer(true)}");
Console.WriteLine($"Part 2: {day.GetPart2Answer(false)}");
stopWatch.Stop();

var ts = stopWatch.Elapsed;
var elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds:000}";
Console.WriteLine("RunTime " + elapsedTime);