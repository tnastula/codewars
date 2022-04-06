using SimpleAssemblerInterpreter.Interfaces;

namespace SimpleAssemblerInterpreter;

public abstract class Instruction
{
    protected IInterpreter Interpreter;
    protected List<Argument> Arguments;

    protected Instruction(IInterpreter interpreter, List<string> arguments)
    {
        Interpreter = interpreter;

        Arguments = new(arguments.Count);
        foreach (string argument in arguments)
        {
            Arguments.Add(new(argument));
        }
    }

    protected int GetArgumentOrRegisterItPointsToValue(int argumentIndex)
    {
        return Arguments[argumentIndex].Type == ArgumentType.Constant
            ? Arguments[argumentIndex].NumericValue.GetValueOrDefault()
            : Interpreter.GetRegisterValue(Arguments[argumentIndex].StringValue);
    }

    public abstract void Perform();
    public abstract void Validate();
}