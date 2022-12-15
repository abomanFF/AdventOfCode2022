using AdventOfCode2022._11._11;
using AdventOfCode2022.Base;
using System.Numerics;

namespace AdventOfCode2022._11;

public class Day11 : BaseTest
{
    [Test]
    public void SolveTestData()
    {
        var data = new MonkeyItemInspectors().Solve(TestData, nrOfRounds: 10000);
        Assert.That(new MonkeyItemInspectors().Solve(TestData, nrOfRounds: 20, worryDivider: 3), Is.EqualTo(10605));
        Assert.That(data, Is.EqualTo(2713310158));
    }

    [Test]
    public void SolveData()
    {
        Assert.That(new MonkeyItemInspectors().Solve(Data, nrOfRounds: 20, worryDivider: 3), Is.EqualTo(57838));
        Assert.That(new MonkeyItemInspectors().Solve(Data, nrOfRounds: 10000), Is.EqualTo(15050382231));
    }

}
