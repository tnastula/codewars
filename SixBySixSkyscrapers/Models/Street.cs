namespace SixBySixSkyscrapers.Models;

public sealed class Street
{
    private readonly List<Building> _cells;
    private readonly List<Clue> _clues;

    public Street(List<Building> cells, List<Clue> clues)
    {
        _cells = cells;
        _clues = clues;
    }
}