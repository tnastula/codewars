using System.Collections.Generic;
using CrosswordPuzzle;
using NUnit.Framework;

namespace CrosswordPuzzleTests;

[TestFixture]
public class Tests
{
    [Test]
    public void Puzzle_1()
    {
        string[] puzzle =
        {
            "#_",
            "_G"
        };
        List<object[]> solutions = new List<object[]>()
        {
            new object[] { "AG", "UG", 6 }, new object[] { "UG", "AG", 6 }
        };
        Assert.AreEqual(solutions, Solution.Crossword2x2(puzzle));
    }

    [Test]
    public void Puzzle_2()
    {
        string[] puzzle =
        {
            "_V",
            "_#"
        };
        List<object[]> solutions = new List<object[]>() { };
        Assert.AreEqual(solutions, Solution.Crossword2x2(puzzle));
    }

    [Test]
    public void Puzzle_3()
    {
        string[] puzzle =
        {
            "Q_",
            "#_"
        };
        List<object[]> solutions = new List<object[]>()
        {
            new object[] { "QI", "IF", 16 }, new object[] { "QI", "ID", 14 }, new object[] { "QI", "IN", 13 },
            new object[] { "QI", "IO", 13 }, new object[] { "QI", "IS", 13 }, new object[] { "QI", "IT", 13 }
        };
        Assert.AreEqual(solutions, Solution.Crossword2x2(puzzle));
    }

    [Test]
    public void Puzzle_4()
    {
        string[] puzzle =
        {
            "__",
            "#P"
        };
        List<object[]> solutions = new List<object[]>()
        {
            new object[] { "ZO", "OP", 15 }, new object[] { "JO", "OP", 13 }, new object[] { "XU", "UP", 13 },
            new object[] { "KO", "OP", 10 }, new object[] { "HO", "OP", 9 }, new object[] { "WO", "OP", 9 },
            new object[] { "YO", "OP", 9 }, new object[] { "YU", "UP", 9 }, new object[] { "BO", "OP", 8 },
            new object[] { "MO", "OP", 8 }, new object[] { "MU", "UP", 8 }, new object[] { "PO", "OP", 8 },
            new object[] { "DO", "OP", 7 }, new object[] { "GO", "OP", 7 }, new object[] { "GU", "UP", 7 },
            new object[] { "IO", "OP", 6 }, new object[] { "LO", "OP", 6 }, new object[] { "NO", "OP", 6 },
            new object[] { "NU", "UP", 6 }, new object[] { "OO", "OP", 6 }, new object[] { "OU", "UP", 6 },
            new object[] { "SO", "OP", 6 }, new object[] { "TO", "OP", 6 }
        };
        Assert.AreEqual(solutions, Solution.Crossword2x2(puzzle));
    }
}