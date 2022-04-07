namespace AssemblerInterpreter.Interfaces;

public interface IInterpreter
{
    void SetMessage(string message);
    int GetRegisterValue(string register);
    void SetRegisterValue(string register, int value);
    void JumpToLabel(string label);
    void CallFunction(string function);
    void ReturnFromFunction();
    ComparisonResult GetLastComparisonResult();
    void SetComparisonResult(ComparisonResult result);
    void EndProgram();
}