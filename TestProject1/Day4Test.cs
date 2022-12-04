using adventOfCode2022;

namespace TestProject1;

public class Day4Test : IDayTest
{
    public Day GetDay()
    {
        return new Day4();
    }
    
    [Test]
    public void Part1Test()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("4.txt")), Is.EqualTo(534));
    }

    [Test]
    public void Part1SampleTest()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("4_sample.txt")), Is.EqualTo(2));
    }

    [Test]
    public void Part2Test()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("4.txt")), Is.EqualTo(2415));   
    }

    [Test]
    public void Part2SampleTest()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("4_sample.txt")), Is.EqualTo(4));
    }
}