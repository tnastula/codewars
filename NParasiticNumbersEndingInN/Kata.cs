namespace NParasiticNumbersEndingInN;

public static class Kata
{
    public static string CalculateSpecial(int trailingDigit, int numberBase)
    {
        var finder = new ParasiticNumberFinder(trailingDigit, numberBase);
        return finder.Calculate();
    }
}