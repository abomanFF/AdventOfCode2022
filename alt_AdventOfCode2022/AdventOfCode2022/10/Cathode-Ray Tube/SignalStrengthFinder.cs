using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022._10.Cathode_Ray_Tube;

internal class SignalStrengthFinder
{
    private Dictionary<string, int> CycleDictionary;
    private int[] ObservedCycles;

    private const string ADDX_COMMAND = "addx";
    private const string NOOP_COMMAND = "noop";

    internal SignalStrengthFinder()
    {
        CycleDictionary= new Dictionary<string, int> { 
            {NOOP_COMMAND, 1 },
            {ADDX_COMMAND, 2 }
        };
        ObservedCycles = new int[6] {20,60,100,140,180,220};
    }

    internal (int, List<string>) Solve(string input)
    {
        int cycles = 0;
        int spritePos = 1;
        var signalStrengths = new List<int>();
        var rows = new List<string>(6){""};

        input.Split(Environment.NewLine)
            .Where(l => l != string.Empty)
            .Select(l => l.Split(" "))
            .ToList()
            .ForEach(c =>
            {
                var command = c[0];
                var commandCycles = CycleDictionary[command];

                for (var i = 0; i < commandCycles; i += 1)
                {
                    var printChar = new int[3] { spritePos - 1, spritePos, spritePos + 1 }.Contains(cycles%40) ? "#" : ".";
                    rows[^1] = rows[^1] + printChar;

                    cycles++;
                    if (cycles % 40 == 0 && rows.Count() < 6)
                        rows.Add("");
                    if (ObservedCycles.Contains(cycles))
                        signalStrengths.Add(spritePos * cycles);                 
                }

                if (command == ADDX_COMMAND)
                    spritePos = spritePos + int.Parse(c[1]);
            });

        return (signalStrengths.Sum(), rows);
    }
}
