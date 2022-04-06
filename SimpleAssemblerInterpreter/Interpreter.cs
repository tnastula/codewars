using SimpleAssemblerInterpreter.Interfaces;

namespace SimpleAssemblerInterpreter;

public class Interpreter : IInterpreter
{
    public Dictionary<string, int> Registers { get; private set; }
    private readonly List<Instruction> _instructions;
    private int _instructionIndex;

    public Interpreter(string[] program)
    {
        Registers = new();

        InstructionFactory instructionFactory = new();
        _instructions = new(program.Length);
        foreach (string instructionBody in program)
        {
            _instructions.Add(instructionFactory.Create(instructionBody, this));
        }

        _instructionIndex = 0;

        Interpret();
    }

    private void Interpret()
    {
        while (_instructionIndex < _instructions.Count)
        {
            Instruction currentInstruction = _instructions[_instructionIndex];
            currentInstruction.Perform();
            _instructionIndex++;
        }
    }

    public int GetRegisterValue(string register)
    {
        return Registers[register];
    }

    public void SetRegisterValue(string register, int value)
    {
        Registers[register] = value;
    }

    public int GetInstructionIndex()
    {
        return _instructionIndex;
    }

    public void SetInstructionIndex(int index)
    {
        _instructionIndex = index;
    }
}