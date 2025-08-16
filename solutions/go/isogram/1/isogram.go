package isogram

import "strings"

func IsIsogram(word string) bool {
	isogram := true
    word = strings.ToUpper(word)
    for i, l := range word {
        if i+1 < len(word) && l != '-' && l != ' ' && strings.Contains(word[i+1:], string(l)) {
            isogram = false
            break;
        }
    }
    return isogram
}
