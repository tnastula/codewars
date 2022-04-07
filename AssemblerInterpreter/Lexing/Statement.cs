namespace AssemblerInterpreter.Lexing;

public class Statement
{
    public readonly List<Token> Tokens;
    public Token? MainToken => Tokens.FirstOrDefault();
    public List<Token> Arguments => Tokens.GetRange(1, Tokens.Count - 1);

    public Statement(List<Token> tokens)
    {
        Tokens = tokens;
    }
}