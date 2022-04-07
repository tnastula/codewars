using AssemblerInterpreter.Instructions.Base;
using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions;

public class Add : Instruction
{
    public Add(IInterpreter interpreter, List<Token> arguments) : base(interpreter, arguments)
    {
    }

    public override void Perform()
    {
        Validate();

        int currentValue = Interpreter.GetRegisterValue(Arguments[0].StringValue);
        int valueToAdd = GetArgumentOrRegisterItPointsToValue(1);

        Interpreter.SetRegisterValue(
            Arguments[0].StringValue,
            currentValue + valueToAdd
        );
    }

    public override void Validate()
    {
        if (Arguments.Count != 2)
        {
            throw new ArgumentException("Add instruction expects 2 arguments");
        }

        if (Arguments[0].Type != TokenType.Identifier)
        {
            throw new ArgumentException("Add instruction expects argument 0 to be of type: Identifier");
        }

        if (Arguments[1].Type != TokenType.Identifier
            && Arguments[1].Type != TokenType.Integer)
        {
            throw new ArgumentException("Add instruction expects argument 1 to be of type: Identifier, Integer");
        }
    }
}