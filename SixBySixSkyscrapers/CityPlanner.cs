using SixBySixSkyscrapers.Interfaces;
using SixBySixSkyscrapers.Models;

namespace SixBySixSkyscrapers;

public class CityPlanner
{
    private static readonly List<IFact> _facts;

    static CityPlanner()
    {
        _facts = new List<IFact>();
        // TODO: fill in the facts
    }

    public int[][] Plan(int[] clueValues)
    {
        City city = City.FromClueValues(clueValues);

        // TODO: Implement
    }
}