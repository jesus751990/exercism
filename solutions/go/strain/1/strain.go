package strain

func Keep[T any](s []T, f func(T) bool) []T {
	var out []T
	for _, v := range s {
		if f(v) {
			out = append(out, v)
		}
	}
	return out
}

func Discard[T any](s []T, f func(T) bool) []T {
	var out []T
	for _, v := range s {
		if !f(v) {
			out = append(out, v)
		}
	}
	return out
}
