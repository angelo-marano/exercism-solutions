using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var dict = new Dictionary<char, int>
        {
            {'A', 0},
            {'C', 0},
            {'T', 0},
            {'G', 0}
        };

        foreach (var c in sequence)
        {
            if (dict.ContainsKey(c))
            {
                dict[c]++;
            }
            else
            {
                throw new ArgumentException(nameof(sequence));
            }

        }

        return dict;
    }
}