namespace AdventOfCode2022._12._12;

internal class HillClimbingAlgorithm
{
    internal int Solve(string input, string startLetter = "S")
    {
        var rows = input.Split(Environment.NewLine);
        Node[,] nodes = new Node[rows[0].Length, rows.Length];
        List<Node> startNodes = new List<Node>();
        Node endNode = null;

        for (int y = 0; y < rows.Length; y += 1)
        {
            var row = rows[y];
            for (int x = 0; x < row.Length; x += 1)
            {
                var node = new Node(row[x].ToString());
                var topNode = y - 1 >= 0 ? nodes[x, y-1] : null;
                var leftNode = x - 1 >= 0 ? nodes[x-1, y] : null;

                if (topNode != null && node.CanAccess(topNode)) node.AccessibleNodes.Add(topNode);
                if (leftNode != null && node.CanAccess(leftNode)) node.AccessibleNodes.Add(leftNode);
                if (leftNode != null && leftNode.CanAccess(node)) leftNode.AccessibleNodes.Add(node);
                if (topNode != null && topNode.CanAccess(node)) topNode.AccessibleNodes.Add(node);

                if (node.Letter == startLetter) startNodes.Add(node);
                if (node.Letter == "E") endNode = node;
                nodes[x,y] = node;
            }
        }

        return new BreadthFirstStepSearch().Start(startNodes, endNode);
    }
}
