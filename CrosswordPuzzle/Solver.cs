namespace CrosswordPuzzle;

public class Solver
{
    private static char _blockedSpaceSymbol = '#';
    private static char _blankSpaceSymbol = '_';
    private static Dictionary<char, List<string>> LetterToWordsList { get; set; }

    static Solver()
    {
        LetterToWordsList = new Dictionary<char, List<string>>(26);
        for (int asciiValue = 65; asciiValue < 91; asciiValue++)
        {
            LetterToWordsList.Add((char)asciiValue, new List<string>(10));
        }

        foreach (string word in Solution.Words)
        {
            LetterToWordsList[word[0]].Add(word);
        }
    }

    public Solver(string[] puzzle)
    {
        Solve(puzzle);
    }

    private void Solve(string[] puzzle)
    {
        Coordinate firstLetterCoordinate = GetCoordinateOfSymbol(puzzle,
            symbol => symbol != _blankSpaceSymbol && symbol != _blockedSpaceSymbol);
        Coordinate blockedSpaceCoordinate = GetCoordinateOfSymbol(puzzle, symbol => symbol == _blockedSpaceSymbol);
    }

    private Coordinate GetCoordinateOfSymbol(string[] puzzle, Func<char, bool> meetingCriteria)
    {
        for (int y = 0; y < puzzle.Length; y++)
        {
            for (int x = 0; x < puzzle[y].Length; x++)
            {
                if (meetingCriteria(puzzle[y][x]))
                {
                    return new Coordinate(x, y);
                }
            }
        }
    }
}