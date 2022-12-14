namespace AdventOfCode2022._09.Bridge;

internal class BridgeRunner
{
    internal int Solve(string input, int tails)
    {
        List<Coordinates> saved = new List<Coordinates>();
        List<Coordinates> knots = new List<Coordinates>(new Coordinates[1 + tails]).Select(n => new Coordinates()).ToList();

        input.Split(Environment.NewLine)
            .Where(l => l != string.Empty)
            .Select(l => l.Split(" "))
            .ToList()
            .ForEach(c =>
            {
                var direction = c[0];
                var moves = int.Parse(c[1]);

                for(var i = 0; i< moves; i++)
                {

                    var head = knots[0];
                    switch (direction)
                    {
                        case "R":
                            head.X = head.X + 1;
                            break;
                        case "L":
                            head.X = head.X - 1;
                            break;
                        case "U":
                            head.Y = head.Y + 1;
                            break;
                        case "D":
                            head.Y = head.Y - 1;
                            break;
                        default:
                            break;
                    }

                    for (var j = 1; j < knots.Count(); j++)
                    {
                        var tempHead = knots[j - 1];
                        var tail = knots[j];
                        if (!tempHead.IsAdjacentTo(tail))
                        {
                            var moveTailX = tempHead.X - tail.X  == 0 ? 0 : tempHead.X - tail.X > 0 ? 1 : -1;
                            var moveTailY = tempHead.Y - tail.Y  == 0 ? 0 : tempHead.Y - tail.Y > 0 ? 1 : -1;

                            tail.X = tail.X + moveTailX;
                            tail.Y = tail.Y + moveTailY;
                        }
                        if(j == knots.Count() - 1)
                        {
                            saved.Add(new Coordinates { X = tail.X, Y = tail.Y});
                        }
                    }
                }
            });

        return saved.DistinctBy(c => new { c.X, c.Y }).Count();
    }

}
