using System.Collections.Concurrent;

namespace AdventOfCode.Years.Aoc23.Day12;

public class Aoc23Day12 : Aoc
{
    protected override long SolvePart1(List<string> lines) => Solve(lines, 1);

    protected override long SolvePart2(List<string> lines) => Solve(lines, 5);

    private long Solve(List<string> lines, int multiplier)
    {
        var totals = new ConcurrentBag<long>();

        var chunkedLines = lines.Chunk(lines.Count / 1);
        Parallel.ForEach(chunkedLines, cl =>
        {
            var c = 0;
            foreach (var line in cl)
            {
                c++;
                var data = line.Split(' ');
                var report = string.Join('?', Enumerable.Repeat(data[0], multiplier)).Select(x => x).ToArray();
                var nums = string.Join(',', Enumerable.Repeat(data[1], multiplier)).Split(',').Select(int.Parse)
                    .ToArray();
                var original = new char[report.Length];
                report.CopyTo(original, 0);
                var count = GetCount(nums, report, 0, -2, 0, original);
                totals.Add(count);
                Console.WriteLine(
                    "{0,-30}{1,-25}{2,-20}{3,-20}{4,-15}",
                    line,
                    $"Completed: ({c} / {cl.Length})",
                    $"Total: ({totals.Count} / {lines.Count})",
                    $"Count: {count}",
                    $"Sum: {totals.Sum()}"
                );
                Console.WriteLine(
                    "-----------------------------------------------------------------------------------------------------------");
            }
        });

        return totals.Sum();
    }

    private long GetCount(int[] nums, char[] line, long count, int lastMatch, int numIndex, char[] original)
    {
        Console.WriteLine(line);
        if (numIndex >= nums.Length)
        {
            //If we have run out of numbers and there are no more '#' then we have a valid line
            for (var i = lastMatch + 1; i < line.Length; i++)
            {
                if (line[i] == '#')
                {
                    return count;
                }
            }

            return ++count;
        }

        var num = nums[numIndex];
        var matchIndex = Match(line, num, lastMatch);
        
        while (matchIndex != -1)
        {
            //replace the match with an 'x' to prevent it from being found again
            for (var i = matchIndex; i < matchIndex + num; i++)
            {
                line[i] = 'x';
            }

            var newCount = GetCount(nums, line, count, matchIndex, numIndex + 1, original);

            count = newCount;

            var found = false;
            for (var i = matchIndex; i < line.Length; i++)
            {
                if (i < matchIndex + num && !found && original[i] == '?')
                {
                    found = true;
                    line[i] = '.';
                }
                else if (original[i] == '#' && !found)
                {
                    return count;
                }
                else
                {
                    line[i] = original[i];
                }
            }

            if (!found)
            {
                return count;
            }

            matchIndex = Match(line, num, matchIndex - 1);
        }

        return count;
    }

    private static int Match(char[] line, int num, int lastMatch)
    {
        for (var i = lastMatch + 2; i < line.Length; i++)
        {
            if (line[i] == '.')
            {
                continue;
            }

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