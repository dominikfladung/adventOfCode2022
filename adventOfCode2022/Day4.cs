namespace adventOfCode2022;

public class Day4 : Day
{
    private class Elve
    {
        public int Start { get; set; }
        public int End { get; set; }


        public Elve(string range)
        {
            var parts = range.Split('-');
            Start = int.Parse(parts[0]);
            End = int.Parse(parts[1]);
        }
    }

    private class ElvePair
    {
        private Elve Elve1 { get; set; }
        private Elve Elve2 { get; set; }
        
        public ElvePair(string row)
        {
            var parts = row.Split(',');
            Elve1 = new Elve(parts[0]);
            Elve2 = new Elve(parts[1]);
        }

        public bool IsOverlap()
        {
            return Elve1.End >= Elve2.Start && Elve1.Start <= Elve2.End;
        }
        
        public bool IsElve1FullInRange()
        {
            return Elve1.Start >= Elve2.Start && Elve1.End <= Elve2.End;
        }
        
        public bool IsElve2FullInRange()
        {
            return Elve2.Start >= Elve1.Start && Elve2.End <= Elve1.End;
        }
    }
    
    public override int Part1(string[] puzzleInput)
    {
        var pairs = puzzleInput.Select(x => new ElvePair(x));
        var count = pairs.Count(x => x.IsElve1FullInRange() || x.IsElve2FullInRange());
        return count;
    }

    public override int Part2(string[] puzzleInput)
    {
        var pairs = puzzleInput.Select(x => new ElvePair(x));
        var count = pairs.Count(x => x.IsOverlap());
        return count;
    }
}