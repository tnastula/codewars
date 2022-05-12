namespace CrosswordPuzzle;

public class PuzzleSolver
{
    private static readonly char BlockedSpaceSymbol = '#';
    private static readonly char BlankSpaceSymbol = '_';
    private static readonly Dictionary<char, List<char>> LetterToFollowingLetters;
    private static readonly Dictionary<char, List<char>> LetterToLeadingLetters;

    private readonly string[] _puzzle;
    public List<PuzzleResult> Result; 
    
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
        _puzzle = puzzle;

        Coordinate initialLetterCoordinate =
            GetCoordinatesOfSymbol(symbol => symbol != BlankSpaceSymbol && symbol != BlockedSpaceSymbol)
                .First();
        char initialLetter = GetLetterAt(initialLetterCoordinate);

        List<Coordinate> blankSpaceCoordinates = GetCoordinatesOfSymbol(symbol => symbol == BlankSpaceSymbol);

        Coordinate firstLetterCoordinate = blankSpaceCoordinates[0];
        Coordinate secondLetterCoordinate = blankSpaceCoordinates[1];
        PositionType positionType = initialLetterCoordinate.PositionInRelationTo(firstLetterCoordinate);
        if (positionType == PositionType.Across)
        {
            firstLetterCoordinate = blankSpaceCoordinates[1];
            secondLetterCoordinate = blankSpaceCoordinates[0];
            positionType = initialLetterCoordinate.PositionInRelationTo(firstLetterCoordinate);
        }

        List<string> firstWords = GenerateWords(initialLetter, positionType);

        positionType = initialLetterCoordinate.PositionInRelationTo(secondLetterCoordinate);
        if (positionType != PositionType.Across)
        {
            List<string> secondWords = GenerateWords(initialLetter, positionType);

            Result = new List<PuzzleResult>(firstWords.Count * secondWords.Count);

            foreach (string firstWord in firstWords)
            {
                foreach (string secondWord in secondWords)
                {
                    if (firstWord.Equals(secondWord))
                    {
                        continue;
                    }

                    if (positionType == PositionType.Left || positionType == PositionType.Right)
                    {
                        Result.Add(new PuzzleResult(secondWord, firstWord, CalculatePoints(firstWord, secondWord)));
                    }
                    else
                    {
                        Result.Add(new PuzzleResult(firstWord, secondWord, CalculatePoints(firstWord, secondWord)));
                    }
                }
            }
        }
        else
        {
            Dictionary<string, List<string>>
                firstWordToSecondWords = new Dictionary<string, List<string>>(firstWords.Count);

            positionType = firstLetterCoordinate.PositionInRelationTo(secondLetterCoordinate);
            foreach (string firstWord in firstWords)
            {
                char startingLetterForSecondWords = firstWord[0];
                if (startingLetterForSecondWords == initialLetter)
                {
                    startingLetterForSecondWords = firstWord[1];
                }
                firstWordToSecondWords[firstWord] = GenerateWords(startingLetterForSecondWords, positionType);
            }
            
            Result = new List<PuzzleResult>(firstWordToSecondWords.Sum(x => x.Value.Count));

            foreach (string firstWord in firstWords)
            {
                foreach (string secondWord in firstWordToSecondWords[firstWord])
                {
                    if (firstWord.Equals(secondWord))
                    {
                        continue;
                    }

                    if (positionType == PositionType.Left || positionType == PositionType.Right)
                    {
                        Result.Add(new PuzzleResult(secondWord, firstWord, CalculatePoints(firstWord, secondWord)));
                    }
                    else
                    {
                        Result.Add(new PuzzleResult(firstWord, secondWord, CalculatePoints(firstWord, secondWord)));
                    }
                }
            }
        }
    }

    private char GetLetterAt(Coordinate coordinate)
    {
        return _puzzle[coordinate.Y][coordinate.X];
    }

    private List<Coordinate> GetCoordinatesOfSymbol(Func<char, bool> criteriaEvaluator)
    {
        List<Coordinate> coordinates = new List<Coordinate>(4);

        for (int y = 0; y < _puzzle.Length; y++)
        {
            for (int x = 0; x < _puzzle[y].Length; x++)
            {
                if (criteriaEvaluator(_puzzle[y][x]))
                {
                    coordinates.Add(new Coordinate(x, y));
                }
            }
        }

        return coordinates;
    }

    private List<string> GenerateWords(char withLetter, PositionType positionedRelatedToMissingLetter)
    {
        List<string> words = new List<string>(10);
        
        if (positionedRelatedToMissingLetter == PositionType.Left || positionedRelatedToMissingLetter == PositionType.Above)
        {
            foreach (char followingLetter in LetterToFollowingLetters[withLetter])
            {
                words.Add($"{withLetter}{followingLetter}");
            }
        }

        if (positionedRelatedToMissingLetter == PositionType.Right || positionedRelatedToMissingLetter == PositionType.Below)
        {
            foreach (char leadingLetter in LetterToLeadingLetters[withLetter])
            {
                words.Add($"{leadingLetter}{withLetter}");
            }
        }

        return words;
    }

    private int CalculatePoints(params string[] words)
    {
        int points = 0;
        
        foreach (string word in words)
        {
            foreach (char letter in word)
            {
                points += Solution.Values[letter];
            }
        }

        return points;
    }
}