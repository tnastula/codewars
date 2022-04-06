using LineSafari;
using NUnit.Framework;

namespace LineSafariTests;

public class Tests
{
    // "Good" examples from the Kata description.
    [Test]
    public void ExGood1()
    {
        var grid = Preloaded.MakeGrid(new[]
        {
            "           ",
            "X---------X",
            "           ",
            "           "
        });
        Preloaded.ShowGrid(grid);
        Assert.AreEqual(true, Dinglemouse.Line(grid));
    }

    [Test]
    public void ExGood2()
    {
        var grid = Preloaded.MakeGrid(new[] 
        {
            "     ",
            "  X  ",
            "  |  ",
            "  |  ",
            "  X  "
        });
        Preloaded.ShowGrid(grid);
        Assert.AreEqual(true, Dinglemouse.Line(grid));
    }

    [Test]
    public void ExGood3()
    {
        var grid = Preloaded.MakeGrid(new[] 
        {
            "                    ",
            "     +--------+     ",
            "  X--+        +--+  ",
            "                 |  ",
            "                 X  ",
            "                    "
        });
        Preloaded.ShowGrid(grid);
        Assert.AreEqual(true, Dinglemouse.Line(grid));
    }

    [Test]
    public void ExGood4()
    {
        var grid = Preloaded.MakeGrid(new[]
        {
            "                     ",
            "    +-------------+  ",
            "    |             |  ",
            " X--+      X------+  ",
            "                     "
        });
        Preloaded.ShowGrid(grid);
        Assert.AreEqual(true, Dinglemouse.Line(grid));
    }

    [Test]
    public void ExGood5()
    {
        var grid = Preloaded.MakeGrid(new[]
        {
            "                      ",
            "   +-------+          ",
            "   |      +++---+     ",
            "X--+      +-+   X      "
        });
        Preloaded.ShowGrid(grid);
        Assert.AreEqual(true, Dinglemouse.Line(grid));
    }

    // "Bad" examples from the Kata description.

    [Test]
    public void ExBad1()
    {
        var grid = Preloaded.MakeGrid(new[] 
        {
            "X-----|----X"
        });
        Preloaded.ShowGrid(grid);
        Assert.AreEqual(false, Dinglemouse.Line(grid));
    }

    [Test]
    public void ExBad2()
    {
        var grid = Preloaded.MakeGrid(new[]
        {
            " X  ",
            " |  ",
            " +  ",
            " X  "
        });
        Preloaded.ShowGrid(grid);
        Assert.AreEqual(false, Dinglemouse.Line(grid));
    }

    [Test]
    public void ExBad3()
    {
        var grid = Preloaded.MakeGrid(new[] 
        {
            "   |--------+    ",
            "X---        ---+ ",
            "               | ",
            "               X "
        });
        Preloaded.ShowGrid(grid);
        Assert.AreEqual(false, Dinglemouse.Line(grid));
    }

    [Test]
    public void ExBad4()
    {
        var grid = Preloaded.MakeGrid(new[] 
        {
            "              ",
            "   +------    ",
            "   |          ",
            "X--+      X   ",
            "              "
        });
        Preloaded.ShowGrid(grid);
        Assert.AreEqual(false, Dinglemouse.Line(grid));
    }

    [Test]
    public void ExBad5()
    {
        var grid = Preloaded.MakeGrid(new[] 
        {
            "      +------+",
            "      |      |",
            "X-----+------+",
            "      |       ",
            "      X       ",
        });
        Preloaded.ShowGrid(grid);
        Assert.AreEqual(false, Dinglemouse.Line(grid));
    }
}