using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions.Base;

public abstract class ConditionalJumpInstruction : Instruction
{
    protected ConditionalJumpInstruction(IInterpreter interpreter, List<Token> arguments) : base(interpreter, arguments)
    {
    }

    protected abstract bool ShouldPerformJump();

    public override void Perform()
    {
        Validate();

        if (ShouldPerformJump())
        {
            Interpreter.JumpToLabel(Arguments[0].StringValue);
        }
    }

    public override void Validate()
    {
        if (Arguments.Count != 1)
        {
            throw new ArgumentException("ConditionalJumpInstruction instruction expects 1 argument");
        }

        if (Arguments[0].Type != TokenType.Identifier)
        {
            throw new ArgumentException(
                "ConditionalJumpInstruction instruction expects argument 0 to be of type: Identifier");
        }
    }
}