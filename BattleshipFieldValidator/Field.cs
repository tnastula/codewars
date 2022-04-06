namespace BattleshipFieldValidator;

public class Field
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsOccupied { get; private set; }
    public bool WasVerified { get; set; }

    public Field(int x, int y, bool isOccupied)
    {
        X = x;
        Y = y;
        IsOccupied = isOccupied;
        WasVerified = false;
    }
}