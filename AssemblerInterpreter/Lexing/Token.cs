namespace AssemblerInterpreter.Lexing;

public class Token
{
    public readonly string StringValue;
    public readonly int? NumericValue;
    public readonly TokenType Type;

    public Token(string stringValue, int? numericValue, TokenType type)
    {
        StringValue = stringValue;
        NumericValue = numericValue;
        Type = type;
    }
}