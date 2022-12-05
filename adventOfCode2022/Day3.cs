namespace adventOfCode2022;

public class Day3 : Day
{
    private Dictionary<char, int> priorityValues = new();

    private void InitPriorities()
    {
        var counter = 1;
        foreach (var c in alphabet)
        {
            priorityValues.Add(c, counter);
            counter++;
        }
            
        foreach (var c in alphabetUpper)
        {
            priorityValues.Add(c, counter);
            counter++;
        }
    }

    public Day3()
    {
        InitPriorities();
    }
    
    private class Rucksack
    {
        public IEnumerable<char> firstCompartments;
        public IEnumerable<char> secondCompartments;
        public IEnumerable<char> allItems;
        
        public Rucksack(string row)
        {
            firstCompartments = row.Take(row.Length / 2);
            secondCompartments = row.Skip(row.Length / 2);
            allItems = row;
        }

        public char? GetItemInBothCompartments()
        {
            foreach (var c in firstCompartments.Where(c => secondCompartments.Contains(c)))
            {
                return c;
            }

            return null;
        }
    }

    private class RucksackGroup
    {
        IEnumerable<Rucksack> rucksacks;

        public RucksackGroup(IEnumerable<Rucksack> rucksacks)
        {
            this.rucksacks = rucksacks;
        }

        public char? GetUsedCharInAllRucksacks()
        {
            var possibleChars = rucksacks.First().allItems;
            foreach (var rucksack in rucksacks)
            {
                possibleChars = possibleChars.Intersect(rucksack.allItems);
            }
            return possibleChars.First();
        }
    }
    
    public override object Part1(string[] puzzleInput)
    {
        var rucksacks = puzzleInput.Select(row => new Rucksack(row));
        var items = rucksacks.Select(rucksack => rucksack.GetItemInBothCompartments());
        var priorities = items.Select(item => priorityValues[item ?? ' ']);
        return priorities.Sum();
    }

    public override object Part2(string[] puzzleInput)
    {
        var counter = 0;
        var groups = new List<RucksackGroup>();
        var rucksacks = new List<Rucksack>();
        
        foreach (var row in puzzleInput)
        {
            rucksacks.Add(new Rucksack(row));
            
            if (counter != 0 && (counter + 1) % 3 == 0)
            {
                groups.Add(new RucksackGroup(rucksacks));
                rucksacks = new List<Rucksack>();
            }
            
            counter++;
        }

        var chars = groups.Select(group => group.GetUsedCharInAllRucksacks()).ToList();
        var priorities = chars.Select(c => priorityValues[c ?? 'a']);
        return priorities.Sum();
    }
}