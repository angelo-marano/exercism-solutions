using System;
using System.Linq;

public static class ResistorColor
{
    private static string[] colors = new []
    {
        "black",
        "brown",
        "red",
        "orange",
        "yellow",
        "green",
        "blue",
        "violet",
        "grey",
        "white"
    };
    public static int ColorCode(string color)
    {
        for (var i = 0; i < colors.Length; i++)
        {
            if (colors[i] == color)
            {
                return i;
            }
        }

        throw new Exception($"{color} ain't right man.");
    }

    public static string[] Colors()
    {
        return colors;
    }
}