namespace SixBySixSkyscrapers.Models;

public sealed class Street
{
    private readonly List<Building> _buildings;
    private readonly List<Clue> _clues;

    public Street(List<Building> buildings, List<Clue> clues)
    {
        _buildings = buildings;
        _clues = clues;
    }
}