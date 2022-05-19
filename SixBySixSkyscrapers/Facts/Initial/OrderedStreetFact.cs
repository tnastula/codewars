using SixBySixSkyscrapers.Interfaces;

namespace SixBySixSkyscrapers.Facts.Initial;

public class OrderedStreetFact : IFact
{
    public bool Check(Street street)
    {
        int height;
        int step;
        
        if (street.TopOrLeftClue == Building.MaxHeight)
        {
            height = Building.MinHeight;
            step = 1;
        }
        else if (street.BottomOrRightClue == Building.MaxHeight)
        {
            height = Building.MaxHeight;
            step = -1;
        }
        else
        {
            return false;
        }

        foreach (Building building in street.Buildings)
        {
            building.SetHeight(height);
            height += step;
        }

        return true;
    }
}