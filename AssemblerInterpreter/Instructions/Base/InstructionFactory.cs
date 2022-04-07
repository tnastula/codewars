using AssemblerInterpreter.Interfaces;
using AssemblerInterpreter.Lexing;

namespace AssemblerInterpreter.Instructions.Base;

public class InstructionFactory
{
    public Instruction Create(Statement statement, IInterpreter interpreter)
    {
        switch (statement.MainToken?.StringValue)
        {
            case "add":
                return new Add(interpreter, statement.Arguments);
            
            case "call":
                return new Call(interpreter, statement.Arguments);
            
            case "cmp":
                return new Cmp(interpreter, statement.Arguments);
            
            case "dec":
                return new Dec(interpreter, statement.Arguments);
            
            case "div":
                return new Div(interpreter, statement.Arguments);
            
            case "end":
                return new End(interpreter, statement.Arguments);
            
            case "inc":
                return new Inc(interpreter, statement.Arguments);

            case "je":
                return new Je(interpreter, statement.Arguments);

            case "jg":
                return new Jg(interpreter, statement.Arguments);

            case "jge":
                return new Jge(interpreter, statement.Arguments);

            case "jl":
                return new Jl(interpreter, statement.Arguments);

            case "jle":
                return new Jle(interpreter, statement.Arguments);

            case "jmp":
                return new Jmp(interpreter, statement.Arguments);

            case "jne":
                return new Jne(interpreter, statement.Arguments);

            case "mov":
                return new Mov(interpreter, statement.Arguments);

            case "msg":
                return new Msg(interpreter, statement.Arguments);

            case "mul":
                return new Mul(interpreter, statement.Arguments);

            case "ret":
                return new Ret(interpreter, statement.Arguments);

            case "sub":
                return new Sub(interpreter, statement.Arguments);

            default:
                throw new NotImplementedException();
        }
    }
}