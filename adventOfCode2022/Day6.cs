namespace adventOfCode2022;

public class Day6 : Day
{
    public override object Part1(string[] puzzleInput)
    {
        var datastream = puzzleInput[0];
        return GetMarker(datastream, 4);
    }

    public override object Part2(string[] puzzleInput)
    {
        var datastream = puzzleInput[0];
        return GetMarker(datastream, 14);
    }

    private static object GetMarker(string datastream, int size)
    {
        var buffer = new Queue<char>();
        
        for (var i = 0; i < datastream.Length; i++)
        {
            var c = datastream[i];
            if (i < size)
            {
                buffer.Enqueue(c);
            }
            else if (buffer.Distinct().Count() == size)
            {
                return i;
            }
            else
            {
                buffer.Dequeue();
                buffer.Enqueue(c);
            }
        }

        return -1;
    }
}