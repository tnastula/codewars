using AssemblerInterpreter.Instructions.Base;
using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions;

public class Inc : Instruction
{
    public Inc(IInterpreter interpreter, List<Token> arguments) : base(interpreter, arguments)
    {
    }

    public override void Perform()
    {
        Validate();

        int value = Interpreter.GetRegisterValue(Arguments[0].StringValue);
        Interpreter.SetRegisterValue(Arguments[0].StringValue, value + 1);
    }

    public override void Validate()
    {
        if (Arguments.Count != 1)
        {
            throw new ArgumentException("Inc instruction expects 1 argument");
        }

        if (Arguments[0].Type != TokenType.Identifier)
        {
            throw new ArgumentException("Inc instruction expects argument 0 to be of type: Identifier");
        }
    }
}