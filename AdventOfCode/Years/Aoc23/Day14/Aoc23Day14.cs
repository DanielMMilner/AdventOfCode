namespace AdventOfCode.Years.Aoc23.Day14;

public class Aoc23Day14 : Aoc
{
    private const char SquareRock = '#';
    private const char CircleRock = 'O';
    private const char Empty = '.';

    protected override long SolvePart1(List<string> lines)
    {
        var charLines = lines.Select(x => x.ToCharArray()).ToArray();
        Tilt(charLines, Direction.North);
        foreach (var charLine in charLines)
        {
            Console.WriteLine(string.Join("", charLine));
        }

        return CountLoad(charLines);
    }

    protected override long SolvePart2(List<string> lines)
    {
        var directions = new[] { Direction.North, Direction.West, Direction.South, Direction.East };
        var charLines = lines.Select(x => x.ToCharArray()).ToArray();
        var cache = new List<string>();
        var foundLoop = false;
        var cacheKey = string.Empty;

        //Continue cycling until we find a loop
        while (!foundLoop)
        {
            foreach (var direction in directions)
            {
                Tilt(charLines, direction);
            }

            cacheKey = string.Join("", charLines.Select(x => string.Join("", x)));

            if (cache.Contains(cacheKey))
            {
                foundLoop = true;
            }
            else
            {
                cache.Add(cacheKey);
            }
        }

        var loopStart = cache.IndexOf(cacheKey);
        var loopSize = cache.Count - loopStart;

        //Finish off the current loop as we have already done the first iteration
        for (var i = 1; i < loopSize; i++)
        {
            foreach (var direction in directions)
            {
                Tilt(charLines, direction);
            }
        }

        //Calculate the remainder of the loops
        var remainder = (1_000_000_000 - loopStart) % loopSize;

        //Finish off the remaining loops
        for (var i = 0; i < remainder; i++)
        {
            foreach (var direction in directions)
            {
                Tilt(charLines, direction);
            }
        }

        return CountLoad(charLines);
    }

    private static int CountLoad(IReadOnlyCollection<char[]> charLines) =>
        charLines
            .Select(t => t.Count(x => x == CircleRock))
            .Select((count, i) => count * (charLines.Count - i))
            .Sum();

    private static void Tilt(char[][] charLines, Direction direction)
    {
        switch (direction)
        {
            case Direction.North:
                TiltNorth(charLines);
                break;
            case Direction.West:
                TiltWest(charLines);
                break;
            case Direction.South:
                TiltSouth(charLines);
                break;
            case Direction.East:
                TiltEast(charLines);
                break;
        }
    }

    private static void TiltNorth(char[][] rocks)
    {
        for (var col = 0; col < rocks[0].Length; col++)
        {
            var squareIndex = -1;
            var circleCount = 0;
            for (var row = 0; row < rocks.Length; row++)
            {
                if (rocks[row][col] == CircleRock)
                {
                    circleCount++;
                }

                if (rocks[row][col] == SquareRock || row == rocks.Length - 1)
                {
                    for (var j = squareIndex + 1; j <= row; j++)
                    {
                        circleCount = RollRocks(rocks, j, col, circleCount);
                    }
                }

                if (rocks[row][col] == SquareRock)
                {
                    squareIndex = row;
                    circleCount = 0;
                }
            }
        }
    }

    private static void TiltSouth(char[][] rocks)
    {
        for (var col = 0; col < rocks[0].Length; col++)
        {
            var squareIndex = rocks.Length;
            var circleCount = 0;
            for (var row = rocks.Length - 1; row >= 0; row--)
            {
                if (rocks[row][col] == CircleRock)
                {
                    circleCount++;
                }

                if (rocks[row][col] == SquareRock || row == 0)
                {
                    for (var j = squareIndex - 1; j >= row; j--)
                    {
                        circleCount = RollRocks(rocks, j, col, circleCount);
                    }
                }

                if (rocks[row][col] == SquareRock)
                {
                    squareIndex = row;
                    circleCount = 0;
                }
            }
        }
    }

    private static void TiltWest(char[][] rocks)
    {
        for (var row = 0; row < rocks.Length; row++)
        {
            var squareIndex = -1;
            var circleCount = 0;
            for (var col = 0; col < rocks[row].Length; col++)
            {
                if (rocks[row][col] == CircleRock)
                {
                    circleCount++;
                }

                if (rocks[row][col] == SquareRock || col == rocks[row].Length - 1)
                {
                    for (var j = squareIndex + 1; j <= col; j++)
                    {
                        circleCount = RollRocks(rocks, row, j, circleCount);
                    }
                }

                if (rocks[row][col] == SquareRock)
                {
                    squareIndex = col;
                    circleCount = 0;
                }
            }
        }
    }

    private static void TiltEast(char[][] rocks)
    {
        for (var row = 0; row < rocks.Length; row++)
        {
            var squareIndex = rocks.Length;
            var circleCount = 0;
            for (var col = rocks[row].Length - 1; col >= 0; col--)
            {
                if (rocks[row][col] == CircleRock)
                {
                    circleCount++;
                }

                if (rocks[row][col] == SquareRock || col == 0)
                {
                    for (var j = squareIndex - 1; j >= col; j--)
                    {
                        circleCount = RollRocks(rocks, row, j, circleCount);
                    }
                }

                if (rocks[row][col] == SquareRock)
                {
                    squareIndex = col;
                    circleCount = 0;
                }
            }
        }
    }

    private static int RollRocks(char[][] rocks, int row, int col, int circleCount)
    {
        if (rocks[row][col] == SquareRock)
        {
            return circleCount;
        }

        if (circleCount != 0)
        {
            rocks[row][col] = CircleRock;
            return circleCount - 1;
        }

        rocks[row][col] = Empty;
        return circleCount;
    }

    private enum Direction
    {
        North,
        West,
        South,
        East
    }
}