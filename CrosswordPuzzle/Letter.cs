namespace CrosswordPuzzle;

public class Letter
{
    public readonly Coordinate Coordinate;
    public readonly char Symbol;
    public List<Letter> Previous { get; set; }
    public List<Letter> Next { get; set; }

    public Letter(Coordinate coordinate, char symbol)
    {
        Coordinate = coordinate;
        Symbol = symbol;
        Previous = new List<Letter>();
        Next = new List<Letter>();
    }
}