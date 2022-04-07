using AssemblerInterpreter.Instructions.Base;
using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions;

public class Cmp : Instruction
{
    public Cmp(IInterpreter interpreter, List<Token> arguments) : base(interpreter, arguments)
    {
    }

    public override void Perform()
    {
        Validate();

        int left = GetArgumentOrRegisterItPointsToValue(0);
        int right = GetArgumentOrRegisterItPointsToValue(1);

        Interpreter.SetComparisonResult(
            left > right
                ? ComparisonResult.LeftGreater
                : left < right
                    ? ComparisonResult.RightGreater
                    : ComparisonResult.Equal
        );
    }

    public override void Validate()
    {
        if (Arguments.Count != 2)
        {
            throw new ArgumentException("Cmp instruction expects 2 arguments");
        }

        if (Arguments[0].Type != TokenType.Identifier
            && Arguments[0].Type != TokenType.Integer)
        {
            throw new ArgumentException("Cmp instruction expects argument 0 to be of type: Identifier, Integer");
        }

        if (Arguments[1].Type != TokenType.Identifier
            && Arguments[1].Type != TokenType.Integer)
        {
            throw new ArgumentException("Cmp instruction expects argument 1 to be of type: Identifier, Integer");
        }
    }
}