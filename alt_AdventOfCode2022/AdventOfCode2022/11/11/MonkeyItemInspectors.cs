using Microsoft.VisualStudio.TestPlatform.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022._11._11;


public class Monkey
{
    public Monkey(string rawMonkey)
    {
        var monkeyRows = rawMonkey.Split(Environment.NewLine);
        Items = monkeyRows[1].Split(": ")[1].Split(", ").Select(d => long.Parse(d)).ToList();
        Operation = monkeyRows[2].Split("new = ")[1];
        Divisible = int.Parse(monkeyRows[3].Split("divisible by ")[1]);
        TrueMonkey = int.Parse(monkeyRows[4].Split(" ").Last());
        FalseMonkey = int.Parse(monkeyRows[5].Split(" ").Last());
        InspectedItemCount = 0;
    }

    public List<long> Items { get; set; }
    public string Operation { get; set; }
    public int Divisible { get; set; }
    public int TrueMonkey { get; set; }
    public int FalseMonkey { get; set; }
    public int InspectedItemCount { get; set; }
    public long RunOperation(long value, int factor)
    {
        InspectedItemCount++;

        var vals = Operation.Split(" ");
        long val = vals[0] == "old" ? value : int.Parse(vals[0]);
        long val2 = vals[2] == "old" ? value : int.Parse(vals[2]);
        return (vals[1] == "+" ? (val + val2) : (val * val2)) % factor;
    }

}

public class MonkeyItemInspectors
{
    public long Solve(string input, int nrOfRounds, long worryDivider = 1)
    {
        var monkeys = input.Split($"{Environment.NewLine}{Environment.NewLine}")
            .Select(rm => new Monkey(rm))
            .ToList();

        var factor = monkeys.Aggregate(1, (a, b) => a * b.Divisible);

        for(var rounds = 0; rounds < nrOfRounds; rounds++)
        {
            monkeys.ForEach(m =>
            {
                foreach(var item in new List<long>(m.Items))
                {
                    var worryLevel = m.RunOperation(item, factor);
                    if (worryDivider > 1)
                        worryLevel = worryLevel / worryDivider;

                    var passTo = worryLevel % m.Divisible == 0 ? m.TrueMonkey : m.FalseMonkey;
                    m.Items.Remove(item);
                    monkeys[passTo].Items.Add(worryLevel);
                }
            });
        }
      
        var result = monkeys.OrderByDescending(m => m.InspectedItemCount);
        return Math.BigMul(result.First().InspectedItemCount, result.ElementAt(1).InspectedItemCount);
    }
}
