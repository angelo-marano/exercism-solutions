// Package weather should have a comment.
package weather

// CurrentCondition is the current weather condition.
var CurrentCondition string

// CurrentLocation is the current location for the forecast.
var CurrentLocation string

// Forecast takes a city and a condition and returns a forecast.
func Forecast(city, condition string) string {

	CurrentLocation, CurrentCondition = city, condition
	return CurrentLocation + " - current weather condition: " + CurrentCondition
}
