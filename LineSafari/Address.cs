namespace LineSafari;

public class Address
{
    private const char CornerSymbol = '+';
    private const char VerticalSymbol = '|';
    private const char HorizontalSymbol = '-';
    private const char EndpointSymbol = 'X';
    
    public int X { get; set; }
    public int Y { get; set; }
    public AddressType Type { get; private set; }
    public bool Visited { get; set; }

    public Address(int x, int y, char symbol)
    {
        X = x;
        Y = y;
        Visited = false;

        switch (symbol)
        {
            case CornerSymbol:
                Type = AddressType.Corner;
                break;
            case VerticalSymbol:
                Type = AddressType.Vertical;
                break;
            case HorizontalSymbol:
                Type = AddressType.Horizontal;
                break;
            case EndpointSymbol:
                Type = AddressType.Endpoint;
                break;
            default:
                Type = AddressType.Blank;
                break;
        }
    }
    
    public Direction GetDirection(Address towards)
    {
        if (Y < towards.Y)
        {
            return Direction.South;
        }

        if (Y > towards.Y)
        {
            return Direction.North;
        }

        return X < towards.X 
            ? Direction.West 
            : Direction.East;
    }

    public override string ToString()
    {
        return $"x{X}:y{Y}:{Type}";
    }
}