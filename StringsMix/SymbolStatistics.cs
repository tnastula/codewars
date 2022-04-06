using System.Text;

namespace StringsMix;

public class SymbolStatistics
{
    public static int EqualityPrefix { get; private set; } = Int32.MaxValue;
    public int Prefix { get; set; }
    private char Symbol { get; set; }
    public int Count { get; private set; }

    public SymbolStatistics(char symbol)
    {
        Prefix = EqualityPrefix;
        Symbol = symbol;
        Count = 0;
    }

    public void RegisterOccurence()
    {
        Count++;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();
        stringBuilder.Append(Prefix == EqualityPrefix ? "=" : Prefix.ToString());
        stringBuilder.Append(':');
        for (int i = 0; i < Count; i++)
        {
            stringBuilder.Append(Symbol);
        }

        return stringBuilder.ToString();
    }
}