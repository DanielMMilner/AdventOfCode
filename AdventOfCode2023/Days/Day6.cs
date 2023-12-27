namespace AdventOfCode2023.Days;

public class Day6 : Day
{
    protected override int GetDayNum() => 6;

    protected override long SolvePart1(List<string> lines)
    {
        var times = lines[0].Split(" ").Where(x => !string.IsNullOrEmpty(x)).Skip(1);
        var distances = lines[1].Split(" ").Where(x => !string.IsNullOrEmpty(x)).Skip(1);
        var races = times.Zip(distances);

        var sum = 1;
        foreach (var race in races)
        {
            var time = int.Parse(race.First);
            var distance = int.Parse(race.Second);

            sum *= Enumerable.Range(1, time).Count(x => x * (time - x) > distance);
        }

        return sum;
    }

    protected override long SolvePart2(List<string> lines)
    {
        long Map(string line) => long.Parse(
            line
                .Split(" ")
                .Where(x => !string.IsNullOrEmpty(x))
                .Skip(1)
                .Aggregate((a, b) => a + b)
        );

        var time = Map(lines[0]);
        var distance = Map(lines[1]);

        long sum = 0;

        for (long i = 0; i < time; i++)
        {
            if (i * (time - i) > distance)
            {
                sum++;
            }
        }

        return sum;
    }
}