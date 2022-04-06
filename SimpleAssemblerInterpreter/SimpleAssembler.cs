namespace SimpleAssemblerInterpreter;

public static class SimpleAssembler
{
    public static Dictionary<string, int> Interpret(string[] program)
    {
        Interpreter interpreter = new(program);
        return interpreter.Registers;
    }
}