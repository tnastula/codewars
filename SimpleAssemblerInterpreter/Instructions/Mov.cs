using SimpleAssemblerInterpreter.Interfaces;

namespace SimpleAssemblerInterpreter.Instructions;

public class Mov : Instruction
{
    public Mov(IInterpreter interpreter, List<string> arguments) : base(interpreter, arguments)
    {
    }

    public override void Perform()
    {
        Validate();

        Interpreter.SetRegisterValue(
            Arguments[0].StringValue,
            GetArgumentOrRegisterItPointsToValue(1)
        );
    }

    public override void Validate()
    {
        if (Arguments.Count != 2)
        {
            throw new ArgumentException();
        }

        if (Arguments[0].Type != ArgumentType.Register)
        {
            throw new ArgumentException();
        }
    }
}