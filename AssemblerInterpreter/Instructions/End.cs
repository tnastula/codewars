using AssemblerInterpreter.Instructions.Base;
using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions;

public class End : Instruction
{
    public End(IInterpreter interpreter, List<Token> arguments) : base(interpreter, arguments)
    {
    }

    public override void Perform()
    {
        Validate();

        Interpreter.EndProgram();
    }

    public override void Validate()
    {
        if (Arguments.Count != 0)
        {
            throw new ArgumentException("End instruction expects no arguments");
        }
    }
}