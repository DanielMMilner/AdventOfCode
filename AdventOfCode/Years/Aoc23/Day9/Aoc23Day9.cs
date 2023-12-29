namespace AdventOfCode.Years.Aoc23.Day9;

public class Aoc23Day9 : Aoc
{
    protected override long SolvePart1(List<string> lines)
    {
        var answers = new List<long>();

        foreach (var line in lines)
        {
            var numbers = line.Split(" ").Select(long.Parse).ToList();
            var sequence = new List<List<long>> { numbers };
            while (numbers.Any(x => x != 0))
            {
                var newNumbers = new List<long>();
                sequence.Add(newNumbers);
                for (var i = 0; i < numbers.Count - 1; i++)
                {
                    var difference = numbers[i + 1] - numbers[i];
                    newNumbers.Add(difference);
                }

                numbers = newNumbers;
            }

            for (var i = sequence.Count - 1; i >= 0; i--)
            {
                long nextNum = 0;
                if (i != sequence.Count - 1)
                {
                    nextNum = sequence[i + 1].Last() + sequence[i].Last();
                }

                sequence[i].Add(nextNum);
            }
            
            answers.Add(sequence.First().Last());
        }

        return answers.Sum();
    }

    protected override long SolvePart2(List<string> lines)
    {
        var answers = new List<long>();

        foreach (var line in lines)
        {
            var numbers = line.Split(" ").Select(long.Parse).ToList();
            var sequence = new List<List<long>> { numbers };
            while (numbers.Any(x => x != 0))
            {
                var newNumbers = new List<long>();
                sequence.Add(newNumbers);
                for (var i = 0; i < numbers.Count - 1; i++)
                {
                    var difference = numbers[i + 1] - numbers[i];
                    newNumbers.Add(difference);
                }

                numbers = newNumbers;
            }

            for (var i = sequence.Count - 1; i >= 0; i--)
            {
                long nextNum = 0;
                if (i != sequence.Count - 1)
                {
                    nextNum = sequence[i].First() - sequence[i + 1].First();
                }

                sequence[i] = sequence[i].Prepend(nextNum).ToList();
            }

            var answer = sequence.First().First();
            
            answers.Add(answer);
        }

        return answers.Sum();
    }
}