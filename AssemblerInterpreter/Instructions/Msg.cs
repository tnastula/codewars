using System.Text;
using AssemblerInterpreter.Instructions.Base;
using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions;

public class Msg : Instruction
{
    public Msg(IInterpreter interpreter, List<Token> arguments) : base(interpreter, arguments)
    {
    }

    public override void Perform()
    {
        Validate();

        StringBuilder stringBuilder = new();
        foreach (Token argument in Arguments)
        {
            if (argument.Type == TokenType.StringLiteral)
            {
                stringBuilder.Append(argument.StringValue);
            }
            else if (argument.Type == TokenType.Identifier)
            {
                stringBuilder.Append(Interpreter.GetRegisterValue(argument.StringValue));
            }
        }
        
        Interpreter.SetMessage(stringBuilder.ToString());
    }

    public override void Validate()
    {
        if (Arguments.Count == 0)
        {
            throw new ArgumentException("Msg instruction expects at least one argument");
        }

        foreach (Token argument in Arguments)
        {
            if (argument.Type != TokenType.Identifier
                && argument.Type != TokenType.StringLiteral)
            {
                throw new ArgumentException(
                    "Msg instruction expects all arguments to be of type: Identifier, StringLiteral");
            }
        }
    }
}