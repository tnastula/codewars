using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions.Base;

public abstract class Instruction
{
    protected IInterpreter Interpreter;
    protected List<Token> Arguments;

    protected Instruction(IInterpreter interpreter, List<Token> arguments)
    {
        Interpreter = interpreter;
        Arguments = arguments.Where(x => x.Type != TokenType.Comment).ToList();
    }

    protected int GetArgumentOrRegisterItPointsToValue(int argumentIndex)
    {
        if (Arguments[argumentIndex].Type == TokenType.Integer)
            return Arguments[argumentIndex].NumericValue.GetValueOrDefault();
        
        if (Arguments[argumentIndex].Type == TokenType.Identifier)
            return Interpreter.GetRegisterValue(Arguments[argumentIndex].StringValue);

        throw new ArgumentException(
            "GetArgumentOrRegisterItPointsToValue expects argument to be of type Identifier, Integer");
    }

    public abstract void Perform();
    public abstract void Validate();
}