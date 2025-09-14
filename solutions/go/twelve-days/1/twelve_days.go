package twelve

import (
	"fmt"
)

func Song() string {
	song := ""
	for i := 1; i <= 12; i++ {
		song += Verse(i)
		if i < 12 {
			song += "\n"
		}
	}
	return song
}

func Verse(i int) string {
	day := Day(i)
	present := Present(i)
	verse := fmt.Sprintf("On the %s day of Christmas my true love gave to me:%s", day, present)
	for j := i - 1; j > 0; j-- {
		present = Present(j)
		if j == 1 {
			present = fmt.Sprintf(" and%s", present)
		}
		verse += present
	}
	return verse
}

func Day(i int) string {
	switch i {
	case 1:
		return "first"
	case 2:
		return "second"
	case 3:
		return "third"
	case 4:
		return "fourth"
	case 5:
		return "fifth"
	case 6:
		return "sixth"
	case 7:
		return "seventh"
	case 8:
		return "eighth"
	case 9:
		return "ninth"
	case 10:
		return "tenth"
	case 11:
		return "eleventh"
	case 12:
		return "twelfth"
	default:
		return ""
	}
}

func Present(i int) string {
	switch i {
	case 1:
		return " a Partridge in a Pear Tree."
	case 2:
		return " two Turtle Doves,"
	case 3:
		return " three French Hens,"
	case 4:
		return " four Calling Birds,"
	case 5:
		return " five Gold Rings,"
	case 6:
		return " six Geese-a-Laying,"
	case 7:
		return " seven Swans-a-Swimming,"
	case 8:
		return " eight Maids-a-Milking,"
	case 9:
		return " nine Ladies Dancing,"
	case 10:
		return " ten Lords-a-Leaping,"
	case 11:
		return " eleven Pipers Piping,"
	case 12:
		return " twelve Drummers Drumming,"
	default:
		return ""
	}
}
