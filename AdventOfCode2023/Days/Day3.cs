using System.Text.RegularExpressions;

namespace AdventOfCode2023.Days;

public class Day3 : Day
{
    protected override int GetDayNum() => 3;

    protected override long SolvePart1(List<string> lines)
    {
        var nonSymbols = new List<char>
        {
            '.', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
        };
        var symbolIndexes = new List<List<int>>();

        foreach (var line in lines)
        {
            var lineIndexes = new List<int>();
            for (var i = 0; i < line.Length; i++)
            {
                if (!nonSymbols.Contains(line[i]))
                {
                    lineIndexes.Add(i);
                }
            }

            symbolIndexes.Add(lineIndexes);
        }

        var engineParts = new List<int>();

        var regex = new Regex("\\d+");

        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            var matches = regex.Matches(line);
            if (matches.Count != 0)
            {
                var lineAbove = i - 1 < 0 ? [] : symbolIndexes[i - 1];
                var lineIndexes = symbolIndexes[i];
                var liveBelow = i + 1 >= symbolIndexes.Count ? [] : symbolIndexes[i + 1];

                foreach (Match match in matches)
                {
                    var hasTopMatch = lineAbove
                        .Any(x => x >= match.Index - 1 && x <= match.Index + match.Length);
                    var hasCurrentMatch = lineIndexes
                        .Any(x => x >= match.Index - 1 && x <= match.Index + match.Length);
                    var hasBottomMatch = liveBelow
                        .Any(x => x >= match.Index - 1 && x <= match.Index + match.Length);
                    if (hasTopMatch || hasCurrentMatch || hasBottomMatch)
                    {
                        engineParts.Add(int.Parse(match.Value));
                        Console.WriteLine(match.Value);
                    }
                }
            }

            Console.WriteLine("-------------------");
        }

        return engineParts.Sum();
    }

    protected override long SolvePart2(List<string> lines)
    {
        const char symbol = '*';
        var symbolIndexes = new List<List<int>>();

        foreach (var line in lines)
        {
            var lineIndexes = new List<int>();
            for (var i = 0; i < line.Length; i++)
            {
                if (line[i] == symbol)
                {
                    lineIndexes.Add(i);
                }
            }

            symbolIndexes.Add(lineIndexes);
        }

        var symbolMatches = new Dictionary<string, List<int>>();


        var regex = new Regex("\\d+");

        for (var i = 0; i < lines.Count; i++)
        {
            var line = lines[i];
            var matches = regex.Matches(line);
            if (matches.Count != 0)
            {
                var lineAbove = i - 1 < 0 ? [] : symbolIndexes[i - 1];
                var lineIndexes = symbolIndexes[i];
                var liveBelow = i + 1 >= symbolIndexes.Count ? [] : symbolIndexes[i + 1];

                foreach (Match match in matches)
                {
                    AddMatches(lineAbove, match, i - 1, symbolMatches);
                    AddMatches(lineIndexes, match, i, symbolMatches);
                    AddMatches(liveBelow, match, i + 1, symbolMatches);
                }
            }

            Console.WriteLine("-------------------");
        }

        return symbolMatches.Where(x => x.Value.Count == 2).Sum(x => x.Value.Aggregate((a, b) => a * b));
    }

    private void AddMatches(List<int> line, Match match, int lineIndexY, Dictionary<string, List<int>> symbolMatches)
    {
        var indexes = line.Where(x => x >= match.Index - 1 && x <= match.Index + match.Length);
        foreach (var index in indexes)
        {
            var coords = $"{index},{lineIndexY}";
            if (symbolMatches.TryGetValue(coords, out var value))
            {
                value.Add(int.Parse(match.Value));
            }
            else
            {
                symbolMatches.Add(coords, [int.Parse(match.Value)]);
            }
            
            Console.WriteLine($"{coords} - {match.Value}");
        }
    }
}