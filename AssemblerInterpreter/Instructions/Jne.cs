using AssemblerInterpreter.Instructions.Base;
using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions;

public class Jne : ConditionalJumpInstruction
{
    public Jne(IInterpreter interpreter, List<Token> arguments) : base(interpreter, arguments)
    {
    }

    protected override bool ShouldPerformJump()
    {
        return Interpreter.GetLastComparisonResult() != ComparisonResult.Equal;
    }
}