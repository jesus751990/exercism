package perfect

import "errors"

type Classification int

const (
	ClassificationPerfect Classification = iota
	ClassificationAbundant
	ClassificationDeficient
)

var ErrOnlyPositive = errors.New("must be > 0")

func Classify(n int64) (Classification, error) {
	if n <= 0 {
		return ClassificationAbundant, ErrOnlyPositive
	}
	aliquotSum := aliquotSum(n)
	switch {
	case aliquotSum == n:
		return ClassificationPerfect, nil
	case aliquotSum > n:
		return ClassificationAbundant, nil
	default:
		return ClassificationDeficient, nil
	}
}

func aliquotSum(n int64) int64 {
	factors := getFactors(n)
	res := int64(0)
	for _, f := range factors[:len(factors)-1] {
		res += f
	}
	return res
}

func getFactors(n int64) []int64 {
	res := make([]int64, 0)
	for i := int64(1); i <= n; i++ {
		if n%i == 0 {
			res = append(res, i)
		}
	}
	return res
}
