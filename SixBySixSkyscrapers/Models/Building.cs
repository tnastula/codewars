namespace SixBySixSkyscrapers.Models;

public sealed class Building
{
    public Height Height { get; set; }
    
    public Building(Height height)
    {
        Height = height;
    }
}