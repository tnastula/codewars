using AssemblerInterpreter.Instructions.Base;
using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions;

public class Dec : Instruction
{
    public Dec(IInterpreter interpreter, List<Token> arguments) : base(interpreter, arguments)
    {
    }

    public override void Perform()
    {
        Validate();

        int value = Interpreter.GetRegisterValue(Arguments[0].StringValue);
        Interpreter.SetRegisterValue(Arguments[0].StringValue, value - 1);
    }

    public override void Validate()
    {
        if (Arguments.Count != 1)
        {
            throw new ArgumentException("Dec instruction expects 1 argument");
        }

        if (Arguments[0].Type != TokenType.Identifier)
        {
            throw new ArgumentException("Dec instruction expects argument 0 to be of type: Identifier");
        }
    }
}