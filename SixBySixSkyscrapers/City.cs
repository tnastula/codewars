using SixBySixSkyscrapers.Facts;
using SixBySixSkyscrapers.Facts.Initial;
using SixBySixSkyscrapers.Interfaces;

namespace SixBySixSkyscrapers;

public class City
{
    private Dictionary<int, Dictionary<int, Building>> Buildings { get; set; }
    private List<Street> HorizontalStreets;
    private List<Street> VerticalStreets;

    public int[][] Map
    {
        get
        {
            int[][] result = new int[Building.MaxHeight][];
            for (var rowIndex = 0; rowIndex < HorizontalStreets.Count; rowIndex++)
            {
                Street street = HorizontalStreets[rowIndex];
                result[rowIndex] = new int[Building.MaxHeight];

                for (var columnIndex = 0; columnIndex < street.Buildings.Count; columnIndex++)
                {
                    Building building = street.Buildings[columnIndex];
                    result[rowIndex][columnIndex] = building.Height ?? -1;
                }
            }

            return result;
        }
    }

    private int StreetsToSolve
    {
        get
        {
            int streetsToSolve = HorizontalStreets.Count(x => x.AvailableHeights.Count > 0);
            streetsToSolve += VerticalStreets.Count(x => x.AvailableHeights.Count > 0);
            return streetsToSolve;
        }
    }
    
    private List<IFact> InitialFacts { get; set; }
    private List<IFact> Facts { get; set; }

    public City(int[] clues)
    {
        HorizontalStreets = new(Building.MaxHeight);
        VerticalStreets = new(Building.MaxHeight);

        for (int i = 0; i < Building.MaxHeight; i++)
        {
            int topClueIndex = i;
            int bottomClueIndex = 3 * Building.MaxHeight - 1 - i;

            VerticalStreets.Add(
                new(Orientation.Vertical,
                clues[topClueIndex],
                clues[bottomClueIndex])
                );

            int leftClueIndex = 4 * Building.MaxHeight - 1 - i;
            int rightClueIndex = Building.MaxHeight - 1 + i;

            HorizontalStreets.Add(
                new(Orientation.Horizontal,
                clues[leftClueIndex],
                clues[rightClueIndex])
                );
        }

        Buildings = new(Building.MaxHeight);
        for (int rowIndex = 0; rowIndex < Building.MaxHeight; rowIndex++)
        {
            Buildings[rowIndex] = new(6);
            for (int columnIndex = 0; columnIndex < Building.MaxHeight; columnIndex++)
            {
                Buildings[rowIndex][columnIndex] = new(HorizontalStreets[rowIndex], VerticalStreets[columnIndex]);
            }
        }

        InitialFacts = new(4)
        {
            new GuaranteedNotTallestFact(),
            new OrderedStreetFact(),
            new TallestAtTheEdgeFact(),
            new TallestInBetweenFact()
        };

        Facts = new(2)
        {
            new NoOtherPossibilityBuildingFact(),
            new NoOtherPossibilityStreetFact()
        };
    }

    public void Build()
    {
        bool factTriggered = false;
        
        foreach (IFact initialFact in InitialFacts)
        {
            foreach (Street street in HorizontalStreets)
            {
                factTriggered = factTriggered || initialFact.Check(street);
            }
            
            foreach (Street street in VerticalStreets)
            {
                factTriggered = factTriggered || initialFact.Check(street);
            }
        }

        if (!factTriggered)
        {
            throw new Exception("No initial fact has been triggered!");
        }

        while (StreetsToSolve > 0)
        {
            factTriggered = false;
            
            foreach (IFact fact in Facts)
            {
                foreach (Street street in HorizontalStreets)
                {
                    factTriggered = factTriggered || fact.Check(street);
                }
            
                foreach (Street street in VerticalStreets)
                {
                    factTriggered = factTriggered || fact.Check(street);
                }
            }
            
            if (!factTriggered)
            {
                throw new Exception("Detected a pass without triggering any fact!");
            }
        }
    }
}