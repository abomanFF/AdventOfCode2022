using AdventOfCode2022._09.Bridge;
using AdventOfCode2022.Base;
using Newtonsoft.Json.Linq;

namespace AdventOfCode2022._09;

public class Day9 : BaseTest
{
    [Test]
    public void SolveTestData()
    {
        Assert.That(new BridgeRunner().Solve(TestData, tails: 1), Is.EqualTo(13));
    }

    [Test]
    public void SolveData()
    {
        Assert.That(new BridgeRunner().Solve(Data, tails: 1), Is.EqualTo(5902));
    }

    //Part2
    [Test]
    public void SolveData2()
    {
        Assert.That(new BridgeRunner().Solve(Data, tails: 9), Is.EqualTo(2445));
    }

    [Test]
    public void SolveTestData1_2()
    {
        Assert.That(new BridgeRunner().Solve(TestData, tails: 9), Is.EqualTo(1));
    }

    [Test]
    public void SolveTestData2()
    {
        Assert.That(new BridgeRunner().Solve(TestData2, tails: 9), Is.EqualTo(36));
    }
}
