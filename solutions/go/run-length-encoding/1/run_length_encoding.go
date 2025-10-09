package encode

import (
	"fmt"
	"strings"
	"unicode"
)

type Letter struct {
	letter      string
	occurrences int
}

func RunLengthEncode(input string) string {
	letters := make([]Letter, 0)
	for _, r := range input {
		if unicode.IsLetter(r) || unicode.IsSpace(r) {
			addLetter(&letters, string(r))
		}
	}
	res := encodeString(letters)
	return res
}

func RunLengthDecode(input string) string {
	var sb strings.Builder
	occurrences := 0
	for _, r := range input {
		if unicode.IsDigit(r) {
			occurrences = occurrences*10 + int(r-'0')
		} else {
			if occurrences == 0 {
				occurrences = 1
			}
			for i := 0; i < occurrences; i++ {
				sb.WriteString(string(r))
			}
			occurrences = 0
		}
	}
	return sb.String()
}

func addLetter(letters *[]Letter, l string) {
	if len(*letters) == 0 {
		*letters = append(*letters, Letter{letter: l, occurrences: 1})
		return
	}

	last := (*letters)[len(*letters)-1]
	if last.letter == l {
		(*letters)[len(*letters)-1].occurrences++
	}
	if last.letter != l {
		*letters = append(*letters, Letter{letter: l, occurrences: 1})
	}
}

func encodeString(letters []Letter) string {
	var sb strings.Builder
	for _, l := range letters {
		switch l.occurrences {
		case 1:
			sb.WriteString(l.letter)
		default:
			sb.WriteString(fmt.Sprintf("%d%s", l.occurrences, l.letter))
		}
	}
	return sb.String()
}
