package armstrong

import "math"

func IsNumber(n int) bool {
	exponent := GetDigits(n)
	result := 0
	value := n
	for value > 0 {
		result += int(math.Pow(float64(value%10), float64(exponent)))
		value /= 10
	}
	return result == n
}

func GetDigits(n int) int {
	return int(math.Log10(float64(n))) + 1
}
