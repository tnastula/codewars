namespace LineSafari;

public class Grid
{
    private readonly Dictionary<int, Dictionary<int, Address>> _grid;
    private int Height => _grid.Count;
    private int Width => _grid.Values.FirstOrDefault()?.Count ?? 0;

    private readonly List<Address> _endpoints;

    public Grid(char[][] grid)
    {
        _endpoints = new(2);
        _grid = new(grid.Length);

        for (int y = 0; y < grid.Length; y++)
        {
            _grid[y] = new(grid[y].Length);

            for (int x = 0; x < grid[y].Length; x++)
            {
                Address address = new(x, y, grid[y][x]);
                _grid[y][x] = address;
                if (address.Type == AddressType.Endpoint)
                {
                    _endpoints.Add(address);
                }
            }
        }
    }

    public bool ContainsValidLine()
    {
        if (_endpoints.Count != 2)
        {
            return false;
        }

        bool firstApproach = TryWeaveALine(_endpoints[0], _endpoints[1]) && VerifyNoExtras();
        bool secondApproach = TryWeaveALine(_endpoints[1], _endpoints[0]) && VerifyNoExtras();
        return firstApproach || secondApproach;
    }

    private bool TryWeaveALine(Address start, Address end)
    {
        foreach (Dictionary<int, Address> row in _grid.Values)
        {
            foreach (Address cell in row.Values)
            {
                cell.Visited = false;
            }
        }

        Address current = start;
        current.Visited = true;
        Address? previous = null;

        do
        {
            Address? nextStep = DetermineNextStep(current, previous);
            if (nextStep == null)
            {
                return false;
            }

            previous = current;
            current = nextStep;
            current.Visited = true;
        } while (current != end);

        return true;
    }

    private Address? DetermineNextStep(Address current, Address? previous)
    {
        Direction? currentDirection = previous?.GetDirection(current);
        HashSet<Direction> viableNextDirections = new(4);

        if (current.Type == AddressType.Endpoint)
        {
            viableNextDirections.Add(Direction.North);
            viableNextDirections.Add(Direction.South);
            viableNextDirections.Add(Direction.East);
            viableNextDirections.Add(Direction.West);
        }
        else if (current.Type == AddressType.Corner)
        {
            if (currentDirection is Direction.North or Direction.South)
            {
                viableNextDirections.Add(Direction.East);
                viableNextDirections.Add(Direction.West);
            }
            else
            {
                viableNextDirections.Add(Direction.North);
                viableNextDirections.Add(Direction.South);
            }
        }
        else if (current.Type is AddressType.Horizontal or AddressType.Vertical)
        {
            viableNextDirections.Add(currentDirection.GetValueOrDefault());
        }

        List<Address> possibleNextSteps = new(viableNextDirections.Count);
        foreach (Direction viableNextDirection in viableNextDirections)
        {
            Address? nextStep = GetAdjacent(current, viableNextDirection);
            if (nextStep != null && IsValidNextStep(current, nextStep))
            {
                possibleNextSteps.Add(nextStep);
            }
        }

        return possibleNextSteps.Count == 1
            ? possibleNextSteps.First()
            : null;
    }

    private bool VerifyNoExtras()
    {
        return !_grid.Values.Any(row
            => row.Values.Any(cell
                => cell.Visited == false && cell.Type != AddressType.Blank));
    }

    private bool IsValidNextStep(Address current, Address next)
    {
        if (next.Visited)
        {
            return false;
        }

        Direction? direction = current.GetDirection(next);
        List<AddressType> validTypes = new(3);
        if (direction is Direction.North or Direction.South)
        {
            validTypes.Add(AddressType.Endpoint);
            validTypes.Add(AddressType.Vertical);
            validTypes.Add(AddressType.Corner);
        }
        else
        {
            validTypes.Add(AddressType.Endpoint);
            validTypes.Add(AddressType.Horizontal);
            validTypes.Add(AddressType.Corner);
        }

        return validTypes.Contains(next.Type);
    }

    private Address? GetAdjacent(Address current, Direction direction)
    {
        int x, y;

        switch (direction)
        {
            case Direction.North:
                x = current.X;
                y = current.Y - 1;
                break;
            case Direction.South:
                x = current.X;
                y = current.Y + 1;
                break;
            case Direction.East:
                x = current.X - 1;
                y = current.Y;
                break;
            case Direction.West:
                x = current.X + 1;
                y = current.Y;
                break;
            default:
                return null;
        }

        if (x < 0 || x >= Width || y < 0 || y >= Height)
        {
            return null;
        }

        return _grid[y][x];
    }
}