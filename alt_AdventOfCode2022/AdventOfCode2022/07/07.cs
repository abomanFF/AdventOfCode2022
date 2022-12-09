using AdventOfCode2022.Base;

namespace AdventOfCode2022._07;

public class Day7 : BaseTest
{
    private Dictionary<string, int> GetDirectoriesWithSizes(string input)
    {
        //Split the input data into command chunks
        var commandList = input.Split($"{Environment.NewLine}$")
            .Select(l => l.Trim().Split(Environment.NewLine))
            .ToList();

        //The available directories 
        var directories = new Dictionary<string, int>();

        //Directories currently in scope
        var activeDirectories = new List<string>();

        commandList.ForEach(c =>
        {
            //First line is always the command
            var command = c[0];

            //If directory
            if (command.StartsWith("cd"))
            {
                var thisDirectory =  command.Split("cd ")[1];
                //Move back 1 step in the active directories
                if (thisDirectory == "..")
                {
                    activeDirectories.RemoveAt(activeDirectories.Count - 1);
                    return;
                }
                //Add full path to name to avoid collision with other files with same name
                if (thisDirectory != "/")
                    thisDirectory = $"{activeDirectories[activeDirectories.Count - 1]}{thisDirectory}/";

                //Add directory to available directories if not already added
                if (!directories.ContainsKey(thisDirectory)) 
                    directories.Add(thisDirectory, 0);

                //Add directory to the active directories currently in scope
                activeDirectories.Add(thisDirectory);
                return;
            }

            //If not cd then it is a list(ls) command
            //Itterate the directories and files listed by the command
            c[1..].ToList().ForEach(content =>
            {
                //If directory, do nothing
                if (content.StartsWith("dir"))
                    return;

                //File data (1234 Filename.txt), split to access size
                //Add size to directory and all parent directories
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
