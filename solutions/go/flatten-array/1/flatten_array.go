package flatten

func Flatten(nested any) []any {
	out := make([]any, 0)
	switch nested := nested.(type) {
	case []any:
		for _, v := range nested {
			out = append(out, Flatten(v)...)
		}
	case any:
		out = append(out, nested)
	}
	return out
}
