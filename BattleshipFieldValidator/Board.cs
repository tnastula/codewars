namespace BattleshipFieldValidator;

public class Board
{
    private const int SizeX = 10;
    private const int SizeY = 10;

    private static readonly Dictionary<int, int> LegalShipSizeToShipsCount = new()
    {
        { 4, 1 },
        { 3, 2 },
        { 2, 3 },
        { 1, 4 }
    };

    private Dictionary<int, Dictionary<int, Field>> Fields { get; set; }
    private Dictionary<int, int> DiscoveredShipSizeToShipsCount { get; set; }

    public Board(int[,] fields)
    {
        DiscoveredShipSizeToShipsCount = new(0);
        Fields = new(SizeY);

        for (int y = 0; y < SizeY; y++)
        {
            Fields[y] = new(SizeX);

            for (int x = 0; x < SizeX; x++)
            {
                Fields[y][x] = new(x, y, fields[y, x] == 1);
            }
        }
    }

    public bool Validate()
    {
        DiscoveredShipSizeToShipsCount = new()
        {
            { 4, 0 },
            { 3, 0 },
            { 2, 0 },
            { 1, 0 }
        };

        for (int x = 0; x < SizeX; x++)
        {
            for (int y = 0; y < SizeY; y++)
            {
                Field? field = GetField(x, y);

                if (field!.WasVerified)
                {
                    continue;
                }

                if (field.IsOccupied && !ValidateShip(field))
                {
                    return false;
                }

                field.WasVerified = true;
            }
        }

        foreach (int shipSize in LegalShipSizeToShipsCount.Keys)
        {
            if (DiscoveredShipSizeToShipsCount[shipSize] != LegalShipSizeToShipsCount[shipSize])
            {
                return false;
            }
        }

        return true;
    }

    private bool ValidateShip(Field field)
    {
        Orientation orientation = Orientation.Vertical;
        List<Field> ship = GetShip(field, orientation);
        
        if (ship.Count == 1)
        {
            orientation = Orientation.Horizontal;
            ship = GetShip(field, orientation);
        }

        if (!ValidateShipLength(ship))
        {
            return false;
        }

        return ValidateNoNeighbours(ship, orientation);
    }

    private bool ValidateShipLength(List<Field> ship)
    {
        if (!DiscoveredShipSizeToShipsCount.ContainsKey(ship.Count))
        {
            return false;
        }

        DiscoveredShipSizeToShipsCount[ship.Count]++;
        if (DiscoveredShipSizeToShipsCount[ship.Count] > LegalShipSizeToShipsCount[ship.Count])
        {
            return false;
        }

        return true;
    }

    private bool ValidateNoNeighbours(List<Field> ship, Orientation orientation)
    {
        List<Field?> shouldBeUnoccupied = new(ship.Count * 2 + 6);
        int xOffset = orientation == Orientation.Vertical
            ? 1
            : 0;
        int yOffset = orientation == Orientation.Horizontal
            ? 1
            : 0;
        
        // Main sequence
        foreach (Field field in ship)
        {
            shouldBeUnoccupied.Add(GetField(field.X + xOffset, field.Y + yOffset));
            shouldBeUnoccupied.Add(GetField(field.X - xOffset, field.Y - yOffset));
        }
        
        // Endings
        Field head = ship.First();
        Field tail = ship.Last();

        for (int offset = -1; offset < 2; offset++)
        {
            if (orientation == Orientation.Horizontal)
            {
                shouldBeUnoccupied.Add(GetField(head.X - 1, head.Y + offset));
                shouldBeUnoccupied.Add(GetField(tail.X + 1, tail.Y + offset));
            }
            else if (orientation == Orientation.Vertical)
            {
                shouldBeUnoccupied.Add(GetField(head.X + offset, head.Y - 1));
                shouldBeUnoccupied.Add(GetField(tail.X + offset, tail.Y + 1));
            }
        }

        shouldBeUnoccupied.RemoveAll(x => x == null);
        if (shouldBeUnoccupied.Any(x => x!.IsOccupied))
        {
            return false;
        }
        
        return true;
    }

    private List<Field> GetShip(Field field, Orientation orientation)
    {
        List<Field> ship = new(4);
        
        // Since we move left to right and top to bottom,
        // we need to check only towards right and bottom 
        int xStep = orientation == Orientation.Horizontal ? 1 : 0;
        int yStep = orientation == Orientation.Vertical ? 1 : 0;

        Field? currentField = field;
        do
        {
            currentField.WasVerified = true;
            ship.Add(currentField);

            currentField = GetField(
                currentField.X + xStep,
                currentField.Y + yStep
            );
        } while (currentField is { IsOccupied: true });

        return ship;
    }

    private Field? GetField(int x, int y)
    {
        if (x is < 0 or >= SizeX || y is < 0 or >= SizeY)
        {
            return null;
        }

        return Fields[y][x];
    }
}