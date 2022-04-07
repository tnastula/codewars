using AssemblerInterpreter.Instructions.Base;
using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions;

public class Je : ConditionalJumpInstruction
{
    public Je(IInterpreter interpreter, List<Token> arguments) : base(interpreter, arguments)
    {
    }

    protected override bool ShouldPerformJump()
    {
        return Interpreter.GetLastComparisonResult() == ComparisonResult.Equal;
    }
}