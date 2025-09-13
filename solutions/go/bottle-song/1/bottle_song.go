package bottlesong

import (
	"fmt"
	"strings"
)

func Recite(startBottles, takeDown int) []string {
	song := make([]string, 0)
	for takeDown > 0 {
		verse := GetVerse(startBottles)
		song = append(song, verse...)
		takeDown--
		startBottles--
		if takeDown > 0 {
			song = append(song, "")
		}
	}
	return song
}

func GetNumbers() map[int]string {
	numbers := map[int]string{
		1:  "One",
		2:  "Two",
		3:  "Three",
		4:  "Four",
		5:  "Five",
		6:  "Six",
		7:  "Seven",
		8:  "Eight",
		9:  "Nine",
		10: "Ten",
	}
	return numbers
}

func GetVerse(takeDown int) []string {
	current := GetNumbers()[takeDown]
	next := "no"
	bottle := "bottle"
	if takeDown > 1 {
		next = GetNumbers()[takeDown-1]
		bottle = "bottles"
	}
	firstAndSecondVerse := fmt.Sprintf("%s green %s hanging on the wall,", current, bottle)

	thirdVerse := "And if one green bottle should accidentally fall,"

	if takeDown == 1 {
		bottle = "bottles"
	} else if takeDown-1 == 1 {
		bottle = "bottle"
	}
	lastVerse := fmt.Sprintf("There'll be %s green %s hanging on the wall.", strings.ToLower(next), bottle)

	verse := []string{
		firstAndSecondVerse,
		firstAndSecondVerse,
		thirdVerse,
		lastVerse,
	}
	return verse
}
