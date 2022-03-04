using System;
using System.Collections.Generic;

public class SpaceAge
{
    private const double EarthYearInSeconds = 31557600;
    private readonly int _seconds;

    public SpaceAge(int seconds)
    {
        _seconds = seconds;
    }

    public double OnEarth()
    {
        double result = _seconds / EarthYearInSeconds;
        return result;
    }

    public double OnMercury()
    {
        return this.OnEarth() / 0.2408467;
    }

    public double OnVenus()
    {
        return this.OnEarth() / 0.61519726;
    }

    public double OnMars()
    {
        return this.OnEarth() / 1.8808158;
    }

    public double OnJupiter()
    {
        return this.OnEarth() / 11.862615;
    }

    public double OnSaturn()
    {
        return this.OnEarth() / 29.447498;
    }

    public double OnUranus()
    {
        return this.OnEarth() / 84.016846;
    }

    public double OnNeptune()
    {
        return this.OnEarth() / 164.79132;
    }
}