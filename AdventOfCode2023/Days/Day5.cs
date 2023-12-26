using System.Collections.Concurrent;
using Microsoft.VisualBasic.CompilerServices;

namespace AdventOfCode2023.Days;

public class Day5 : Day
{
    protected override int GetDayNum() => 5;

    protected override int SolvePart1(List<string> lines)
    {
        var maps = GetMaps(lines);

        var seeds = lines[0].Split(":")[1].Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(long.Parse);
        var seedLocation = new ValueTuple<long, long>(-1, -1);

        foreach (var seed in seeds)
        {
            var location = GetLocationFromSeed(maps, seed);

            if (seedLocation.Item2 == -1 || location < seedLocation.Item2)
            {
                seedLocation.Item1 = seed;
                seedLocation.Item2 = location;
            }
        }

        return (int)seedLocation.Item2;
    }

    protected override int SolvePart2(List<string> lines)
    {
        var maps = GetMaps(lines);

        var seedRanges = lines[0]
            .Split(":")[1]
            .Split(" ")
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(long.Parse)
            .Chunk(2)
            .ToList();

        var locations = new ConcurrentBag<long>();

        Parallel.ForEach(seedRanges, ranges =>
        {
            long minLocation = -1;
            var start = ranges[0];
            var end = start + ranges[0 + 1];
            for (var j = start; j < end; j++)
            {
                var location = GetLocationFromSeed(maps, j);

                if (minLocation == -1 || location < minLocation)
                {
                    minLocation = location;
                }
            }

            locations.Add(minLocation);
        });

        return (int)locations.ToList().MinBy(x => x);
    }

    private static List<Map> GetMaps(IEnumerable<string> lines)
    {
        var maps = new List<Map>
        {
            new("seed-to-soil map:"),
            new("soil-to-fertilizer map:"),
            new("fertilizer-to-water map:"),
            new("water-to-light map:"),
            new("light-to-temperature map:"),
            new("temperature-to-humidity map:"),
            new("humidity-to-location map:")
        };

        var currentMap = maps[0];
        foreach (var line in lines.Skip(1).Where(x => !string.IsNullOrEmpty(x)))
        {
            if (line.Contains(':'))
            {
                currentMap = maps.First(x => x.Name == line.Trim());
            }
            else
            {
                var map = line.Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(long.Parse).ToArray();
                currentMap.Ranges.Add(new Ranges
                {
                    Destination = map[0],
                    Source = map[1],
                    Range = map[2]
                });
            }
        }

        return maps;
    }

    private long GetLocationFromSeed(List<Map> maps, long seed)
    {
        foreach (var map in maps)
        {
            var range = map.Ranges.FirstOrDefault(x => seed >= x.Source && seed <= x.Source + x.Range);
            if (range != null)
            {
                seed = seed - range.Source + range.Destination;
            }
        }

        return seed;
    }

    private class Map(string name)
    {
        public string Name { get; set; } = name;
        public List<Ranges> Ranges { get; set; } = [];
    }

    private class Ranges
    {
        public long Destination { get; set; }
        public long Source { get; set; }
        public long Range { get; set; }
    }
}