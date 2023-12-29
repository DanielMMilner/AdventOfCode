namespace AdventOfCode.Years.Aoc23.Day11;

public class Aoc23Day11 : Aoc
{
    protected override long SolvePart1(List<string> lines) => GetDistanceSum(lines, 2);

    protected override long SolvePart2(List<string> lines) => GetDistanceSum(lines, 1_000_000);

    private static long GetDistanceSum(IEnumerable<string> lines, int expansionAmount)
    {
        var starMap = lines.Select(x => x.Select(z => z).ToList()).ToList();
        var galaxies = new List<(int, int)>();

        var yMultipliers = Enumerable.Range(0, starMap.Count).ToList();
        var xMultipliers = Enumerable.Range(0, starMap[0].Count).ToList();

        for (var y = 0; y < starMap.Count; y++)
        {
            for (var x = 0; x < starMap[y].Count; x++)
            {
                if (starMap[y][x] == '#')
                {
                    yMultipliers.Remove(y);
                    xMultipliers.Remove(x);
                    galaxies.Add((x, y));
                }
            }
        }

        long sum = 0;
        for (var i = 0; i < galaxies.Count; i++)
        {
            for (var j = i + 1; j < galaxies.Count; j++)
            {
                var g1 = galaxies[i];
                var g2 = galaxies[j];
                long distance = Math.Abs(g1.Item1 - g2.Item1) + Math.Abs(g1.Item2 - g2.Item2);
                var yMultiplier = yMultipliers.Count(y =>
                    y >= Math.Min(g1.Item2, g2.Item2) && y <= Math.Max(g1.Item2, g2.Item2));
                var xMultiplier = xMultipliers.Count(x =>
                    x >= Math.Min(g1.Item1, g2.Item1) && x <= Math.Max(g1.Item1, g2.Item1));
                var expandedDistance =
                    distance + xMultiplier * (expansionAmount - 1) + yMultiplier * (expansionAmount - 1);
                sum += expandedDistance;
            }
        }

        return sum;
    }
}