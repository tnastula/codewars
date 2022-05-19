namespace SixBySixSkyscrapers;

public class Street
{
    public readonly Orientation Orientation;
    public List<Building> Buildings { get; private set; }

    public int? TopOrLeftClue;
    public int? BottomOrRightClue;

    public HashSet<int> AvailableHeights { get; private set; }

    public HashSet<int> UnavailableHeights { get; private set; }

    public Street(Orientation orientation, int topOrLeftClue, int bottomOrRightClue)
    {
        Orientation = orientation;
        Buildings = new(Building.MaxHeight);
        TopOrLeftClue = topOrLeftClue == 0 ? null : topOrLeftClue;
        BottomOrRightClue = bottomOrRightClue == 0 ? null : bottomOrRightClue;
        AvailableHeights = Building.AllPossibleHeights.ToHashSet();
        UnavailableHeights = new HashSet<int>(Building.MaxHeight);
    }

    public void AddBuilding(Building building)
    {
        Buildings.Add(building);
    }

    public void BuildingHeightSetHandler(Building building)
    {
        AvailableHeights.Remove(building.Height.GetValueOrDefault());
        UnavailableHeights.Add(building.Height.GetValueOrDefault());
        
        foreach (Building otherBuilding in Buildings)
        {
            if (otherBuilding == building)
                continue;
            
            otherBuilding.RegisterImpossibleHeight(building.Height.GetValueOrDefault());
        }
    }
}