package lsproduct

import (
	"errors"
	"regexp"
)

func LargestSeriesProduct(digits string, span int) (int64, error) {
	re := regexp.MustCompile(`^\d+$`)
	if span > len(digits) || span < 0 || !re.MatchString(digits) {
		return 0, errors.New("digits can only contain numbers, span must be lower than digits and greather than zero")
	}
	product := int64(1)
	max := int64(0)
	for i := 0; i <= len(digits)-span; i++ {
		product = int64(1)
		for _, r := range digits[i : i+span] {
			product *= int64(r - '0')
		}
		if max < product {
			max = product
		}
	}
	return max, nil
}
