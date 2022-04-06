using SimpleAssemblerInterpreter.Instructions;
using SimpleAssemblerInterpreter.Interfaces;

namespace SimpleAssemblerInterpreter;

public class InstructionFactory
{
    public Instruction Create(string instructionBody, IInterpreter interpreter)
    {
        instructionBody = instructionBody.TrimStart();
        string[] instructionParts = instructionBody.Split(' ');

        if (instructionParts.Length < 2)
        {
            throw new FormatException();
        }

        List<string> arguments = instructionParts[1..].ToList();

        switch (instructionParts[0])
        {
            case "mov":
                return new Mov(interpreter, arguments);

            case "inc":
                return new Inc(interpreter, arguments);

            case "dec":
                return new Dec(interpreter, arguments);

            case "jnz":
                return new Jnz(interpreter, arguments);

            default:
                throw new NotImplementedException();
        }
    }
}