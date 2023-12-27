namespace AdventOfCode2023.Days;

public class Day1 : Day
{
    protected override int GetDayNum() => 1;

    protected override long SolvePart1(List<string> lines)
    {
        var sum = 0;
        foreach (var line in lines)
        {
            var numOnly = line.Where(char.IsNumber).ToList();
            var firstNum = numOnly.First();
            var lastNum = numOnly.Last();
            var actualNum = int.Parse($"{firstNum}{lastNum}");
            sum += actualNum;
            Console.WriteLine(actualNum);
        }

        return sum;
    }

    protected override long SolvePart2(List<string> lines)
    {
        var words = new List<string>
        {
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine"
        };
        var sum = 0;
        foreach (var line in lines)
        {
            var numIndexes = new List<(int, int)>();
            var numOnly = line.Where(char.IsNumber).Select(x => x.ToString()).ToList();
            numOnly.AddRange(words.Where(w => line.Contains(w)));
            foreach (var word in numOnly)
            {
                for (var k = line.IndexOf(word, StringComparison.Ordinal);
                     k > -1;
                     k = line.IndexOf(word, k + 1, StringComparison.Ordinal))
                {
                    var isNum = int.TryParse(word, out var num);
                    numIndexes.Add(new ValueTuple<int, int>(isNum ? num : words.IndexOf(word) + 1, k));
                }
            }

            numIndexes = numIndexes.OrderBy(x => x.Item2).ToList();
            var firstNum = numIndexes.First();
            var lastNum = numIndexes.Last();
            var actualNum = int.Parse($"{firstNum.Item1}{lastNum.Item1}");
            sum += actualNum;
            Console.WriteLine($"{line} -> {actualNum}");
        }

        return sum;
    }
}