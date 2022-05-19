using SixBySixSkyscrapers.Interfaces;

namespace SixBySixSkyscrapers.Facts.Initial;

public class TallestInBetweenFact : IFact
{
    public bool Check(Street street)
    {
        if (street.TopOrLeftClue == null
            || street.BottomOrRightClue == null
            || street.TopOrLeftClue + street.BottomOrRightClue != Building.MaxHeight + 1)
        {
            return false;
        }

        street
            .Buildings[street.TopOrLeftClue.GetValueOrDefault() - 1]
            .SetHeight(Building.MaxHeight);

        return true;
    }
}