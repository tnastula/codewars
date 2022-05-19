namespace SixBySixSkyscrapers.Models;

public class Clue
{
    public static Clue Null = new NullClue();
    
    public int Value { get; set; }

    private class NullClue : Clue
    {
        
    }
}