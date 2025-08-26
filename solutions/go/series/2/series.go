package series

func All(n int, s string) []string {
	series := []string{}
	for i := 0; i <= len(s)-n; i++ {
		series = append(series, s[i:i+n])
	}
	return series
}
func UnsafeFirst(n int, s string) string {
	return s[:n]
}
