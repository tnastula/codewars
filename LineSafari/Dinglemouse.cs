namespace LineSafari;

public class Dinglemouse
{
    public static bool Line(char[][] grid)
    {
        Grid dingleMouse = new (grid);
        return dingleMouse.ContainsValidLine();
    }
}