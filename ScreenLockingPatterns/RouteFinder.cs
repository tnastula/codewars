namespace ScreenLockingPatterns;

public class RouteFinder
{
    // A B C
    // D E F
    // G H I

    // 0 1 2
    // 3 4 5
    // 6 7 8
    
    private int InitialNode { get; set; }
    private int Length { get; set; }

    public RouteFinder(int initialNode, int length)
    {
        InitialNode = initialNode;
        Length = length;
    }

    public List<Route> Find()
    {
        int estimatedCollectionSize = Helper.Factorial(Length);
        List<Route> routes = new(estimatedCollectionSize);

        if (Length == 0)
        {
            return routes;
        }

        routes.Add(new(InitialNode));

        for (int currentLength = 1; currentLength < Length; currentLength++)
        {
            List<Route> currentPassRoutes = new(routes.Count * 8);

            foreach (Route route in routes)
            {
                currentPassRoutes.AddRange(route.GetOneStepLongerRoutes());
            }

            routes = currentPassRoutes;
        }

        return routes;
    }
}