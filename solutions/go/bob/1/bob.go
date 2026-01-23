// Bob is a lackadaisical teenager. He likes to think that he's very cool. And he definitely doesn't get excited about things. That wouldn't be cool.
package bob

import "unicode"

func IsSilence (runes []rune) bool {    
    return len(runes) == 0
}

func IsQuestion(runes []rune) bool {
    lenr := len(runes)
    return lenr > 0 && runes[lenr-1] == '?'
}

func AllCapital(runes []rune) bool {
    allCapital := false
    for _, r := range runes {
        if unicode.IsLetter(r) {
            allCapital = unicode.ToUpper(r) == r
            if !allCapital {
                break;
            }
        }
    }
    return allCapital
}

// Hey should return the distinct answers
func Hey(remark string) string {
    var runes []rune
    for _, r := range remark {
        if !unicode.IsSpace(r) {
            runes = append(runes, r)
        }
    }
    
    isSilence := IsSilence(runes)
    isQuestion := IsQuestion(runes)
    allCapital := AllCapital(runes)

    switch {
    case isSilence:
        return "Fine. Be that way!"
    case allCapital == false && isQuestion == true:
        return "Sure."
    case allCapital == true && isQuestion == false:
        return "Whoa, chill out!"
    case allCapital == true && isQuestion == true:
        return "Calm down, I know what I'm doing!"
    default:
        return "Whatever." 
    }
}
