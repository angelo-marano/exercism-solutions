using System;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException(nameof(firstStrand));
        }
        var a = firstStrand.ToCharArray();
        var b = secondStrand.ToCharArray();
        var counter = 0;
        for (var i = 0; i < a.Length; i++)
        {
            if (a[i] != b[i])
            {
                counter++;  
            }
        }
        return counter;   
    }
}