package secret

import "slices"

func Handshake(code uint) []string {
	var result []string
	for i := range actions {
		if code&(1<<i) != 0 {
			result = append(result, actions[i])
		}
	}
	if code&16 != 0 {
		slices.Reverse(result)
	}
	return result
}

var actions = []string{
	"wink",
	"double blink",
	"close your eyes",
	"jump",
}
