namespace SimpleAssemblerInterpreter.Interfaces;

public interface IInterpreter
{
    int GetRegisterValue(string register);
    void SetRegisterValue(string register, int value);
    int GetInstructionIndex();
    void SetInstructionIndex(int index);
}