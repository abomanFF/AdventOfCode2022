using AdventOfCode2022._10.Cathode_Ray_Tube;
using AdventOfCode2022.Base;

namespace AdventOfCode2022._10;

public class Day10 : BaseTest
{
    private List<string> _dataAnswer = new List<string>
        {
            "####.###....##.###..###..#..#..##..#..#.",
            "#....#..#....#.#..#.#..#.#.#..#..#.#..#.",
            "###..#..#....#.###..#..#.##...#..#.####.",
            "#....###.....#.#..#.###..#.#..####.#..#.",
            "#....#....#..#.#..#.#.#..#.#..#..#.#..#.",
            "####.#.....##..###..#..#.#..#.#..#.#..#."
        };

    private List<string> _testDataAnswer = new List<string>
        {
            "##..##..##..##..##..##..##..##..##..##..",
            "###...###...###...###...###...###...###.",
            "####....####....####....####....####....",
            "#####.....#####.....#####.....#####.....",
            "######......######......######......####",
            "#######.......#######.......#######....."
        };


    [Test]
    public void SolveTestData()
    {
        (int first, List<string> second) = new SignalStrengthFinder().Solve(TestData);

        second.ForEach(l => Console.WriteLine(l));

        Assert.That(first, Is.EqualTo(13140));
        Assert.That(second, Is.EqualTo(_testDataAnswer));
    }

    [Test]
    public void SolveData()
    {
        (int first, List<string> second) = new SignalStrengthFinder().Solve(Data);

        second.ForEach(l => Console.WriteLine(l));

        Assert.That(first, Is.EqualTo(11820));
        Assert.That(second, Is.EqualTo(_dataAnswer));
    }

}
