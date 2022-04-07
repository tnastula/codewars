using System.Text;

namespace AssemblerInterpreter.Lexing;

public class Lexer
{
    private const char StatementSeparator = '\n';
    private const char StringLiteralMarker = '\'';
    private const char CommentMarker = ';';
    private const char LabelMarker = ':';
    private const char WhiteSpace = ' ';

    private readonly string[] _instructionIdentifiers =
    {
        "mov",
        "inc",
        "dec",
        "add",
        "sub",
        "mul",
        "div",
        "jmp",
        "cmp",
        "jne",
        "je",
        "jge",
        "jg",
        "jle",
        "jl",
        "call",
        "ret",
        "msg",
        "end"
    };

    private readonly char[] _ignoredSymbols =
    {
        ','
    };

    private StringBuilder _accumulator;
    private bool _insideStringLiteral;
    private List<Token> _tokens;
    
    public List<Statement> Lex(string program)
    {
        string[] statementBodies = program.Split(StatementSeparator);
        List<Statement> statements = new(statementBodies.Length);

        foreach (string statementBody in statementBodies)
        {
            statements.Add(LexStatement(statementBody));
        }

        return statements;
    }

    private Statement LexStatement(string statement)
    {
        _accumulator = new();
        _insideStringLiteral = false;
        _tokens = new(4);
        
        for (int symbolIndex = 0; symbolIndex < statement.Length; symbolIndex++)
        {
            char symbol = statement[symbolIndex];
            Token token;

            if (_insideStringLiteral)
            {
                if (symbol == StringLiteralMarker)
                {
                    _insideStringLiteral = false;
                    token = new(_accumulator.ToString(), null, TokenType.StringLiteral);
                    _tokens.Add(token);
                    _accumulator.Clear();
                }
                else
                {
                    _accumulator.Append(symbol);
                }

                continue;
            }

            switch (symbol)
            {
                case StringLiteralMarker:
                    _insideStringLiteral = true;
                    break;

                case CommentMarker:
                    token = new(statement[(symbolIndex + 1)..], null, TokenType.Comment);
                    _tokens.Add(token);
                    symbolIndex = statement.Length; // break outer loop
                    break;

                case LabelMarker:
                    token = new(_accumulator.ToString(), null, TokenType.LabelName);
                    _tokens.Add(token);
                    _accumulator.Clear();
                    break;

                case WhiteSpace:
                    HandleEndOfString();
                    break;

                default:
                    if (_ignoredSymbols.Contains(symbol))
                        continue;
                    
                    _accumulator.Append(symbol);
                    break;
            }
        }

        HandleEndOfString();
        
        return new(_tokens);
    }

    private void HandleEndOfString()
    {
        if (_accumulator.Length == 0)
            return;
                    
        string tokenBody = _accumulator.ToString();
        _accumulator.Clear();

        Token token;
        if (_instructionIdentifiers.Contains(tokenBody))
        {
            token = new(tokenBody, null, TokenType.Instruction);
        }
        else if (Int32.TryParse(tokenBody, out int numericValue))
        {
            token = new(tokenBody, numericValue, TokenType.Integer);
        }
        else
        {
            token = new(tokenBody, null, TokenType.Identifier);
        }

        _tokens.Add(token);
    }
}