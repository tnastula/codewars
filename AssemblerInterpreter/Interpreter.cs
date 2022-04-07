using AssemblerInterpreter.Instructions.Base;
using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter;

public class Interpreter : IInterpreter
{
    public string? Output { get; private set; }
    
    private readonly Dictionary<string, int> _registers;
    private readonly Dictionary<string, int> _identifierToInstructionIndex;
    private readonly Stack<int> _callstack;
    private ComparisonResult? _lastComparisonResult;
    private string _message;

    private readonly List<Instruction> _instructions;
    private int _instructionIndex;

    public Interpreter(string program)
    {
        Output = null;
        _registers = new();
        _identifierToInstructionIndex = new();
        _callstack = new();

        Lexer lexer = new();
        List<Statement> statements = lexer.Lex(program);

        InstructionFactory instructionFactory = new();
        _instructions = new(program.Length);

        foreach (Statement statement in statements)
        {
            if (statement.MainToken?.Type == TokenType.Instruction)
            {
                _instructions.Add(instructionFactory.Create(statement, this));
            }
            else if (statement.MainToken?.Type == TokenType.LabelName)
            {
                _identifierToInstructionIndex[statement.MainToken.StringValue] = _instructions.Count;
            }
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

    public void SetMessage(string message)
    {
        _message = message;
    }

    public int GetRegisterValue(string register)
    {
        return _registers[register];
    }

    public void SetRegisterValue(string register, int value)
    {
        _registers[register] = value;
    }

    public void JumpToLabel(string label)
    {
        // -1 since we increment index in each interpretation loop iteration
        _instructionIndex = _identifierToInstructionIndex[label] - 1;
    }

    public void CallFunction(string function)
    {
        _callstack.Push(_instructionIndex);
        // -1 since we increment index in each interpretation loop iteration
        _instructionIndex = _identifierToInstructionIndex[function] - 1;
    }

    public void ReturnFromFunction()
    {
        // No -1 here since we want to move behind 'call ...' instruction
        _instructionIndex = _callstack.Pop();
    }

    public ComparisonResult GetLastComparisonResult()
    {
        return _lastComparisonResult ??
               throw new InvalidOperationException(
                   "Attempt to get last comparison result without any comparison being performed yet");
    }

    public void SetComparisonResult(ComparisonResult result)
    {
        _lastComparisonResult = result;
    }

    public void EndProgram()
    {
        Output = _message;
        _instructionIndex = _instructions.Count;
    }
}