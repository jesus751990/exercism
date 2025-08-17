package rotationalcipher

import "unicode"

func RotationalCipher(plain string, shiftKey int) string {
    runes := make([]rune, len(plain))
    for i, r := range plain {
        rcode := int(r)
        if unicode.IsLetter(r) {
            rcode += shiftKey 
            switch {
            case 'a' <= r && r <= 'z':
                if (rcode) > int('z') {
                    rcode = rcode - int('z') - 1 + int('a')
                }
			case 'A' <= r && r <= 'Z':
                if (rcode) > int('Z') {
                    rcode = rcode - int('Z') - 1 + int('A')
                }
            }
        } 
        runes[i] = rune(rcode)
    }
    return string(runes)
}
