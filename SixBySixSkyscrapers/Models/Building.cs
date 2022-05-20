namespace SixBySixSkyscrapers.Models;

public sealed class Building
{
    public Height Height { get; set; }
    
    public Building()
    {
        Height = Height.Null;
    }

    public static Dictionary<int, List<Building>> Grid(int ofSize)
    {
        Dictionary<int, List<Building>> grid = new Dictionary<int, List<Building>>(ofSize);

        for (int rowIndex = 0; rowIndex < ofSize; rowIndex++)
        {
            grid[rowIndex] = new List<Building>(ofSize);
            
            for (int columnIndex = 0; columnIndex < ofSize; columnIndex++)
            {
                grid[rowIndex][columnIndex] = new Building();
            }
        }

        return grid;
    }
}