package anagram

import "strings"

func TotalRune(subject string, r rune) int {
	total := 0
	for _, v := range subject {
		if v == r {
			total++
		}
	}
	return total
}

func Detect(subject string, candidates []string) []string {
	var anagrams []string
	subject = strings.ToLower(subject)
	for i := 0; i < len(candidates); i++ {
		lower := strings.ToLower(candidates[i])
		if len(subject) != len(candidates[i]) || subject == lower {
			continue
		}
		mustAdd := true
		for _, r := range subject {
			if TotalRune(lower, r) != TotalRune(subject, r) {
				mustAdd = false
				break
			}
		}
		if mustAdd {
			anagrams = append(anagrams, candidates[i])
		}
	}
	return anagrams
}
