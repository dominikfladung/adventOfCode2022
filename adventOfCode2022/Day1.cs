namespace adventOfCode2022;

class Elve
{
    public int[] ItemCalories;

    public Elve(IEnumerable<string> itemCalories)
    {
        ItemCalories = Day.ToInt(itemCalories);
    }
    
    public int SumOfCalories()
    {
        return ItemCalories.Sum();
    }
}

public class Day1 : Day
{
    private static List<Elve> GetElves(string[] puzzleInput)
    {
        var elves = new List<Elve>();
        var chunk = new List<string>();
        foreach (var row in puzzleInput)
        {
            if (row == string.Empty)
            {
                elves.Add(new Elve(chunk));
                chunk = new List<string>();
            }
            else
            {
                chunk.Add(row);
            }
        }
        elves.Add(new Elve(chunk));

        return elves;
    }

    public override object Part1(string[] puzzleInput)
    {
        var elves = GetElves(puzzleInput);
        return elves.Select(e => e.SumOfCalories()).Max();
    }


    public override object Part2(string[] puzzleInput)
    {
        var elves = GetElves(puzzleInput);
        var top3Elves = elves.Select(e => e.SumOfCalories()).OrderByDescending(i => i).Take(3);
        return top3Elves.Sum();
    }
}
