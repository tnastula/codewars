using SixBySixSkyscrapers.Interfaces;

namespace SixBySixSkyscrapers.Facts.Initial;

public class GuaranteedNotTallestFact : IFact
{
    public bool Check(Street street)
    {
        if (street.TopOrLeftClue != null)
        {
            for (int index = 0; index < street.TopOrLeftClue - 1; index++)
            {
                street
                    .Buildings[index]
                    .RegisterImpossibleHeight(Building.MaxHeight);
            }
        }

        if (street.BottomOrRightClue != null)
        {
            for (int index = 0; index < street.BottomOrRightClue - 1; index++)
            {
                street
                    .Buildings[Building.MaxHeight - 1 - index]
                    .RegisterImpossibleHeight(Building.MaxHeight);
            }
        }

        return false;
    }
}