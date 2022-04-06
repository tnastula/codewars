using SimpleAssemblerInterpreter.Interfaces;

namespace SimpleAssemblerInterpreter.Instructions;

public class Jnz : Instruction
{
    public Jnz(IInterpreter interpreter, List<string> arguments) : base(interpreter, arguments)
    {
    }

    public override void Perform()
    {
        Validate();

        int conditionalValue = GetArgumentOrRegisterItPointsToValue(0);
        if (conditionalValue == 0)
        {
            return;
        }

        // -1 since we increment index after each loop in interpreter
        int offsetValue = GetArgumentOrRegisterItPointsToValue(1) - 1;
        int currentIndex = Interpreter.GetInstructionIndex();
        Interpreter.SetInstructionIndex(currentIndex + offsetValue);
    }

    public override void Validate()
    {
        if (Arguments.Count != 2)
        {
            throw new ArgumentException();
        }
    }
}