namespace SixBySixSkyscrapers.Models;

public sealed class City
{
    private readonly List<Street> _horizontalStreets;
    private readonly List<Street> _verticalStreets;

    public City(List<Street> horizontalStreets, List<Street> verticalStreets)
    {
        _horizontalStreets = horizontalStreets;
        _verticalStreets = verticalStreets;
    }
}