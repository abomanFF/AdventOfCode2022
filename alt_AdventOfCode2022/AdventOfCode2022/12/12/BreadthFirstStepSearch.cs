namespace AdventOfCode2022._12._12;

internal class BreadthFirstStepSearch
{

    internal int Start(List<Node> startNodes, Node? endNode)
    {
        var pathLength = 0;
        foreach (var startNode in startNodes)
        {
            var nodeRoute = RouteNodes(startNode);
            (var validRoute, var thisPathLength) = GetShortestRouteFrom(startNode, endNode, nodeRoute);
            if (!validRoute) continue;

            if (pathLength == 0 || thisPathLength < pathLength)
                pathLength = thisPathLength;
        }

        return pathLength;

    }

    private (bool, int) GetShortestRouteFrom(Node? startNode, Node? endNode, Dictionary<Node, Node> nodeRoute)
    {
        if (!nodeRoute.ContainsKey(endNode))
            return (false, -1);

        var nodePath = new HashSet<Node>();
        var activeNode = endNode;
        while (activeNode != startNode)
        {
            nodePath.Add(activeNode);
            activeNode = nodeRoute[activeNode];
        }

        return (true, nodePath.Count());
    }

    private Dictionary<Node, Node> RouteNodes(Node startNode)
    {
        var queue = new Queue<Node>();
        var previous = new Dictionary<Node, Node?>();

        queue.Enqueue(startNode);
        previous[startNode] = null;
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            foreach (var an in node.AccessibleNodes)
            {
                if (previous.ContainsKey(an))
                    continue;

                previous[an] = node;
                queue.Enqueue(an);
            }
        }
        return previous;
    }

}