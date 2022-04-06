namespace StringsMix;

public class TextComparer
{
    private List<TextStatistics> StatisticsList { get; set; }
    private List<SymbolStatistics> MaximumsList { get; set; }

    public TextComparer(string firstText, string secondText)
    {
        MaximumsList = new(0);
        StatisticsList = new(2)
        {
            new(firstText),
            new(secondText)
        };
        DetermineMaximums();
    }

    public override string ToString()
    {
        return String.Join('/', MaximumsList);
    }

    private void DetermineMaximums()
    {
        int estimatedCollectionSize = TextStatistics.HighestCountedSymbol - TextStatistics.LowestCountedSymbol + 1;
        MaximumsList = new(estimatedCollectionSize);

        for (int symbol = TextStatistics.LowestCountedSymbol;
             symbol <= TextStatistics.HighestCountedSymbol;
             symbol++)
        {
            SymbolStatistics? maximumSymbolStatistic = null;

            for (int textStatisticIndex = 0; textStatisticIndex < StatisticsList.Count; textStatisticIndex++)
            {
                TextStatistics currentTextStatistics = StatisticsList[textStatisticIndex];
                SymbolStatistics currentSymbolStatistic = currentTextStatistics.Statistics[(char)symbol];

                if (maximumSymbolStatistic == null)
                {
                    if (currentSymbolStatistic.Count > 1)
                    {
                        maximumSymbolStatistic = currentSymbolStatistic;
                        maximumSymbolStatistic.Prefix = textStatisticIndex + 1;
                    }
                }
                else if (maximumSymbolStatistic.Count < currentSymbolStatistic.Count)
                {
                    maximumSymbolStatistic = currentSymbolStatistic;
                    maximumSymbolStatistic.Prefix = textStatisticIndex + 1;
                }
                else if (maximumSymbolStatistic.Count == currentSymbolStatistic.Count)
                {
                    maximumSymbolStatistic.Prefix = SymbolStatistics.EqualityPrefix;
                }
            }

            if (maximumSymbolStatistic != null)
            {
                MaximumsList.Add(maximumSymbolStatistic);
            }
        }

        MaximumsList = MaximumsList
            .OrderByDescending(x => x.Count)
            .ThenBy(x => x.Prefix)
            .ToList();
    }
}