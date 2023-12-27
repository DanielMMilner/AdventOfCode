using System.Text.RegularExpressions;

namespace AdventOfCode2023.Days;

public class Day2 : Day
{
    protected override int GetDayNum() => 2;

    protected override long SolvePart1(List<string> lines)
    {
        const int red = 12;
        const int green = 13;
        const int blue = 14;
        var games = CreateGames(lines);

        var possibleGames =
            games.Where(game => game.Draws.All(x => x.Red <= red && x.Blue <= blue && x.Green <= green));

        return possibleGames.Sum(x => x.Id);
    }

    protected override long SolvePart2(List<string> lines)
    {
        var games = CreateGames(lines);

        return games.Sum(x => x.Power);
    }

    private IEnumerable<Game> CreateGames(List<string> lines)
    {
        var redRegex = new Regex(" \\d+ red");
        var greenRegex = new Regex(" \\d+ green");
        var blueRegex = new Regex(" \\d+ blue");

        return lines.Select(line =>
        {
            var split = line.Split(":");
            var draws = split.Last()
                .Split(";")
                .Select(x => new GameDraw
                {
                    Red = GetNum(x, redRegex, " red"),
                    Blue = GetNum(x, blueRegex, " blue"),
                    Green = GetNum(x, greenRegex, " green")
                }).ToList();

            return new Game
            {
                Id = int.Parse(split.First().Replace("Game ", string.Empty)),
                Draws = draws
            };
        });
    }

    private static int GetNum(string draw, Regex regex, string replace)
    {
        var match = regex.Match(draw);
        return match.Success ? int.Parse(match.Value.Replace(replace, string.Empty)) : 0;
    }

    private class Game
    {
        public int Id { get; init; }
        public IEnumerable<GameDraw> Draws { get; init; } = new List<GameDraw>();
        private int RequiredRed => Draws.Max(x => x.Red);
        private int RequiredGreen => Draws.Max(x => x.Green);
        private int RequiredBlue => Draws.Max(x => x.Blue);
        public int Power => RequiredRed * RequiredGreen * RequiredBlue;
    }

    private class GameDraw
    {
        public int Red { get; init; }
        public int Green { get; init; }
        public int Blue { get; init; }
    }
}