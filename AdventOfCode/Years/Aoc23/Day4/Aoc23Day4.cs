namespace AdventOfCode.Years.Aoc23.Day4;

public class Aoc23Day4 : Aoc
{
    protected override long SolvePart1(List<string> lines)
    {
        double sum = 0;
        foreach (var line in lines)
        {
            var foundWinningNumbers = GetFoundWinningNumbers(line);
            if (foundWinningNumbers > 0)
            {
                sum += 1 << (foundWinningNumbers - 1);
            }
        }

        return (int)sum;
    }

    protected override long SolvePart2(List<string> lines)
    {
        var scratchCards = Enumerable.Repeat(1, lines.Count).ToArray();
        for (var i = 0; i < lines.Count; i++)
        {
            var foundWinningNumbers = GetFoundWinningNumbers(lines[i]);

            for (var j = i + 1; j < i + 1 + foundWinningNumbers; j++)
            {
                scratchCards[j] += scratchCards[i];
            }
        }

        return scratchCards.Sum();
    }

    private static int GetFoundWinningNumbers(string line)
    {
        var match = line.Split(":");
        var card = match[1].Split("|");
        var winningNumbers = card[0].Split(" ").Where(x => !string.IsNullOrEmpty(x));
        var gameNumbers = card[1].Split(" ").Where(x => !string.IsNullOrEmpty(x));
        var foundWinningNumbers = gameNumbers.Count(x => winningNumbers.Contains(x));
        return foundWinningNumbers;
    }
}