package resistorcolorduo

func GetResistors() map[string]int{
    return map[string]int{
        "black": 0,
        "brown": 1,
        "red": 2,
        "orange": 3,
        "yellow": 4,
        "green": 5,
        "blue": 6,
        "violet": 7,
        "grey": 8,
        "white": 9,
    }
}

// Value should return the resistance value of a resistor with a given colors.
func Value(colors []string) int {
	resistors := GetResistors()
	result := 0
    bands := 0

    for _, color := range colors {
        resistence, exist := resistors[color]
        if exist && bands < 2 {
            result = (result * 10) + resistence
            bands++
        }
    }
    
    return result
}
