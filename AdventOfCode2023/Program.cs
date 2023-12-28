using System.Diagnostics;
using AdventOfCode2023.Days;

var stopWatch = Stopwatch.StartNew();
new Day9().Solve();
stopWatch.Stop();

var ts = stopWatch.Elapsed;
var elapsedTime = $"{ts.Hours:00}:{ts.Minutes:00}:{ts.Seconds:00}.{ts.Milliseconds:000}";
Console.WriteLine("RunTime " + elapsedTime);