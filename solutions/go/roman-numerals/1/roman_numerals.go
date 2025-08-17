package romannumerals

import (
	"errors"
	"strings"
)

// ToRomanNumeral converts an Arabic numeral to Roman numeral
func ToRomanNumeral(number int) (string, error) {
	if number <= 0 || number > 3999 {
		return "", errors.New("number out of range: must be between 1 and 3999")
	}
	
    values := []int{1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1}
	numerals := []string{"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"}
	var result strings.Builder
	for i := 0; i < len(values); i++ {
		for number >= values[i] {
			result.WriteString(numerals[i])
			number -= values[i]
		}
	}
	return result.String(), nil
}