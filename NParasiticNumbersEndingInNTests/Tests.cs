using NParasiticNumbersEndingInN;
using NUnit.Framework;

namespace NParasiticNumbersEndingInNTests;

public class Tests
{
    [TestCase(4, 16, ExpectedResult = "104")]
    [TestCase(4, 10, ExpectedResult = "102564")]
    public static string SampleTest(int trailingDigit, int numberBase)
    {
        return Kata.CalculateSpecial(trailingDigit, numberBase);
    }
}