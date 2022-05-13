namespace MergedStringChecker;

public class StringPart
{
    private int _currentIndex;
    private readonly string _text;

    public StringPart(string text)
    {
        _text = text;
        _currentIndex = 0;
    }

    public char? Peek()
    {
        if (DepletedLetters())
        {
            return null;
        }

        return _text[_currentIndex];
    }
    
    public void MoveIndex()
    {
        if (!DepletedLetters())
        {
            _currentIndex++;
        }
    }

    public StringPart CreateFromRemaining()
    {
        return new StringPart(_text.Substring(_currentIndex));
    }

    public bool DepletedLetters()
    {
        return _currentIndex >= _text.Length;
    }
}