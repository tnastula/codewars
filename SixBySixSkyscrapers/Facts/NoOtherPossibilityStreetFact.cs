using SixBySixSkyscrapers.Interfaces;

namespace SixBySixSkyscrapers.Facts;

public class NoOtherPossibilityStreetFact : IFact
{
    public bool Check(Street street)
    {
        if (street.AvailableHeights.Count == 0)
            return false;

        bool occured = false;

        List<int> availableHeights = street.AvailableHeights.ToList(); // copy because might be mutated
        foreach (int availableHeight in availableHeights)
        {
            List<Building> buildingsAcceptingHeight = new(Building.MaxHeight);

            foreach (Building building in street.Buildings)
            {
                if (building.Height != null)
                    continue;
                
                if (building.PossibleHeights.Contains(availableHeight))
                    buildingsAcceptingHeight.Add(building);
            }

            if (buildingsAcceptingHeight.Count == 1)
            {
                buildingsAcceptingHeight.First().SetHeight(availableHeight);
                occured = true;
            }
        }

        return occured;
    }
}