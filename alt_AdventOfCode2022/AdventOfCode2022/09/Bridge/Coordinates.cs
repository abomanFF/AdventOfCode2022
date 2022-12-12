namespace AdventOfCode2022._09.Bridge;

public class Coordinates
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsAdjacentTo(Coordinates other) => Math.Abs(other.X - X) <= 1 && Math.Abs(other.Y - Y) <= 1;
}
