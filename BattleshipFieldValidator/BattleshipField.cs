namespace BattleshipFieldValidator;

public static class BattleshipField
{
    public static bool ValidateBattlefield(int[,] field)
    {
        Board board = new(field);
        return board.Validate();
    }
}