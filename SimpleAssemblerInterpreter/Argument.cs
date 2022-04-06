namespace SimpleAssemblerInterpreter;

public class Argument
{
    public readonly string StringValue;
    public readonly int? NumericValue;
    public readonly ArgumentType Type;

    public Argument(string stringValue)
    {
        StringValue = stringValue;

        if (Int32.TryParse(StringValue, out int numericValue))
        {
            NumericValue = numericValue;
        }
        else
        {
            NumericValue = null;
        }

        Type = NumericValue == null
            ? ArgumentType.Register
            : ArgumentType.Constant;
    }
}