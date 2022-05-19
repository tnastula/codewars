namespace SixBySixSkyscrapers;

public class Skyscrapers
{
    public static int[][] SolvePuzzle(int[] clues)
    {
        City city = new City(clues);
        city.Build();
        return city.Map;
    }
}