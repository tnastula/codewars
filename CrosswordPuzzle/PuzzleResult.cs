namespace CrosswordPuzzle;

public class PuzzleResult
{
    public readonly string AcrossWord;
    public readonly string DownWord;
    public readonly int Points;

    public PuzzleResult(string acrossWord, string downWord, int points)
    {
        AcrossWord = acrossWord;
        DownWord = downWord;
        Points = points;
    }
}