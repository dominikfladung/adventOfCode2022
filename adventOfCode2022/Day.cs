using System.Reflection;

namespace adventOfCode2022;

public abstract class Day
{
    public abstract object Part1(string[] puzzleInput);
    public abstract object Part2(string[] puzzleInput);

    public static string[] GetPuzzleInput(string fileName)
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty,
            @"../../../inputs/" + fileName);
        var fullPath = Path.Combine(Directory.GetCurrentDirectory(), path);
        return File.ReadAllLines(fullPath);
    }

    public static int[] ToInt(string[] array)
    {
        return Array.ConvertAll(array, int.Parse);
    }

    public static int[] ToInt(IEnumerable<string> list)
    {
        return list.Select(int.Parse).ToArray();
    }

    public static int BinaryToInt(string binaryString)
    {
        return Convert.ToInt32(binaryString, 2);
    }

    public static string IntToBinary(int number)
    {
        return Convert.ToString(number, 2);
    }

    protected static char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

    protected static char[] alphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    
    public static IEnumerable<string> Chunk(string str, int n)
    {
        if (string.IsNullOrEmpty(str) || n < 1) {
            throw new ArgumentException("String is Empty");
        }

        var chunks = new List<string>();
        for (var i = 0; i < str.Length; i += n) {
            chunks.Add(str.Substring(i, Math.Min(n, str.Length - i)));
        }

        return chunks;
    }
}