namespace AdventOfCode2022._11._11;

internal class MonkeyItemInspectors
{
    internal long Solve(string input, int nrOfRounds, long worryDivider = 1)
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
