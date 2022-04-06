using NUnit.Framework;
using ScreenLockingPatterns;

namespace ScreenLockingPatternsTests;

public class Tests
{
    [Test, Description("Example Tests")]
    [TestCase('A', 0, ExpectedResult = 0)]
    [TestCase('A', 10, ExpectedResult = 0)]
    [TestCase('B', 1, ExpectedResult = 1)]
    [TestCase('C', 2, ExpectedResult = 5)]
    [TestCase('D', 3, ExpectedResult = 37)]
    [TestCase('E', 4, ExpectedResult = 256)]
    [TestCase('E', 8, ExpectedResult = 23280)]
    public int ExampleTests(char firstDot, int length)
    {
        return Kata.CountPatternsFrom(firstDot, length);
    }
}