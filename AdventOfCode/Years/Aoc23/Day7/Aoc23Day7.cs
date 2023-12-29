namespace AdventOfCode.Years.Aoc23.Day7;

public class Aoc23Day7 : Aoc
{
    private static List<char> CardsByRank => ['2', '3', '4', '5', '6', '7', '8', '9', 'T', 'J', 'Q', 'K', 'A'];
    private static List<char> JokerCardsByRank => ['J', '2', '3', '4', '5', '6', '7', '8', '9', 'T', 'Q', 'K', 'A'];

    protected override long SolvePart1(List<string> lines) =>
        lines
            .Select(x => x.Split(' '))
            .Select(x => new Hand
            {
                Cards = x[0],
                Bid = int.Parse(x[1]),
                TypeRank = GetTypeRank(x[0])
            })
            .Order(new HandComparer())
            .Select((hand, index) => hand.Bid * (index + 1))
            .Sum();

    protected override long SolvePart2(List<string> lines)
    {
        return lines
            .Select(x => x.Split(' '))
            .Select(x => new Hand
            {
                Cards = x[0],
                Bid = int.Parse(x[1]),
                TypeRank = GetTypeRank(x[0]),
                WithJokerRank = GetJokerRank(x[0])
            })
            .Order(new JokerHandComparer())
            .Select((hand, index) => hand.Bid * (index + 1))
            .Sum();
    }

    private static int GetJokerRank(string cards) => 
        JokerCardsByRank.Select(card => GetTypeRank(cards.Replace('J', card))).Max();

    private static int GetTypeRank(string cards)
    {
        // Five of a kind
        var groups = cards.GroupBy(x => x).ToList();
        if (groups.Any(x => x.Count() == 5))
        {
            return 6;
        }

        //Four of a kind
        if (groups.Any(x => x.Count() == 4))
        {
            return 5;
        }

        //Full house
        if (groups.Any(x => x.Count() == 3) && groups.Any(x => x.Count() == 2))
        {
            return 4;
        }

        //Three of a kind
        if (groups.Any(x => x.Count() == 3))
        {
            return 3;
        }

        //Two pairs
        if (groups.Count(x => x.Count() == 2) == 2)
        {
            return 2;
        }

        //One pair
        if (groups.Any(x => x.Count() == 2))
        {
            return 1;
        }

        //High card
        return 0;
    }

    private class Hand
    {
        public string Cards { get; set; } = string.Empty;
        public int Bid { get; set; }
        public int TypeRank { get; set; }
        public int WithJokerRank { get; set; }
    }

    private class HandComparer : Comparer<Hand>
    {
        public override int Compare(Hand? x, Hand? y)
        {
            if (x!.TypeRank != y!.TypeRank)
            {
                if (x.TypeRank > y.TypeRank)
                {
                    return 1;
                }

                return -1;
            }

            for (var i = 0; i < x.Cards.Length; i++)
            {
                if (x.Cards[i] != y.Cards[i])
                {
                    if (CardsByRank.IndexOf(x.Cards[i]) > CardsByRank.IndexOf(y.Cards[i]))
                    {
                        return 1;
                    }

                    return -1;
                }
            }

            return 0;
        }
    }
    
    private class JokerHandComparer : Comparer<Hand>
    {
        public override int Compare(Hand? x, Hand? y)
        {
            if (x!.WithJokerRank != y!.WithJokerRank)
            {
                if (x.WithJokerRank > y.WithJokerRank)
                {
                    return 1;
                }

                return -1;
            }

            for (var i = 0; i < x.Cards.Length; i++)
            {
                if (x.Cards[i] != y.Cards[i])
                {
                    if (JokerCardsByRank.IndexOf(x.Cards[i]) > JokerCardsByRank.IndexOf(y.Cards[i]))
                    {
                        return 1;
                    }

                    return -1;
                }
            }

            return 0;
        }
    }
}