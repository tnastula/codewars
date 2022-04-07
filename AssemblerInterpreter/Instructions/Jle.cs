using AssemblerInterpreter.Instructions.Base;
using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions;

public class Jle : ConditionalJumpInstruction
{
    public Jle(IInterpreter interpreter, List<Token> arguments) : base(interpreter, arguments)
    {
    }

    protected override bool ShouldPerformJump()
    {
        ComparisonResult lastComparisonResult = Interpreter.GetLastComparisonResult();
        return lastComparisonResult == ComparisonResult.RightGreater
               || lastComparisonResult == ComparisonResult.Equal;
    }
}