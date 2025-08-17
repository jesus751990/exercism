package isbn

import "unicode"

func IsValidISBN(isbn string) bool {
    value := 0
    multiplier := 10
    digits := 0
    for i, r := range isbn {
        if unicode.IsDigit(r) {
            value += (int(r - '0') * multiplier)
            if multiplier > 1 {
            	multiplier--                
            }
            digits++
        } else if r == 'X' {
            if i < (len(isbn) - 1) {
                return false
            }
            value += 10
            digits++
        } else if r != '-' {
            return false
        }
    }
    return digits == 10 && value % 11 == 0
}
