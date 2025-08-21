package atbash

import (
    "strings"
    "unicode"
)

func GetIndex(r rune, runes []rune) int {
    for i:=0;i<len(runes);i++{
        if runes[i] == r {
            return i
        }
    }
    return -1
}

func Atbash(s string) string {
	plain := "abcdefghijklmnopqrstuvwxyz"
    plainrs := make([]rune, 26)
    for i, r := range plain {
        plainrs[i] = r
    }
    cipher := "zyxwvutsrqponmlkjihgfedcba"
    cipherrs := make([]rune, 26)
    for i, r := range cipher {
        cipherrs[i] = r
    }
    s = strings.ToLower(s)
    totalInGroups := 0
    var builder strings.Builder
    for _, r := range s {
        if index := GetIndex(r, plainrs); index > -1 || unicode.IsDigit(r) {
            if index > -1 {
        		builder.WriteRune(cipherrs[index])                
            } else {
                builder.WriteRune(r)
            }
            totalInGroups++
            if totalInGroups == 5 {
                totalInGroups = 0
                builder.WriteRune(' ')
            } 
        }
    }
    atbash := builder.String()
    return strings.TrimSpace(atbash)
}
