namespace StringsMix;

public class TextStatistics
{
    public static char LowestCountedSymbol { get; private set; }
    public static char HighestCountedSymbol { get; private set; }
    private string Text { get; set; }
    public Dictionary<char, SymbolStatistics> Statistics { get; private set; }

    static TextStatistics()
    {
        LowestCountedSymbol = 'a';
        HighestCountedSymbol = 'z';
    }

    public TextStatistics(string text)
    {
        Statistics = new(0);
        Text = text;
        PerformAnalysis();
    }

    private void PerformAnalysis()
    {
        int estimatedCollectionSize = TextStatistics.HighestCountedSymbol - TextStatistics.LowestCountedSymbol + 1;
        Statistics = new Dictionary<char, SymbolStatistics>(estimatedCollectionSize);
        for (int i = LowestCountedSymbol; i <= HighestCountedSymbol; i++)
        {
            Statistics[(char)i] = new SymbolStatistics((char)i);
        }

        foreach (char symbol in Text)
        {
            if (symbol < LowestCountedSymbol || symbol > HighestCountedSymbol)
            {
                continue;
            }

            Statistics[symbol].RegisterOccurence();
        }
    }
}