namespace AdventOfCode2023.Days;

public class Day8 : Day
{
    protected override long SolvePart1(List<string> lines)
    {
        var steps = lines[0].Select(x => x).ToList();
        var network = lines
            .Skip(2)
            .ToDictionary(
                line => line.Split(" = ")[0],
                line =>
                {
                    var network = line
                        .Split(" = ")[1]
                        .Replace("(", string.Empty)
                        .Replace(")", string.Empty)
                        .Split(", ");
                    return new Network
                    {
                        Left = network[0],
                        Right = network[1]
                    };
                });

        var count = 0;
        var stepIndex = 0;
        var current = "AAA";
        var currentStep = network[current];
        while (current != "ZZZ")
        {
            var step = steps[stepIndex];
            current = step == 'R' ? currentStep.Right : currentStep.Left;

            currentStep = network[current];
            count++;
            stepIndex++;
            if (stepIndex >= steps.Count)
            {
                stepIndex = 0;
            }
        }

        return count;
    }

    protected override long SolvePart2(List<string> lines)
    {
        var steps = lines[0].Select(x => x).ToList();
        var network = lines
            .Skip(2)
            .ToDictionary(
                line => line.Split(" = ")[0],
                line =>
                {
                    var network = line
                        .Split(" = ")[1]
                        .Replace("(", string.Empty)
                        .Replace(")", string.Empty)
                        .Split(", ");
                    return new Network
                    {
                        Left = network[0],
                        Right = network[1]
                    };
                });

        var currentSteps = network.Where(x => x.Key.EndsWith('A')).Select(x => x.Key).ToArray();
        var ghostCounts = new List<long>();

        foreach (var stp in currentSteps)
        {
            var count = 0;
            var stepIndex = 0;
            var current = stp;
            var currentStep = network[current];
            while (current[2] != 'Z')
            {
                var step = steps[stepIndex];
                current = step == 'R' ? currentStep.Right : currentStep.Left;

                currentStep = network[current];
                count++;
                stepIndex++;
                if (stepIndex >= steps.Count)
                {
                    stepIndex = 0;
                }
            }

            ghostCounts.Add(count);
        }

        return ghostCounts.Aggregate((a, b) => a * b / GreatestCommonFactor(a, b));
    }

    private static long GreatestCommonFactor(long a, long b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    private class Network
    {
        public string Left { get; init; } = string.Empty;
        public string Right { get; init; } = string.Empty;
    }
}