// This is a "stub" file.  It's a little start on your solution.
// It's not a complete solution though; you have to write some code.

// Package leap works with years in the Gregorian calendar
package leap

// IsLeapYear return is a year is a leap year
func IsLeapYear(year int) bool {
	return year % 4 == 0 && year % 100 > 0 || year % 100 == 0 && year % 400 == 0
}
