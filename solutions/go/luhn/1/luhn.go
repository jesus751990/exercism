package luhn

import (
    "unicode"
    "strings"
)

func Reverse(input string) string {
    var result string
    for _, c := range input {
        result = string(c) + result
    }
    return result
}

func Valid(id string) bool {
    if len(id) <= 1 {
        return false
    }
    
    withoutSpaces := strings.Replace(id, " ", "", -1)
    if withoutSpaces == "0"{
        return false
    }

    reverse := Reverse(withoutSpaces)    
    var sum int
    for i, r := range reverse {            
        if unicode.IsNumber(r) {
            value := int(r - '0')
            if i % 2 > 0 {
                value *= 2
                if value > 9 {
                    value -= 9
                }
            }
            sum += value
        } else {
            return false
        }
    }

    return sum % 10 == 0
}