package summultiples

func SumMultiples(limit int, divisors ...int) int {
	res := 0
	mult := make([]int, 0)
	m := 0
	for _, d := range divisors {
		for i := 0; i < limit; i++ {
			m = d * i
			if m < limit && !Includes(mult, m) {
				res += m
				mult = append(mult, m)
			}
		}
	}
	return res
}

func Includes(values []int, input int) bool {
	for _, v := range values {
		if input == v {
			return true
		}
	}
	return false
}
