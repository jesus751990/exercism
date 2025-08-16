// Package weather provides tools for get the wheather condtion.
package weather

// CurrentCondition represent the wheather condition.
var CurrentCondition string
// CurrentLocation represent the location.
var CurrentLocation string

// Forecast return an string value with the current location and the wheather condition.
func Forecast(city, condition string) string {
	CurrentLocation, CurrentCondition = city, condition
	return CurrentLocation + " - current weather condition: " + CurrentCondition
}
