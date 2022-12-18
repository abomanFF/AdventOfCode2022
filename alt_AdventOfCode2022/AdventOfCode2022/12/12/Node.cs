namespace AdventOfCode2022._12._12;

internal class Node
{
    private const string Abc = "abcdefghijklmnopqrstuvwxyz";
    internal string Letter { get; private set; }
    internal int Altitude { get; private set; }
    internal List<Node> AccessibleNodes { get; set; }

    public Node(string letter)
    {
        Letter = letter;
        Altitude = GetAltitude(letter);
        AccessibleNodes = new List<Node>();
    }

    private int GetAltitude(string letter)
    {
        if (letter == "S") letter = "a";
        if (letter == "E") letter = "z";
        return Abc.IndexOf(letter);
    }

    public bool CanAccess(Node? neighbour)
    {
        if (neighbour == null)
            return false;

        return Altitude >= neighbour.Altitude || neighbour.Altitude - Altitude == 1;
    }
}
