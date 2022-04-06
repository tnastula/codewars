using SimpleAssemblerInterpreter.Interfaces;

namespace SimpleAssemblerInterpreter.Instructions;

public class Inc : Instruction
{
    public Inc(IInterpreter interpreter, List<string> arguments) : base(interpreter, arguments)
    {
    }

    public override void Perform()
    {
        Validate();

        int value = Interpreter.GetRegisterValue(Arguments[0].StringValue);
        Interpreter.SetRegisterValue(Arguments[0].StringValue, value + 1);
    }

    public override void Validate()
    {
        if (Arguments.Count != 1)
        {
            throw new ArgumentException();
        }

        if (Arguments[0].Type != ArgumentType.Register)
        {
            throw new ArgumentException();
        }
    }
}