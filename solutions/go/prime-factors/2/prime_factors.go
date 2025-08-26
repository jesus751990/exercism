package prime

func Factors(n int64) []int64 {
	factors := make([]int64, 0)
	var i int64 = 2
	for n > 1 {
		for n%i == 0 {
			factors = append(factors, i)
			n /= i
		}
		i++
	}
	return factors
}
