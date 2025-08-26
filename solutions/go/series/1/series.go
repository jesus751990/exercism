package series

func All(n int, s string) []string {
	series := make([]string, 0)
	if len(s) < n {
		return series
	}
	for i := 0; i < len(s); i++ {
		end := i + n
		if end > len(s) {
			break
		}
		series = append(series, s[i:end])
	}
	return series
}

func UnsafeFirst(n int, s string) string {
	return s[0:n]
}
