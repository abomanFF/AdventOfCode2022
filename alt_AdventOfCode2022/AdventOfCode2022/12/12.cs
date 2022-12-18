using AdventOfCode2022._12._12;
using AdventOfCode2022.Base;


namespace AdventOfCode2022._12;

public class Day12 : BaseTest
{
    [Test]
    public void SolveTestData()
    {

        Assert.That(new HillClimbingAlgorithm().Solve(TestData), Is.EqualTo(31));
    }

    [Test]
    public void SolveData()
    {
        Assert.That(new HillClimbingAlgorithm().Solve(Data), Is.EqualTo(394));
    }

    [Test]
    public void SolveTestData2()
    {
        Assert.That(new HillClimbingAlgorithm().Solve(TestData, "a"), Is.EqualTo(29));
    }

    [Test]
    public void SolveData2()
    {
        Assert.That(new HillClimbingAlgorithm().Solve(Data, "a"), Is.EqualTo(388));
    }
}
