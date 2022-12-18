namespace AdventOfCode2022._11._11;

internal class Monkey
{
    internal Monkey(string rawMonkey)
    {
        var monkeyRows = rawMonkey.Split(Environment.NewLine);
        Items = monkeyRows[1].Split(": ")[1].Split(", ").Select(d => long.Parse(d)).ToList();
        Operation = monkeyRows[2].Split("new = ")[1];
        Divisible = int.Parse(monkeyRows[3].Split("divisible by ")[1]);
        TrueMonkey = int.Parse(monkeyRows[4].Split(" ").Last());
        FalseMonkey = int.Parse(monkeyRows[5].Split(" ").Last());
        InspectedItemCount = 0;
    }

    internal List<long> Items { get; set; }
    internal string Operation { get; set; }
    internal int Divisible { get; set; }
    internal int TrueMonkey { get; set; }
    internal int FalseMonkey { get; set; }
    internal int InspectedItemCount { get; set; }
    internal long RunOperation(long value, int factor)
    {
        InspectedItemCount++;

        var vals = Operation.Split(" ");
        long val = vals[0] == "old" ? value : int.Parse(vals[0]);
        long val2 = vals[2] == "old" ? value : int.Parse(vals[2]);
        return (vals[1] == "+" ? (val + val2) : (val * val2)) % factor;
    }

}
