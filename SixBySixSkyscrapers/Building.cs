namespace SixBySixSkyscrapers;

public class Building
{
    public const int MaxHeight = 6;
    public const int MinHeight = 1;
    public static readonly HashSet<int> AllPossibleHeights;

    public int? Height { get; private set; }
    public HashSet<int> ImpossibleHeights { get; private set; }
    public HashSet<int> PossibleHeights { get; private set; }

    public readonly Street HorizontalStreet;
    public readonly Street VerticalStreet;

    static Building()
    {
        AllPossibleHeights = new HashSet<int>(MaxHeight - MinHeight + 1);
        for (int height = MinHeight; height <= MaxHeight; height++)
        {
            AllPossibleHeights.Add(height);
        }
    }

    public Building(Street horizontalStreet, Street verticalStreet)
    {
        HorizontalStreet = horizontalStreet;
        HorizontalStreet.AddBuilding(this);
        
        VerticalStreet = verticalStreet;
        VerticalStreet.AddBuilding(this);
        
        Height = null;
        ImpossibleHeights = new(6);
        PossibleHeights = AllPossibleHeights.ToHashSet();
    }

    public void SetHeight(int height)
    {
        Height = height;
        ImpossibleHeights = AllPossibleHeights.ToHashSet();
        ImpossibleHeights.Remove(height);
        PossibleHeights.RemoveWhere(x => x != height);
        
        HorizontalStreet.BuildingHeightSetHandler(this);
        VerticalStreet.BuildingHeightSetHandler(this);
    }

    public void RegisterImpossibleHeight(int height)
    {
        ImpossibleHeights.Add(height);
        PossibleHeights.Remove(height);
    }
}