namespace ScreenLockingPatterns;

public class Route
{
    private static HashSet<int> AvailableNodes { get; set; }
    private static List<List<int>> SpecialRoutes { get; set; }
    private int CurrentNode { get; set; }
    private HashSet<int> VisitedNodes { get; set; }

    static Route()
    {
        AvailableNodes = new(9);
        for (int i = 0; i < 9; i++)
        {
            AvailableNodes.Add(i);
        }

        SpecialRoutes = new(8)
        {
            new() { 0, 2 },
            new() { 2, 8 },
            new() { 6, 8 },
            new() { 0, 6 },
            new() { 1, 7 },
            new() { 3, 5 },
            new() { 0, 8 },
            new() { 2, 6 }
        };
    }

    public Route(int currentNode, HashSet<int>? visitedNodes = null)
    {
        CurrentNode = currentNode;
        VisitedNodes = visitedNodes ?? new HashSet<int>();
        VisitedNodes.Add(currentNode);
    }

    public List<Route> GetOneStepLongerRoutes()
    {
        List<Route> routes = new(8);

        foreach (int availableNode in AvailableNodes)
        {
            if (!IsMoveLegal(availableNode))
            {
                continue;
            }

            Route route = new(availableNode, VisitedNodes.ToHashSet());
            routes.Add(route);
        }

        return routes;
    }

    private bool IsMoveLegal(int nextNode)
    {
        if (VisitedNodes.Contains(nextNode))
        {
            return false;
        }

        bool isSpecialRoute = SpecialRoutes.Any(x => x.Contains(CurrentNode) && x.Contains(nextNode));
        if (isSpecialRoute)
        {
            int dependantNode = (CurrentNode + nextNode) / 2;
            if (!VisitedNodes.Contains(dependantNode))
            {
                return false;
            }
        }

        return true;
    }
}