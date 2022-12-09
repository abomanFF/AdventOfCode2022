using AdventOfCode2022.Base;
using Newtonsoft.Json.Linq;

namespace AdventOfCode2022._08;

public class Day8 : BaseTest
{
    public int Solve(string input)
    {

        var grid = input.Split(Environment.NewLine)
            .Select(l => l.ToArray()
                .Select(c => int.Parse(c.ToString())).ToList())
            .ToList();

        //All outside trees are visible
        var visibleTrees = (grid.Count() * 2) + (grid.First().Count() * 2) - 4;

        //For each row in grid
        for (int i = 1; i < grid.Count()-1; i++)
        {
            var currentRow = grid[i].ToList();
            //For each column
            for(int j = 1; j < currentRow.Count()-1; j++)
            {
                var leftSmaller = currentRow.GetRange(0, j).FirstOrDefault(c => c >= currentRow[j], -1) == -1;
                if (leftSmaller)
                {
                    visibleTrees++;
                    continue;
                }

                var rightSmaller = currentRow.GetRange(j+1, currentRow.Count()-1-j).FirstOrDefault(c => c >= currentRow[j], -1) == -1;
                if (rightSmaller)
                {
                    visibleTrees++;
                    continue;
                }

                var topSmaller = grid.GetRange(0, i).FirstOrDefault(topRow => topRow[j] >= currentRow[j], null) == null;
                if (topSmaller)
                {
                    visibleTrees++;
                    continue;
                }

                var bottomSmaller = grid.GetRange(i+1, grid.Count()-1-i).FirstOrDefault(bottomRow =>  bottomRow[j] >= currentRow[j], null) == null;
                if (bottomSmaller)
                {
                    visibleTrees++;
                    continue;
                }
            }
        }

        return visibleTrees;
    }

    public int Solve2(string input)
    {

        var grid = input.Split(Environment.NewLine)
            .Select(l => l.ToArray()
                .Select(c => int.Parse(c.ToString())).ToList())
            .ToList();

        //Highest scenic score
        var savedScore = 0;

        //For each row in grid
        for (int i = 1; i < grid.Count() - 1; i++)
        {
            var currentRow = grid[i].ToList();
            //For each column
            for (int j = 1; j < currentRow.Count() - 1; j++)
            {
                var leftVal = 0;
                var leftCells = currentRow.GetRange(0, j);
                leftCells.Reverse();
                foreach (var leftCell in leftCells)
                {
                    leftVal++;
                    if (leftCell >= currentRow[j])
                        break;
                }

                var rightVal = 0;
                foreach(var rightCell in currentRow.GetRange(j + 1, currentRow.Count() - 1 - j))
                {
                    rightVal++;
                    if (rightCell >= currentRow[j])
                        break;
                }

                var topVal = 0;
                var topCells = grid.GetRange(0, i);
                topCells.Reverse();
                foreach (var topRow in topCells)
                {
                    topVal++;
                    if (topRow[j] >= currentRow[j])
                        break;
                }

                var bottomVal = 0;
                foreach (var bottomRow in grid.GetRange(i + 1, grid.Count() - 1 - i))
                {
                    bottomVal++;
                    if (bottomRow[j] >= currentRow[j])
                        break;
                }

                var scenicScore = leftVal * rightVal * topVal * bottomVal;
                savedScore = scenicScore > savedScore ? scenicScore : savedScore;
            }
        }

        return savedScore;
    }

    [Test]
    public void SolveTestData()
    {
        Assert.That(Solve(TestData), Is.EqualTo(21));
    }

    [Test]
    public void SolveDataPart1()
    {
        Assert.That(Solve(Data), Is.EqualTo(1693));
    }

    [Test]
    public void SolveTestDataPart2()
    {
        Assert.That(Solve2(TestData), Is.EqualTo(8));
    }

    [Test]
    public void SolveDataPart2()
    {
        Assert.That(Solve2(Data), Is.EqualTo(1693));
    }
}
