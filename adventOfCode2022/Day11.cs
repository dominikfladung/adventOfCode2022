namespace adventOfCode2022;

public class Day11 : Day
{
    private class Monkey : IComparable
    {
        public int OperationCounter = 0;
        public int Number { get; set; }
        public List<long> Items { get; set; }
        public Func<long, long> Operation { get; set; }
        
        public int DivisibleBy { get; set; }
        public int IfTrueMonkey { get; set; }
        public int IfFalseMonkey { get; set; }
        
        public int CompareTo(object? obj)
        {
            if (obj is Monkey other)
            {
                return other.OperationCounter.CompareTo(OperationCounter);
            }

            return 0;
        }
    }

    private List<Monkey> GetMonkeys(string[] puzzleInput)
    {
        var chunks = Chunk(puzzleInput, 7);

        return chunks.Select(chunk =>
            {
                var number = int.Parse(chunk[0].Replace("Monkey ", "").Replace(":", "").Trim());
                var items = chunk[1].Replace("Starting items: ", "").Split(',').Select(long.Parse).ToList();
                var operation = GetOperation(chunk[2].Replace("Operation: new = old ", "").Trim());
                var divisibleBy = int.Parse(chunk[3].Replace("Test: divisible by ", "").Trim());
                var ifTrueMonkey = int.Parse(chunk[4].Replace("If true: throw to monkey ", "").Trim());
                var ifFalseMonkey = int.Parse(chunk[5].Replace("If false: throw to monkey ", "").Trim());
                return new Monkey
                {
                    Number = number,
                    Items = items,
                    Operation = operation,
                    DivisibleBy = divisibleBy,
                    IfTrueMonkey = ifTrueMonkey,
                    IfFalseMonkey = ifFalseMonkey,
                };
            })
            .ToList();
    }
    private static Func<long, long> GetOperation(string row)
        {
            if(row.StartsWith("* old"))
            {
                return old => old * old;
            }
            if (row.StartsWith("+ old"))
            {
                return old => old + old;
            }
            
            if (row.StartsWith("*"))
            {
                return old => old * int.Parse(row.Replace("* ", ""));
            } 
           
            return old => old + int.Parse(row.Replace("+ ", ""));
        }

    public override object Part1(string[] puzzleInput)
    {
        var monkeys = GetMonkeys(puzzleInput);
        for (var i = 0; i < 20; i++)
        {
            foreach (var monkey in monkeys)
            {
                monkey.Items.ForEach(item =>
                {
                    monkey.OperationCounter++;
                    var result = monkey.Operation(item) / 3;
                    if (result % monkey.DivisibleBy == 0)
                    {
                        monkeys.First(e => e.Number == monkey.IfTrueMonkey).Items.Add(result);
                    }
                    else
                    {
                        monkeys.First(e => e.Number == monkey.IfFalseMonkey).Items.Add(result);
                    }
                });
                monkey.Items.Clear();
            }
        }

        monkeys.Sort();
        return monkeys
            .Take(2)
            .Select(e => e.OperationCounter)
            .Aggregate((a,b) => a * b);
    }

    public override object Part2(string[] puzzleInput)
    {
        var monkeys = GetMonkeys(puzzleInput);
        for (var i = 0; i < 10_000; i++)
        {
            foreach (var monkey in monkeys)
            {
                monkey.Items.ForEach(item =>
                {
                    monkey.OperationCounter++;
                    var result = monkey.Operation(item) % monkey.DivisibleBy;
                    if (result % monkey.DivisibleBy == 0)
                    {
                        monkeys.First(e => e.Number == monkey.IfTrueMonkey).Items.Add(result);
                    }
                    else
                    {
                        monkeys.First(e => e.Number == monkey.IfFalseMonkey).Items.Add(result);
                    }
                });
                monkey.Items.Clear();
            }
        }

        monkeys.Sort();
        var result = monkeys
            .Take(2)
            .Select(e => e.OperationCounter)
            .Aggregate((a,b) => a * b);
        return result;
    }
}