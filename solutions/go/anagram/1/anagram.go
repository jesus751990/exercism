package anagram

import "strings"

func Detect(subject string, candidates []string) []string {
	var anagrams []string
	subject = strings.ToLower(subject)
	for i := 0; i < len(candidates); i++ {
		if len(subject) != len(candidates[i]) {
			break
		}
		lower := strings.ToLower(candidates[i])
		mustAdd := true
		for _, r := range subject {
			if !strings.ContainsRune(lower, r) {
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
