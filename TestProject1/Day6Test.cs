using adventOfCode2022;

namespace TestProject1;

public class Day6Test : IDayTest
{
    public Day GetDay()
    {
        return new Day6();
    }
    
    [Test]
    public void Part1Test()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("6.txt")), Is.EqualTo(1235));
    }

    [Test]
    public void Part1SampleTest()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("6_sample.txt")), Is.EqualTo(7));
    }
    
    [Test]
    public void Part1SampleTest2()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("6_sample_2.txt")), Is.EqualTo(5));
    }

    [Test]
    public void Part1SampleTest3()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("6_sample_3.txt")), Is.EqualTo(6));
    }
    
    [Test]
    public void Part1SampleTest4()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("6_sample_4.txt")), Is.EqualTo(10));
    }
    
    [Test]
    public void Part1SampleTest5()
    {
        Assert.That(GetDay().Part1(Day.GetPuzzleInput("6_sample_5.txt")), Is.EqualTo(11));
    }
    
    
    [Test]
    public void Part2Test()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("6.txt")), Is.EqualTo(3051));   
    }

    [Test]
    public void Part2SampleTest()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("6_sample.txt")), Is.EqualTo(19));
    }
    
    [Test]
    public void Part2SampleTest2()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("6_sample_2.txt")), Is.EqualTo(23));
    }

    [Test]
    public void Part2SampleTest3()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("6_sample_3.txt")), Is.EqualTo(23));
    }
    
    [Test]
    public void Part2SampleTest4()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("6_sample_4.txt")), Is.EqualTo(29));
    }
    
    [Test]
    public void Part2SampleTest5()
    {
        Assert.That(GetDay().Part2(Day.GetPuzzleInput("6_sample_5.txt")), Is.EqualTo(26));
    }
}