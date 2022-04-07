namespace AssemblerInterpreter;

public static class AssemblerInterpreter
{
    public static string? Interpret(string program)
    {
        Interpreter interpreter = new Interpreter(program);
        return interpreter.Output;
    }
}