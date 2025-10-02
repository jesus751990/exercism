package resistorcolortrio

import (
	"fmt"
	"math"
)

func ColorsResistors() map[string]int {
	return map[string]int{
		"black":  0,
		"brown":  1,
		"red":    2,
		"orange": 3,
		"yellow": 4,
		"green":  5,
		"blue":   6,
		"violet": 7,
		"grey":   8,
		"white":  9,
	}
}

func Prefix(value int) (int, string) {
	var pows = []int{int(math.Pow10(3)), int(math.Pow10(6)), int(math.Pow10(9)), int(math.Pow10(12))}
	switch {
	case pows[0] <= value && value < pows[1]:
		return value / pows[0], "kilo"
	case pows[1] <= value && value < pows[2]:
		return value / pows[1], "mega"
	case pows[2] <= value && value < pows[3]:
		return value / pows[2], "giga"
	case pows[3] <= value:
		return value / pows[3], "tera"
	default:
		return value, ""
	}
}

func Label(colors []string) string {
	resistors := ColorsResistors()
	value := resistors[colors[0]]*10 + resistors[colors[1]]
	pow := int(math.Pow10(resistors[colors[2]]))
	round, prefix := Prefix(value * pow)
	return fmt.Sprintf("%d %sohms", round, prefix)
}
