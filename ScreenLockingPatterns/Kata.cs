namespace ScreenLockingPatterns;

public static class Kata
{
    public static int CountPatternsFrom(char firstDot, int length)
    {
        int sorryIDidWithInt = firstDot - 65;
        RouteFinder finder = new RouteFinder(sorryIDidWithInt, length);
        return finder.Find().Count;
    }
}