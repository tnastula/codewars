using AssemblerInterpreter.Instructions.Base;
using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions;

public class Call : Instruction
{
    public Call(IInterpreter interpreter, List<Token> arguments) : base(interpreter, arguments)
    {
    }

    public override void Perform()
    {
        Validate();

        Interpreter.CallFunction(Arguments[0].StringValue);
    }

    public override void Validate()
    {
        if (Arguments.Count != 1)
        {
            throw new ArgumentException("Call instruction expects 1 argument");
        }

        if (Arguments[0].Type != TokenType.Identifier)
        {
            throw new ArgumentException(
                "Call instruction expects argument 0 to be of type: Identifier");
        }
    }
}