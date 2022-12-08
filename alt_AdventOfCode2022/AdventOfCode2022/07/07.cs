using AdventOfCode2022.Base;

namespace AdventOfCode2022._07;

public class Day7 : BaseTest
{
    private Dictionary<string, int> GetDirectoriesWithSizes(string input)
    {
        var commandList = input.Split($"{Environment.NewLine}$")
            .Select(l => l.Trim().Split(Environment.NewLine))
            .ToList();

        var directories = new Dictionary<string, int>();
        var activeDirectories = new List<string>();

        commandList.ForEach(c =>
        {
            var command = c[0];
            if (command.StartsWith("cd"))
            {
                var thisDirectory =  command.Split("cd ")[1];
                if (thisDirectory == "..")
                {
                    activeDirectories.RemoveAt(activeDirectories.Count - 1);
                    return;
                }
                if (thisDirectory != "/")
                    thisDirectory = $"{activeDirectories[activeDirectories.Count - 1]}{thisDirectory}/";

                if (!directories.ContainsKey(thisDirectory)) 
                    directories.Add(thisDirectory, 0);

                activeDirectories.Add(thisDirectory);
                return;
            }

            c[1..].ToList().ForEach(content =>
            {
                if (content.StartsWith("dir"))
                    return;

                var fileData = content.Split(" ");
                activeDirectories.ForEach(d => directories[d] = directories[d] + int.Parse(fileData[0]));
            });

        });

        return directories;
    }

    private int Solve1(string input)
    {
        return GetDirectoriesWithSizes(input)
            .Where(c => c.Value <= 100000)
            .Select(d => d.Value)
            .Sum();
    }

    private int Solve2(string input)
    {
        var dirs = GetDirectoriesWithSizes(Data);
        var usedData = 70000000 - dirs.First().Value;
        var neededData = 30000000 - usedData;

        return dirs.Where(d => d.Value >= neededData).OrderBy(d => d.Value).First().Value;
    }

    [Test]
    public void SolveTestData()
    {
        Assert.That(Solve1(TestData), Is.EqualTo(95437));
    }

    [Test]
    public void SolveDataPart1()
    {
        Assert.That(Solve1(Data), Is.EqualTo(1477771));
    }

    [Test]
    public void SolveDataPart2()
    {
        Assert.That(Solve2(Data), Is.EqualTo(3579501));
    }

}
