using AssemblerInterpreter.Instructions.Base;
using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions;

public class Jge : ConditionalJumpInstruction
{
    public Jge(IInterpreter interpreter, List<Token> arguments) : base(interpreter, arguments)
    {
    }

    protected override bool ShouldPerformJump()
    {
        ComparisonResult lastComparisonResult = Interpreter.GetLastComparisonResult();
        return lastComparisonResult == ComparisonResult.LeftGreater
               || lastComparisonResult == ComparisonResult.Equal;
    }
}