using SixBySixSkyscrapers.Interfaces;
using SixBySixSkyscrapers.Models;

namespace SixBySixSkyscrapers;

public class CityPlanner
{
    private static readonly List<IFact> _facts;
    private const int CitySize = 6;

    static CityPlanner()
    {
        _facts = new List<IFact>();
        // TODO: fill in the facts
    }

    public int[][] Plan(int[] clueValues)
    {
        // TODO: Maybe extract to City class as factory method
        City city = CreateCity(clueValues);
        
        // TODO: Implement
    }

    private City CreateCity(int[] clueValues)
    {
        List<Clue> clues = Clue.FromValues(clueValues);
        Dictionary<int, List<Building>> buildingsGrid = Building.Grid(CitySize);

        List<Street> horizontalStreets = GenerateHorizontalStreets(clues, buildingsGrid);
        List<Street> verticalStreets = GenerateVerticalStreets(clues, buildingsGrid);

        return new City(horizontalStreets, verticalStreets);
    }

    private List<Street> GenerateHorizontalStreets(List<Clue> clues, Dictionary<int, List<Building>> buildingsGrid)
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
    
    private List<Street> GenerateVerticalStreets(List<Clue> clues, Dictionary<int,List<Building>> buildingsGrid)
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