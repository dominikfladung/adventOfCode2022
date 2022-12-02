namespace adventOfCode2022;

public class Day2 : Day
{
    private enum Hand
    {
        Rock,
        Scissors,
        Paper
    }

    private class Round
    {
        protected Hand OpponentHand { get; }
        protected Hand MyHand { get; set; }
        
        protected string MyHandKey { get; }
        private string OpponentHandKey { get; }

        public Round(string row)
        {
            var hands = row.Split(" ");
            OpponentHandKey = hands[0];
            MyHandKey = hands[1];
            
            OpponentHand = OpponentHandKey switch
            {
                "A" => Hand.Rock,
                "B" => Hand.Paper,
                "C" => Hand.Scissors,
                _ => OpponentHand
            };

            MyHand = MyHandKey switch
            {
                "Y" => Hand.Paper,
                "X" => Hand.Rock,
                "Z" => Hand.Scissors,
                _ => MyHand
            };
        }

        private bool Win()
        {
            return (OpponentHand == Hand.Rock && MyHand == Hand.Paper) ||
                   (OpponentHand == Hand.Scissors && MyHand == Hand.Rock) ||
                   (OpponentHand == Hand.Paper && MyHand == Hand.Scissors);
        }

        private bool IsDraw()
        {
            return OpponentHand == MyHand;
        }

        public int Play()
        {
            var points = 0;
            if (Win())
                points += 6;
            else if (IsDraw()) points += 3;

            points += MyHand switch
            {
                Hand.Rock => 1,
                Hand.Paper => 2,
                Hand.Scissors => 3,
                _ => 0
            };

            return points;
        }
    }

    private class RoundPart2 : Round
    {
        public RoundPart2(string row) : base(row)
        {
            MyHand = MyHandKey switch
            {
                "Y" => OpponentHand, // draw
                "X" => GetLooseHand(OpponentHand),
                "Z" => GetWinHand(OpponentHand),
                _ => MyHand
            };
        }

        private static Hand GetWinHand(Hand hand)
        {
            return hand switch
            {
                Hand.Rock => Hand.Paper,
                Hand.Paper => Hand.Scissors,
                Hand.Scissors => Hand.Rock,
                _ => hand
            };
        }

        private static Hand GetLooseHand(Hand hand)
        {
            return hand switch
            {
                Hand.Rock => Hand.Scissors,
                Hand.Paper => Hand.Rock,
                Hand.Scissors => Hand.Paper,
                _ => hand
            };
        }
    }
    
    

    public override int Part1(string[] puzzleInput)
    {
        return puzzleInput.Select(row => new Round(row).Play()).Sum();
    }

    public override int Part2(string[] puzzleInput)
    {
        return puzzleInput.Select(row => new RoundPart2(row).Play()).Sum();
    }
}