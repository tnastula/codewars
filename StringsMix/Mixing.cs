namespace StringsMix;

public static class Mixing 
{
    public static string Mix(string s1, string s2)
    {
        TextComparer comparer = new(s1, s2);
        return comparer.ToString();
    }
}