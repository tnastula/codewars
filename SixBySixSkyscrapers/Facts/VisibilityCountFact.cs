using SixBySixSkyscrapers.Interfaces;

namespace SixBySixSkyscrapers.Facts;

public class VisibilityCountFact : IFact
{
    public bool Check(Street street)
    {
        if (street.AvailableHeights.Count == 0)
            return false;

        if (street.AvailableHeights.Contains(Building.MaxHeight))
            return false;

        if (street.TopOrLeftClue == null && street.BottomOrRightClue == null)
            return false;
        
        
    }

    private int? DetermineVisibility(Street street, int fromIndex, int withStep, int forHeight)
    {
        int tallestIndex = street.Buildings.FindIndex(x => x.Height == Building.MaxHeight);

        int tallestSoFar = 0;
        int visibility = 0;
        for (int index = fromIndex; index != tallestIndex; index += withStep)
        {
            Building current = street.Buildings[index];
            if (current.Height > tallestSoFar)
            {
                visibility++;
                tallestSoFar = current.Height.GetValueOrDefault();
            }
        }
    }
}