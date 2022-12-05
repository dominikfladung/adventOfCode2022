using static System.String;

namespace adventOfCode2022;

public class Day5 : Day
{
    private class Crate
    {
        public string Value { get; }

        public Crate(string value)
        {
            char[] charsToTrim = { ' ', '[', ']' };
            Value = value.Trim(charsToTrim);
        }
    }

    private class RearrangementProcedure
    {
        public int Count { get; }
        public Stack<Crate> TargetStack { get; }
        public Stack<Crate> OriginStack { get; }

        public RearrangementProcedure(string row, IReadOnlyList<Stack<Crate>> stacks)
        {
            var parts = row.Split(' ');
            Count = int.Parse(parts[1]);
            OriginStack = stacks[int.Parse(parts[3]) - 1];
            TargetStack = stacks[int.Parse(parts[5]) - 1];
        }

        public void Process()
        {
            for (var i = 0; i < Count; i++)
            {
                var crate = OriginStack.Pop();
                TargetStack.Push(crate);
            }
        }

        public void ProcessMultiple()
        {
            var crates = new Crate[Count];
            for (var i = Count - 1; i >= 0; i--) crates[i] = OriginStack.Pop();
            foreach (var crate in crates) TargetStack.Push(crate);
        }
    }

    private static Stack<Crate>[] GetStacks(IReadOnlyList<string> puzzleInput)
    {
        var partsFirstRow = Chunk(puzzleInput[0], 4).ToArray();
        var stacks = new Stack<Crate>[partsFirstRow.Length];
        for (var i = 0; i < partsFirstRow.Length; i++) stacks[i] = new Stack<Crate>();

        foreach (var row in puzzleInput.Reverse())
        {
            if (row.Trim().Length == 0 || row.Contains("move") || row.Contains('1')) continue;

            var parts = Chunk(row, 4).ToArray();
            for (var i = 0; i < parts.Length; i++)
            {
                if (parts[i].Trim().Length == 0) continue;
                var crate = new Crate(parts[i]);
                stacks[i].Push(crate);
            }
        }

        return stacks;
    }

    private static List<RearrangementProcedure> GetRearrangementProcedures(IEnumerable<string> puzzleInput,
        IReadOnlyList<Stack<Crate>> stacks)
    {
        return (
            from row in puzzleInput
            where row.Contains("move")
            select new RearrangementProcedure(row, stacks)
        ).ToList();
    }

    public override object Part1(string[] puzzleInput)
    {
        var stacks = GetStacks(puzzleInput);
        var procedures = GetRearrangementProcedures(puzzleInput, stacks);
        foreach (var rearrangementProcedure in procedures) rearrangementProcedure.Process();

        var result = stacks.Select(stack => stack.Pop().Value).ToList();
        return Join(Empty, result);
    }

    public override object Part2(string[] puzzleInput)
    {
        var stacks = GetStacks(puzzleInput);
        var procedures = GetRearrangementProcedures(puzzleInput, stacks);
        foreach (var rearrangementProcedure in procedures) rearrangementProcedure.ProcessMultiple();

        var result = stacks.Select(stack => stack.Pop().Value).ToList();
        return Join(Empty, result);
    }
}