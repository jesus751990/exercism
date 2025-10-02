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
	var multipliers = []int{int(math.Pow10(3)), int(math.Pow10(6)), int(math.Pow10(9)), int(math.Pow10(12))}
	switch {
	case multipliers[0] <= value && value < multipliers[1]:
		return value / multipliers[0], "kilo"
	case multipliers[1] <= value && value < multipliers[2]:
		return value / multipliers[1], "mega"
	case multipliers[2] <= value && value < multipliers[3]:
		return value / multipliers[2], "giga"
	case multipliers[3] <= value:
		return value / multipliers[3], "tera"
	default:
		return value, ""
	}
}

func Label(colors []string) string {
	resistors := ColorsResistors()
	value := resistors[colors[0]]*10 + resistors[colors[1]]
	multiplier := int(math.Pow10(resistors[colors[2]]))
	adjusted, prefix := Prefix(value * multiplier)
	return fmt.Sprintf("%d %sohms", adjusted, prefix)
}
