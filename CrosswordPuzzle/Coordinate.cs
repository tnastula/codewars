namespace CrosswordPuzzle;

public class Coordinate
{
    public int X { get; }
    public int Y { get; }

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public PositionType PositionInRelationTo(Coordinate other)
    {
        if (X == other.X && Y > other.Y)
        {
            return PositionType.Below;
        }

        if (X == other.X && Y < other.Y)
        {
            return PositionType.Above;
        }

        if (Y == other.Y && X > other.X)
        {
            return PositionType.Right;
        }

        if (Y == other.Y && X < other.X)
        {
            return PositionType.Left;
        }

        return PositionType.Across;
    }
}