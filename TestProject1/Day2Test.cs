using adventOfCode2022;

namespace TestProject1;

public class Day2Test : IDayTest
{
    public Day GetDay()
    {
        return new Day2();
    }
    
    [Test]
    public void Part1Test()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("2.txt")), Is.EqualTo(10310));
    }

    [Test]
    public void Part1SampleTest()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("2_sample.txt")), Is.EqualTo(15));
    }

    [Test]
    public void Part2Test()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("2.txt")), Is.EqualTo(14859));   
    }

    [Test]
    public void Part2SampleTest()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("2_sample.txt")), Is.EqualTo(12));
    }
}