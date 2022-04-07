using AssemblerInterpreter.Instructions.Base;
using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions;

public class Div : Instruction
{
    public Div(IInterpreter interpreter, List<Token> arguments) : base(interpreter, arguments)
    {
    }

    public override void Perform()
    {
        Validate();

        int currentValue = Interpreter.GetRegisterValue(Arguments[0].StringValue);
        int divider = GetArgumentOrRegisterItPointsToValue(1);

        Interpreter.SetRegisterValue(
            Arguments[0].StringValue,
            currentValue / divider
        );
    }

    public override void Validate()
    {
        if (Arguments.Count != 2)
        {
            throw new ArgumentException("Div instruction expects 2 arguments");
        }

        if (Arguments[0].Type != TokenType.Identifier)
        {
            throw new ArgumentException("Div instruction expects argument 0 to be of type: Identifier");
        }

        if (Arguments[1].Type != TokenType.Identifier
            && Arguments[1].Type != TokenType.Integer)
        {
            throw new ArgumentException("Div instruction expects argument 1 to be of type: Identifier, Integer");
        }
    }
}