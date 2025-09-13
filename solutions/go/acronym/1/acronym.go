// Package acronym get the acronym given a string
package acronym

import ("unicode"
        "strings")

// Abbreviate get the acronym 
func Abbreviate(s string) string {
    var sb strings.Builder
	for i, r := range s {
        if unicode.IsLetter(r) {
            if i == 0 || IsSeparator(rune(s[i-1])){
                sb.WriteRune(unicode.ToUpper(r))
            }
        }
    }

    return sb.String()
}

func IsSeparator(r rune) bool {
    switch r {
        case '-':
        return true
        case ' ':
        return true
        case '_':
        return true
        default:
        return false
    }
}
