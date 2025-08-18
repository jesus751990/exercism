package rotationalcipher

import "unicode"

func RotationalCipher(plain string, shiftKey int) string {
    runes := make([]rune, len(plain))
    for i, r := range plain {
        rcode := int(r)
        if unicode.IsLetter(r) {
            base := 0
            switch {
            case 'a' <= r && r <= 'z':
                base = int('a')
			case 'A' <= r && r <= 'Z':
                base = int('A')
            }
            rcode = ((int(r) - base + shiftKey) % 26) + base
        } 
        runes[i] = rune(rcode)
    }
    return string(runes)
}
