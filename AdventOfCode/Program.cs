using System.Diagnostics;
using AdventOfCode.Years.Aoc23.Day12;

var day = new Aoc23Day12();
var stopWatch = Stopwatch.StartNew();
// Console.WriteLine($"Part 1 Sample: {day.GetPart1Answer(true)}");
// Console.WriteLine($"Part 1: {day.GetPart1Answer(false)}");
// Console.WriteLine($"Part 2 Sample: {day.GetPart2Answer(true)}");
Console.WriteLine($"Part 2: {day.GetPart2Answer(false)}");
stopWatch.Stop();

var ts = stopWatch.Elapsed;
var elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds:000}";
Console.WriteLine("RunTime " + elapsedTime);