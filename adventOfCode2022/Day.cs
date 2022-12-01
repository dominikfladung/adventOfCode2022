using System.Reflection;

namespace adventOfCode2022;

public abstract class Day
{
    public abstract int Part1(string[] puzzleInput);
    public abstract int Part2(string[] puzzleInput);

    public static string[] GetPuzzleInput(string fileName)
    {
        var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty, @"../../../inputs/" + fileName);
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
}