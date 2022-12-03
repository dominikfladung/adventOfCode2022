using adventOfCode2022;

namespace TestProject1;

public class Day7Test : IDayTest
{
    public Day GetDay()
    {
        return new Day7();
    }
    
    [Test]
    public void Part1Test()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("7.txt")), Is.EqualTo(7766));
    }

    [Test]
    public void Part1SampleTest()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("7_sample.txt")), Is.EqualTo(157));
    }

    [Test]
    public void Part2Test()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("7.txt")), Is.EqualTo(2415));   
    }

    [Test]
    public void Part2SampleTest()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("7_sample.txt")), Is.EqualTo(70));
    }
}