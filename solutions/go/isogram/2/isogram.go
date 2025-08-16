package isogram

import (
    "strings"
    "unicode"
)

func IsIsogram(word string) bool {
	word = strings.ToUpper(word)
    for i, l := range word {
        if unicode.IsLetter(l) && strings.ContainsRune(word[i+1:], l) {
            return false
        }
    }
    return true
}
