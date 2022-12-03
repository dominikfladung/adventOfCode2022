using adventOfCode2022;

namespace TestProject1;

public class Day5Test : IDayTest
{
    public Day GetDay()
    {
        return new Day5();
    }
    
    [Test]
    public void Part1Test()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("5.txt")), Is.EqualTo(7766));
    }

    [Test]
    public void Part1SampleTest()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("5_sample.txt")), Is.EqualTo(157));
    }

    [Test]
    public void Part2Test()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("5.txt")), Is.EqualTo(2415));   
    }

    [Test]
    public void Part2SampleTest()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("5_sample.txt")), Is.EqualTo(70));
    }
}