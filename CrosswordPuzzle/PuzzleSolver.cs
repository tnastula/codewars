namespace CrosswordPuzzle;

public class PuzzleSolver
{
    private const char BlockedSpaceSymbol = '#';
    private const char BlankSpaceSymbol = '_';
    private static readonly Dictionary<char, List<char>> LetterToFollowingLetters;
    private static readonly Dictionary<char, List<char>> LetterToLeadingLetters;

    private Coordinate InitialLetterCoordinate { get; set; }
    private char InitialLetter { get; set; }
    private List<Coordinate> BlankSpaceCoordinates { get; set; }
    private Coordinate FirstLetterCoordinate { get; set; }
    private Coordinate SecondLetterCoordinate { get; set; }
    public List<object[]> Result;

    static PuzzleSolver()
    {
        LetterToFollowingLetters = new Dictionary<char, List<char>>(26);
        LetterToLeadingLetters = new Dictionary<char, List<char>>(26);

        for (int asciiValue = 65; asciiValue < 91; asciiValue++)
        {
            LetterToFollowingLetters.Add((char)asciiValue, new List<char>(10));
            LetterToLeadingLetters.Add((char)asciiValue, new List<char>(10));
        }

        foreach (string word in Solution.Words)
        {
            LetterToFollowingLetters[word[0]].Add(word[1]);
            LetterToLeadingLetters[word[1]].Add(word[0]);
        }
    }

    public PuzzleSolver(string[] puzzle)
    {
        ParseInput(puzzle);

        PositionType positionType = InitialLetterCoordinate.PositionInRelationTo(FirstLetterCoordinate);
        List<string> firstWords = GenerateWords(InitialLetter, positionType);
        Dictionary<string, List<string>> firstWordToSecondWords = new(firstWords.Count);

        positionType = InitialLetterCoordinate.PositionInRelationTo(SecondLetterCoordinate);
        if (positionType != PositionType.Across)
        {
            List<string> secondWords = GenerateWords(InitialLetter, positionType);
            foreach (string firstWord in firstWords)
            {
                firstWordToSecondWords[firstWord] = secondWords;
            }
        }
        else
        {
            positionType = FirstLetterCoordinate.PositionInRelationTo(SecondLetterCoordinate);
            foreach (string firstWord in firstWords)
            {
                char startingLetterForSecondWords = firstWord[0];
                if (startingLetterForSecondWords == InitialLetter)
                {
                    startingLetterForSecondWords = firstWord[1];
                }

                firstWordToSecondWords[firstWord] = GenerateWords(startingLetterForSecondWords, positionType);
            }
        }

        GenerateResult(firstWords, firstWordToSecondWords, positionType);
    }

    private void ParseInput(string[] puzzle)
    {
        InitialLetterCoordinate = GetCoordinatesOfSymbol(
                puzzle,
                symbol => symbol != BlankSpaceSymbol && symbol != BlockedSpaceSymbol)
            .First();
        InitialLetter = puzzle[InitialLetterCoordinate.Y][InitialLetterCoordinate.X];
        BlankSpaceCoordinates = GetCoordinatesOfSymbol(
            puzzle,
            symbol => symbol == BlankSpaceSymbol);

        FirstLetterCoordinate = BlankSpaceCoordinates[0];
        SecondLetterCoordinate = BlankSpaceCoordinates[1];
        PositionType positionType = InitialLetterCoordinate.PositionInRelationTo(FirstLetterCoordinate);
        if (positionType == PositionType.Across)
        {
            FirstLetterCoordinate = BlankSpaceCoordinates[1];
            SecondLetterCoordinate = BlankSpaceCoordinates[0];
        }
    }

    private List<Coordinate> GetCoordinatesOfSymbol(string[] puzzle, Func<char, bool> criteriaEvaluator)
    {
        List<Coordinate> coordinates = new(4);

        for (int y = 0; y < puzzle.Length; y++)
        {
            for (int x = 0; x < puzzle[y].Length; x++)
            {
                if (criteriaEvaluator(puzzle[y][x]))
                {
                    coordinates.Add(new(x, y));
                }
            }
        }

        return coordinates;
    }

    private List<string> GenerateWords(char withLetter, PositionType positionedRelatedToMissingLetter)
    {
        List<string> words = new(10);

        if (positionedRelatedToMissingLetter is PositionType.Left or PositionType.Above)
        {
            foreach (char followingLetter in LetterToFollowingLetters[withLetter])
            {
                words.Add($"{withLetter}{followingLetter}");
            }
        }

        if (positionedRelatedToMissingLetter is PositionType.Right or PositionType.Below)
        {
            foreach (char leadingLetter in LetterToLeadingLetters[withLetter])
            {
                words.Add($"{leadingLetter}{withLetter}");
            }
        }

        return words;
    }

    private void GenerateResult(List<string> firstWords, Dictionary<string, List<string>> firstWordToSecondWords,
        PositionType secondWordPositionType)
    {
        Result = new(firstWordToSecondWords.Sum(x => x.Value.Count));

        foreach (string firstWord in firstWords)
        {
            foreach (string secondWord in firstWordToSecondWords[firstWord])
            {
                if (firstWord.Equals(secondWord))
                {
                    continue;
                }

                string acrossWord = firstWord;
                string downWord = secondWord;
                if (secondWordPositionType is PositionType.Left or PositionType.Right)
                {
                    acrossWord = secondWord;
                    downWord = firstWord;
                }

                Result.Add(new object[]
                {
                    acrossWord,
                    downWord,
                    firstWord.Sum(x => Solution.Values[x]) + secondWord.Sum(x => Solution.Values[x])
                });
            }
        }

        Result = Result.OrderByDescending(x => x[2])
            .ThenBy(x => x[0])
            .ThenBy(x => x[1])
            .ToList();
    }
}