using BattleshipFieldValidator;
using NUnit.Framework;

namespace BattleshipFieldValidatorTests;

public class Tests
{
    [Test]
    public void TestCase()
    {
        int[,] field = new int[10, 10]
        {
            { 1, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
            { 1, 0, 1, 0, 0, 0, 0, 0, 1, 0 },
            { 1, 0, 1, 0, 1, 1, 1, 0, 1, 0 },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            { 0, 0, 0, 0, 1, 1, 1, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
            { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };
        
        Assert.IsTrue(BattleshipField.ValidateBattlefield(field));
    }
}