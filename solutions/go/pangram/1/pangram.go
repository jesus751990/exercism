package pangram

import (
    "strings"
    "slices"
    "unicode"
)

func IsPangram(input string) bool {
    currents := make([]rune, 26)
    i := 0
    for _, r := range strings.ToLower(input) {
        if unicode.IsLetter(r) && slices.Contains(currents, r) == false {
            currents[i] = r
            i++
        }
    }

    if i < 26 {
        return false
    }
    
    return true    
}
