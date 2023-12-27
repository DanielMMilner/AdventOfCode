using System.Collections.Concurrent;

namespace AdventOfCode2023.Days;

public class Day5 : Day
{
    protected override long SolvePart1(List<string> lines)
    {
        var maps = GetMaps(lines);

        var seeds = lines[0].Split(":")[1].Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(uint.Parse);
        var seedLocation = new ValueTuple<uint, uint>(uint.MaxValue, uint.MaxValue);

        foreach (var seed in seeds)
        {
            var location = GetLocationFromSeed(maps, seed);

            if (location < seedLocation.Item2)
            {
                seedLocation.Item1 = seed;
                seedLocation.Item2 = location;
            }
        }

        return (int)seedLocation.Item2;
    }

    protected override long SolvePart2(List<string> lines)
    {
        var reversedMaps = GetMaps(lines).Reverse().ToArray();

        var seedRanges = lines[0]
            .Split(":")[1]
            .Split(" ")
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(uint.Parse)
            .Chunk(2)
            .Select(x => new { Start = x[0], End = x[0] + x[1] })
            .ToList();
        const int batchSize = 1000000;

        uint location = 0;
        while (true)
        {
            var numRanges = Enumerable.Range(0, 20).Select(x => (uint)(x * batchSize + location)).ToList();
            var seeds = new ConcurrentBag<uint>();
            var lowestThreadFound = uint.MaxValue;

            Parallel.ForEach(numRanges, numRange =>
            {
                Range? range;
                Range? tempRange;
                Map? tempMap;
                uint num;
                for (uint b = 0; b <= batchSize; b++)
                {
                    if (numRange > lowestThreadFound)
                    {
                        return;
                    }
                    num = numRange + b;
                    var tempSeed = num;
                    for (var i = 0; i < reversedMaps.Length; i++)
                    {
                        tempMap = reversedMaps[i];
                        range = null;

                        for (var j = 0; j < tempMap.Ranges.Count; j++)
                        {
                            tempRange = tempMap.Ranges[j];
                            if (tempSeed >= tempRange.DestinationStart && tempSeed <= tempRange.DestinationEnd)
                            {
                                range = tempRange;
                                break;
                            }
                        }

                        if (range != null)
                        {
                            tempSeed = tempSeed - range.DestinationStart + range.SourceStart;
                        }
                    }

                    for (var i = 0; i < seedRanges.Count; i++)
                    {
                        if (seedRanges[i].Start <= tempSeed && seedRanges[i].End >= tempSeed)
                        {
                            seeds.Add(num);
                            if (numRange < lowestThreadFound)
                            {
                                lowestThreadFound = numRange;
                            }
                            return;
                        }
                    }
                }
            });

            if (!seeds.IsEmpty)
            {
                return (int)seeds.MinBy(x => x);
            }

            location = numRanges.Last() + 1;
        }
    }

    private static Map[] GetMaps(IEnumerable<string> lines)
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
                var map = line.Split(" ").Where(x => !string.IsNullOrEmpty(x)).Select(uint.Parse).ToArray();
                var range = new Range
                {
                    DestinationStart = map[0],
                    DestinationEnd = map[0] + map[2],
                    SourceStart = map[1],
                    SourceEnd = map[1] + map[2]
                };
                currentMap.Ranges.Add(range);
            }
        }

        return maps.ToArray();
    }

    private static uint GetLocationFromSeed(Map[] maps, uint seed)
    {
        Range? range;
        Range? tempRange;
        Map? tempMap;
        for (var i = 0; i < maps.Length; i++)
        {
            tempMap = maps[i];
            range = null;

            for (var j = 0; j < tempMap.Ranges.Count; j++)
            {
                tempRange = tempMap.Ranges[j];
                if (seed >= tempRange.SourceStart && seed <= tempRange.SourceEnd)
                {
                    range = tempRange;
                    break;
                }
            }

            if (range != null)
            {
                seed = seed - range.SourceStart + range.DestinationStart;
            }
        }

        return seed;
    }

    private class Map(string name)
    {
        public string Name { get; } = name;
        public List<Range> Ranges { get; } = [];
    }

    private class Range
    {
        public uint DestinationStart { get; init; }
        public uint DestinationEnd { get; init; }
        public uint SourceStart { get; init; }
        public uint SourceEnd { get; init; }
    }
}