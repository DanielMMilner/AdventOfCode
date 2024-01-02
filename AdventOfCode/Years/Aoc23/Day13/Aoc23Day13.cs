namespace AdventOfCode.Years.Aoc23.Day13;

public class Aoc23Day13 : Aoc
{
    protected override long SolvePart1(List<string> lines) => GetSum(lines, false);

    protected override long SolvePart2(List<string> lines) => GetSum(lines, true);

    private static int GetSum(List<string> lines, bool fixSmudge) =>
        GetMirrors(lines)
            .Select(mirror =>
            {
                var mirrorPosHorizontal = GetMirrorPosition(mirror.Horizontal, fixSmudge);
                var mirrorPosVertical = GetMirrorPosition(mirror.Vertical, fixSmudge);
                return mirrorPosHorizontal != -1 ? mirrorPosHorizontal * 100 : mirrorPosVertical;
            })
            .Sum();

    private static int GetMirrorPosition(IReadOnlyList<string> mirror, bool fixSmudge)
    {
        for (var i = 0; i < mirror.Count; i++)
        {
            var offset = 0;
            var matches = true;
            var smudgeFixed = false;
            while (matches && i - offset >= 0 && i + offset + 1 < mirror.Count)
            {
                (matches, var smudgeWasFixed) =
                    CompareStrings(mirror[i - offset], mirror[i + offset + 1], fixSmudge && !smudgeFixed);
                if (fixSmudge && smudgeWasFixed)
                {
                    smudgeFixed = true;
                }

                if (matches)
                {
                    offset++;
                }
            }

            var touchesEdge = i + 1 - offset != 0 && offset + i + 1 != mirror.Count;
            if (offset == 0 || touchesEdge)
                continue;

            if (!fixSmudge || fixSmudge && smudgeFixed)
            {
                return i + 1;
            }
        }

        return -1;
    }

    private static (bool matches, bool smudgeFixed) CompareStrings(string string1, string string2, bool fixSmudge)
    {
        if (!fixSmudge)
        {
            return (string1 == string2, false);
        }

        var smudgeFixed = false;
        for (var i = 0; i < string1.Length; i++)
        {
            if (string1[i] != string2[i])
            {
                if (smudgeFixed)
                {
                    return (false, smudgeFixed);
                }

                smudgeFixed = true;
            }
        }

        return (true, smudgeFixed);
    }

    private static List<Mirror> GetMirrors(List<string> lines)
    {
        var mirrorsStrings = new List<List<string>>();
        var m = new List<string>();
        foreach (var line in lines)
        {
            if (line == string.Empty)
            {
                mirrorsStrings.Add(m);
                m = [];
            }
            else
            {
                m.Add(line);
            }
        }

        mirrorsStrings.Add(m);

        var mirrors = new List<Mirror>();
        foreach (var mirrorsString in mirrorsStrings)
        {
            var mirror = new Mirror
            {
                Horizontal = mirrorsString
            };
            var length = mirrorsString[0].Length;

            for (var i = 0; i < length; i++)
            {
                mirror.Vertical.Add(mirrorsString.Aggregate(string.Empty, (current, ms) => current + ms[i]));
            }

            mirrors.Add(mirror);
        }

        return mirrors;
    }

    private class Mirror
    {
        public List<string> Horizontal { get; init; } = [];
        public List<string> Vertical { get; } = [];
    }
}