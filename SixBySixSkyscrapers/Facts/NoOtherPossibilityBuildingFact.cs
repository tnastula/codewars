using SixBySixSkyscrapers.Interfaces;

namespace SixBySixSkyscrapers.Facts;

public class NoOtherPossibilityBuildingFact : IFact
{
    public bool Check(Street street)
    {
        if (street.AvailableHeights.Count == 0)
            return false;
        
        bool occured = false;
        
        foreach (Building building in street.Buildings)
        {
            if (building.Height == null && building.PossibleHeights.Count == 1)
            {
                building.SetHeight(building.PossibleHeights.First());
                occured = true;
            }
        }

        return occured;
    }
}