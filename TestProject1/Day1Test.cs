using adventOfCode2022;

namespace TestProject1;

public class Day1Test : IDayTest
{
    public Day GetDay()
    {
        return new Day1();
    }
    
    [Test]
    public void Part1Test()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("1.txt")), Is.EqualTo(69693));
    }

    [Test]
    public void Part1SampleTest()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("1_sample.txt")), Is.EqualTo(24000));
    }

    [Test]
    public void Part2Test()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("1.txt")), Is.EqualTo(200945));   
    }

    [Test]
    public void Part2SampleTest()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("1_sample.txt")), Is.EqualTo(45000));
    }
}