using System;

namespace LineSafariTests;

public static class Preloaded
{
    public static char[][] MakeGrid(string[] strings)
    {
        char[][] result = new char[strings.Length][];
        
        for (int rowIndex = 0; rowIndex < strings.Length; rowIndex++)
        {
            result[rowIndex] = strings[rowIndex].ToCharArray();
        }

        return result;
    }

    public static void ShowGrid(char[][] grid)
    {
        foreach (var row in grid)
        {
            foreach (var symbol in row)
            {
                Console.Write(symbol);
            }

            Console.Write(Environment.NewLine);
        }
    }
}