package wordcount

import (
	"strings"
	"unicode"
)

type Frequency map[string]int

func IsApostrophe(phrase string, index int) bool {
	if rune(phrase[index]) != '\'' || index == 0 || len(phrase) < 3 || index+1 >= len(phrase) {
		return false
	} else {
		previous := rune(phrase[index-1])
		next := rune(phrase[index+1])
		return unicode.IsLetter(previous) && unicode.IsLetter(next)
	}
}

func WordCount(phrase string) Frequency {
	separators := ".:,;!?"
	var res Frequency = make(map[string]int)
	var chars []rune
	var word string
	phrase = strings.ToLower(phrase)
	for i, r := range phrase {
		if unicode.IsLetter(r) || unicode.IsDigit(r) || IsApostrophe(phrase, i) {
			chars = append(chars, r)
		} else if (unicode.IsSpace(r) || strings.ContainsRune(separators, r)) && len(chars) > 0 {
			word = string(chars)
			_, exist := res[word]
			if exist {
				res[word]++
			} else {
				res[word] = 1
			}
			chars = []rune{}
		}
	}
	if len(chars) > 0 {
		word = string(chars)
		_, exist := res[word]
		if exist {
			res[word]++
		} else {
			res[word] = 1
		}
	}
	return res
}
