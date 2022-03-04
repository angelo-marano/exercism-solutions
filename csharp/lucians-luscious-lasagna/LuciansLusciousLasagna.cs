class Lasagna
{
	public int ExpectedMinutesInOven() => 40;
	public int RemainingMinutesInOven(int minutesInOven) => 40 - minutesInOven;
	public int PreparationTimeInMinutes(int layers) => layers * 2;
	public int ElapsedTimeInMinutes(int layers, int timeInOven) => PreparationTimeInMinutes(layers) + timeInOven;
}
