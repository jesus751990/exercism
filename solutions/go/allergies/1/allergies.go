package allergies

import "fmt"

var allergens = map[string]uint{
	"eggs":         1,
	"peanuts":      2,
	"shellfish":    4,
	"strawberries": 8,
	"tomatoes":     16,
	"chocolate":    32,
	"pollen":       64,
	"cats":         128,
}

func Allergies(allergies uint) []string {
	var result []string
	for allergen, score := range allergens {
		if score&allergies != 0 {
			result = append(result, allergen)
		}
	}
	return result
}

func AllergicTo(allergies uint, allergen string) bool {
	score, found := allergens[allergen]
	if !found {
		return false
	}
	i := 10
	j := 20
	fmt.Println(i&j != 0)
	fmt.Println(j&i != 0)
	return score&allergies != 0
}
