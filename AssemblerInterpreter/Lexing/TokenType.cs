namespace AssemblerInterpreter.Lexing;

public enum TokenType
{
    Instruction,
    Comment,
    Identifier,
    LabelName,
    Integer,
    StringLiteral
}