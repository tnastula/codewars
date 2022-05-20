namespace SixBySixSkyscrapers;

public static class Skyscrapers
{
    public static int[][] SolvePuzzle(int[] clues)
    {
        CityPlanner planner = new CityPlanner();
        return planner.Plan(clues);
    }
}