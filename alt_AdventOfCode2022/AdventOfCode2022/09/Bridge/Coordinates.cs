namespace AdventOfCode2022._09.Bridge;

internal class Coordinates
{
    internal int X { get; set; }
    internal int Y { get; set; }
    internal bool IsAdjacentTo(Coordinates other) => Math.Abs(other.X - X) <= 1 && Math.Abs(other.Y - Y) <= 1;
}
