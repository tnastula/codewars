namespace SixBySixSkyscrapers.Models;

public sealed class City
{
    private const int CitySize = 6;
    private readonly List<Street> _horizontalStreets;
    private readonly List<Street> _verticalStreets;

    private City(List<Street> horizontalStreets, List<Street> verticalStreets)
    {
        _horizontalStreets = horizontalStreets;
        _verticalStreets = verticalStreets;
    }

    public static City FromClueValues(int[] clueValues)
    {
        List<Clue> clues = Clue.FromValues(clueValues);
        Dictionary<int, List<Building>> buildingsGrid = Building.Grid(CitySize);

        List<Street> horizontalStreets = GenerateHorizontalStreets(clues, buildingsGrid);
        List<Street> verticalStreets = GenerateVerticalStreets(clues, buildingsGrid);

        return new City(horizontalStreets, verticalStreets);
    }
    
    private static List<Street> GenerateHorizontalStreets(List<Clue> clues, Dictionary<int, List<Building>> buildingsGrid)
    {
        List<Street> horizontalStreets = new List<Street>(CitySize);
        for (int streetIndex = 0; streetIndex < CitySize; streetIndex++)
        {
            List<Building> streetBuildings = buildingsGrid[streetIndex].ToList();
            List<Clue> streetClues = new List<Clue>(2)
            {
                clues[CitySize * 4 - 1 - streetIndex],
                clues[CitySize + streetIndex]
            };
            
            horizontalStreets.Add(new Street(streetBuildings, streetClues));
        }

        return horizontalStreets;
    }
    
    private static List<Street> GenerateVerticalStreets(List<Clue> clues, Dictionary<int,List<Building>> buildingsGrid)
    {
        List<Street> verticalStreets = new List<Street>(CitySize);
        for (int streetIndex = 0; streetIndex < CitySize; streetIndex++)
        {
            List<Building> streetBuildings = new List<Building>(CitySize);
            foreach (List<Building> horizontalStreetBuildings in buildingsGrid.Values)
            {
                streetBuildings.Add(horizontalStreetBuildings[streetIndex]);
            }
            
            List<Clue> streetClues = new List<Clue>(2)
            {
                clues[streetIndex],
                clues[CitySize * 3 - 1 - streetIndex]
            };
            
            verticalStreets.Add(new Street(streetBuildings, streetClues));
        }

        return verticalStreets;
    }
}