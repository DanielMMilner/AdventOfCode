using System.Collections.Concurrent;

namespace AdventOfCode.Years.Aoc23.Day12;

public class Aoc23Day12 : Aoc
{
    protected override long SolvePart1(List<string> lines) => Solve(lines, 1);

    protected override long SolvePart2(List<string> lines) => Solve(lines, 5);

    private long Solve(List<string> lines, int multiplier)
    {
        var totals = new ConcurrentBag<int>();

        var chunkedLines = lines.Chunk(lines.Count / 1);
        Parallel.ForEach(chunkedLines, cl =>
        {
            foreach (var line in cl)
            {
                var data = line.Split(' ');
                var report = string.Join('?', Enumerable.Repeat(data[0], multiplier)).Select(x => x).ToArray();
                var nums = string.Join(',', Enumerable.Repeat(data[1], multiplier)).Split(',').Select(int.Parse)
                    .ToArray();
                var count = GetCount(nums, report, 0, -1, 0);
                totals.Add(count);
            }
        });

        return totals.Sum();
    }

    private int GetCount(int[] nums, char[] line, int count, int lastMatch, int numIndex)
    {
        if (numIndex >= nums.Length)
        {
            //If we have run out of numbers and there are no more '#' then we have a valid line
            if (!line.Contains('#'))
            {
                count++;
            }

            return count;
        }

        var num = nums[numIndex];
        var matchIndex = Match(line, num, lastMatch);

        while (matchIndex != -1)
        {
            //replace the match with an 'x' to prevent it from being found again
            var newLine = new char[line.Length];
            line.CopyTo(newLine, 0);
            for (var i = matchIndex; i < matchIndex + num; i++)
            {
                newLine[i] = 'x';
            }

            count = GetCount(nums, newLine, count, matchIndex, numIndex + 1);

            var found = false;
            for (var i = matchIndex; i < matchIndex + num; i++)
            {
                if (line[i] == '?')
                {
                    found = true;
                    line[i] = '.';
                    break;
                }
            }

            if (!found)
            {
                return count;
            }

            matchIndex = Match(line, num, matchIndex);
        }

        return count;
    }

    private static int Match(char[] line, int num, int startIndex)
    {
        startIndex = startIndex == -1 ? 0 : startIndex;
        for (var i = startIndex; i < line.Length; i++)
        {
            var match = true;
            for (var j = 0; j < num; j++)
            {
                //reached end of line so match is no longer possible
                if (i + j >= line.Length)
                {
                    match = false;
                    break;
                }

                //if the next char is not a # or ? then match is no longer possible
                var next = line[i + j];
                if (next != '#' && next != '?')
                {
                    match = false;
                    break;
                }
            }

            if (match)
            {
                //If the match has a '.' or '?' before and after it or its the start/end of the line then it is a valid match
                var before = i - 1 < 0 ? '.' : line[i - 1];
                var after = i + num >= line.Length ? '.' : line[i + num];
                if (before is '.' or '?' && after is '.' or '?')
                {
                    return i;
                }
            }

            //If the current char is a '#' and we didnt find a match then its no longer possible to find a full match
            if (line[i] == '#')
            {
                return -1;
            }
        }

        return -1;
    }
}