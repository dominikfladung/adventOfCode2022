using adventOfCode2022;

namespace TestProject1;

public class Day11Test : IDayTest
{
    public Day GetDay()
    {
        return new Day11();
    }

    [Test]
    public void Part1Test()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("11.txt")), Is.EqualTo(110888));
    }

    [Test]
    public void Part1SampleTest()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("11_sample.txt")), Is.EqualTo(10605));
    }

    [Test]
    public void Part2Test()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("11.txt")), Is.EqualTo(2713310158));   
    }

    [Test]
    public void Part2SampleTest()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("11_sample.txt")), Is.EqualTo(2713310158));
    }
}