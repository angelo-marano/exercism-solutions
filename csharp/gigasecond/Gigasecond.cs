using System;

public static class Gigasecond
{
    public static DateTime Add(DateTime moment)
    {
        return moment.Add(TimeSpan.FromSeconds(1000000000));
    }
}