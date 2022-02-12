using System;
using System.Linq;
using System.Threading;
public static class ScaleGenerator
{
    private static readonly string[] Sharps = new[]
        {"C", "C#", "D", "D#", "E", "F", "F#", "G", "G#", "A", "A#", "B"};
    private static readonly string[] Flats = new[]
        {"F", "Gb", "G", "Ab", "A", "Bb", "B", "C", "Db", "D", "Eb", "E"};
    private static readonly string[] SharpKeys = new[]
        {"C", "G", "D", "A", "E", "B", "F#", "a", "e", "b", "f#", "c#", "g#", "d#"};

    public static string[] Chromatic(string tonic)
    {
        var a = new string[12];
        var current = ToTitleCase(tonic);
        var isSharp = IsSharpKey(tonic);
        for (var i = 0; i < 12; i++)
        {
            a[i] = current;
            current = Steps(current, 1, isSharp);
        }

        return a;
    }

    private static string Steps(string note, int steps, bool sharps)
    {
        var a = sharps ? Sharps : Flats;
        var next = (Array.IndexOf(a, note) + steps) % a.Length;
        return a[next];
    }

    public static string[] Interval(string tonic, string pattern)
    {
        var a = new string[pattern.Length];
        var current = ToTitleCase(tonic);
        var isSharp = IsSharpKey(tonic);
        for (var i = 0; i < pattern.Length; i++)
        {
            a[i] = current;
            var steps = pattern[i] switch
            {
                'm' => 1,
                'M' => 2,
                'A' => 3,
                _ => throw new ArgumentOutOfRangeException(pattern[i].ToString()),
            };
            current = Steps(current, steps, isSharp);
        }

        return a;
    }

    private static string ToTitleCase(string s) => Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s);
    private static bool IsSharpKey(string tonic) => SharpKeys.Contains(tonic);
}