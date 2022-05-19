using SixBySixSkyscrapers.Interfaces;

namespace SixBySixSkyscrapers.Facts.Initial;

public class TallestAtTheEdgeFact : IFact
{
    public bool Check(Street street)
    {
        if (street.TopOrLeftClue == 1)
        {
            street.Buildings[0].SetHeight(Building.MaxHeight);
            return true;
        }

        if (street.BottomOrRightClue == 1)
        {
            int index = Building.MaxHeight - 1;
            street.Buildings[index].SetHeight(Building.MaxHeight);
            return true;
        }

        return false;
    }
}