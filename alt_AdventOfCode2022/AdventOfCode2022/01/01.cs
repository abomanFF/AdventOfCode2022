using AdventOfCode2022.Base;

namespace AdventOfCode2022._01;

public class Tests : BaseTest
{
    private int Solve(string input) => input
            .Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(l => l.Split($"{Environment.NewLine}")
                .Where(n => n != String.Empty).Select(n => int.Parse(n))
                .Sum())
            .Max();

    [Test]
    public void SolveTestData()
    {
        Assert.That(Solve(TestData), Is.EqualTo(24000));
    }

    [Test]
    public void SolveData()
    {
        Assert.That(Solve(Data), Is.EqualTo(72070));
    }
}
