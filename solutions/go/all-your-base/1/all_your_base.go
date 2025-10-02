package allyourbase

import (
	"errors"
	"math"
	"slices"
)

func ConvertToBase(inputBase int, inputDigits []int, outputBase int) ([]int, error) {
	res := make([]int, 0)
	err := Validate(inputBase, inputDigits, outputBase)
	if err != nil {
		return res, err
	}
	pos := len(inputDigits) - 1
	dec := 0
	for _, d := range inputDigits {
		dec += d * int(math.Pow(float64(inputBase), float64(pos)))
		pos--
	}
	mod := int(math.Mod(float64(dec), float64(outputBase)))
	div := dec / outputBase
	res = append(res, mod)
	for div > 0 {
		mod = int(math.Mod(float64(div), float64(outputBase)))
		div = div / outputBase
		res = append(res, mod)
	}
	slices.Reverse(res)
	return res, nil
}

func Validate(inputBase int, inputDigits []int, outputBase int) error {
	if inputBase < 2 {
		return errors.New("input base must be >= 2")
	}
	if outputBase < 2 {
		return errors.New("output base must be >= 2")
	}
	for _, d := range inputDigits {
		if d < 0 || d >= inputBase {
			return errors.New("all digits must satisfy 0 <= d < input base")
		}
	}
	return nil
}
