package piglatin

import (
	"slices"
	"strings"
)

var vowels = []rune{'a', 'e', 'i', 'o', 'u'}

func Sentence(s string) string {
	splitFn := func(c rune) bool {
		return c == ' '
	}
	words := strings.FieldsFunc(s, splitFn)
	var sb strings.Builder
	for i, w := range words {
		sb.WriteString(Latinize(w))
		if i < len(words)-1 {
			sb.WriteRune(' ')
		}
	}
	return sb.String()
}

func Latinize(s string) string {
	if sr1, okr1 := rule1(s); okr1 {
		return sr1
	}

	if sr2, okr2 := rule2(s); okr2 {
		return sr2
	}

	if sr3, okr3 := rule3(s); okr3 {
		return sr3
	}

	if sr4, okr4 := rule4(s); okr4 {
		return sr4
	}

	return s
}

func rule1(s string) (string, bool) {
	if startWithVowel(s) || startWithXrOrYT(s) {
		return s + "ay", true
	}
	return s, false
}

func rule2(s string) (string, bool) {
	if !startWithVowel(s) && !startWithXrOrYT(s) && !containsQU(s) {
		fv := 0
		for i, v := range s {
			if slices.Contains(vowels, v) {
				fv = i
				break
			}
		}

		if fv > 0 {
			return s[fv:] + s[0:fv] + "ay", true
		}
	}
	return s, false
}

func rule3(s string) (string, bool) {
	qu := strings.Index(s, "qu")
	if qu > -1 {
		return s[qu+2:] + s[0:qu+2] + "ay", true
	}
	return s, false
}

func rule4(s string) (string, bool) {
	y := strings.Index(s, "y")
	if y > -1 {
		return s[y:] + s[0:y] + "ay", true
	}
	return s, false
}

func startWithVowel(s string) bool {
	return slices.Contains(vowels, rune(s[0]))
}

func startWithXrOrYT(s string) bool {
	var prefixs = []string{"xr", "yt"}
	return len(s) >= 2 && slices.Contains(prefixs, s[:2])
}

func containsQU(s string) bool {
	return strings.Contains(s, "qu")
}
