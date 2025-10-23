package yacht

import "slices"

var categories = []string{
	"yacht",
	"ones",
	"twos",
	"threes",
	"fours",
	"fives",
	"sixes",
	"full house",
	"four of a kind",
	"little straight",
	"big straight",
	"choice",
}

func Score(dice []int, category string) int {
	if len(dice) != 5 || slices.Index(categories, category) == -1 {
		return 0
	}

	switch category {
	case "yacht":
		if IsYacht(dice) {
			return 50
		}
		return 0
	case "ones":
		return NPerNumberOfN(dice, 1)
	case "twos":
		return NPerNumberOfN(dice, 2)
	case "threes":
		return NPerNumberOfN(dice, 3)
	case "fours":
		return NPerNumberOfN(dice, 4)
	case "fives":
		return NPerNumberOfN(dice, 5)
	case "sixes":
		return NPerNumberOfN(dice, 6)
	case "full house":
		if IsFullHouse(dice) {
			return TotalOfTheDice(dice)
		}
		return 0
	case "four of a kind":
		if num, ok := IsFourOfAKind(dice); ok {
			return num * 4
		}
		return 0
	case "little straight":
		if IsLittleStraight(dice) {
			return 30
		}
		return 0
	case "big straight":
		if IsBigStraight(dice) {
			return 30
		}
		return 0
	case "choice":
		return TotalOfTheDice(dice)
	default:
		return 0
	}
}

func NPerNumberOfN(dice []int, n int) int {
	total := 0
	for _, die := range dice {
		if die == n {
			total += 1
		}
	}
	return total * n
}

func IsFullHouse(dice []int) bool {
	counts := make(map[int]int)
	for _, die := range dice {
		counts[die]++
	}
	if len(counts) != 2 {
		return false
	}
	hasThree := false
	hasTwo := false
	for _, count := range counts {
		switch count {
		case 3:
			hasThree = true
		case 2:
			hasTwo = true
		}
	}
	return hasThree && hasTwo
}

func IsFourOfAKind(dice []int) (int, bool) {
	counts := make(map[int]int)
	for _, die := range dice {
		counts[die]++
	}
	for num, count := range counts {
		if count >= 4 {
			return num, true
		}
	}
	return 0, false
}

func IsLittleStraight(dice []int) bool {
	expected := map[int]bool{1: false, 2: false, 3: false, 4: false, 5: false}
	for _, die := range dice {
		expected[die] = true
	}
	for _, found := range expected {
		if !found {
			return false
		}
	}
	return true
}

func IsBigStraight(dice []int) bool {
	expected := map[int]bool{2: false, 3: false, 4: false, 5: false, 6: false}
	for _, die := range dice {
		expected[die] = true
	}
	for _, found := range expected {
		if !found {
			return false
		}
	}
	return true
}

func IsYacht(dice []int) bool {
	first := dice[0]
	for _, die := range dice {
		if die != first {
			return false
		}
	}
	return true
}

func TotalOfTheDice(dice []int) int {
	total := 0
	for _, die := range dice {
		total += die
	}
	return total
}
