namespace SixBySixSkyscrapers.Models;

public class Clue
{
    public static Clue Null = new NullClue();

    public int Value { get; set; }

    private class NullClue : Clue
    {
    }

    public static Clue FromValue(int value)
    {
        return value == 0
            ? Null
            : new Clue() { Value = value };
    }
    
    public static List<Clue> FromValues(int[] values)
    {
        List<Clue> clues = new List<Clue>(values.Length);
        foreach (int clueValue in values)
        {
            clues.Add(FromValue(clueValue));
        }

        return clues;
    }
}