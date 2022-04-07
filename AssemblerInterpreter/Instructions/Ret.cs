using AssemblerInterpreter.Instructions.Base;
using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions;

public class Ret : Instruction
{
    public Ret(IInterpreter interpreter, List<Token> arguments) : base(interpreter, arguments)
    {
    }

    public override void Perform()
    {
        Validate();

        Interpreter.ReturnFromFunction();
    }

    public override void Validate()
    {
        if (Arguments.Count != 0)
        {
            throw new ArgumentException("Ret instruction expects no arguments");
        }
    }
}