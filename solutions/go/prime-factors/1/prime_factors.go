package prime

func Factors(n int64) []int64 {
	factors := make([]int64, 0)
	var i int64 = 2
	if n < i {
		return factors
	}
	var total int64 = 1
	var factor int64 = n
	for {
		if factor%i == 0 {
			factors = append(factors, i)
			factor /= i
			total *= i
			if total == n {
				break
			}
		} else {
			i++
		}
	}
	return factors
}
