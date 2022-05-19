namespace SixBySixSkyscrapers.Models;

public class Height
{
    public static Height Null = new NullHeight();
    
    public int Value { get; set; }

    private class NullHeight : Height
    {
        
    }
}