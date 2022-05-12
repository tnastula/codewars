namespace CrosswordPuzzle;

public class Coordinate
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }

    public List<Coordinate> GetNeighbors(List<Coordinate> avoidCoordinates)
    {
        List<Coordinate> neighbors = new List<Coordinate>(2)
        {
            new Coordinate(Math.Abs(X - 1), Y),
            new Coordinate(X, Math.Abs(Y - 1))
        };

        neighbors.RemoveAll(coord => avoidCoordinates.Any(avoid => avoid.Equals(coord)));

        return neighbors;
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

    public bool Equals(Coordinate? other)
    {
        if (ReferenceEquals(null, other))
        {
            return false;
        }

        if (ReferenceEquals(this, other))
        {
            return true;
        }

        return X == other.X && Y == other.Y;
    }
}