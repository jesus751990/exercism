package scrabble

import "strings"

type TScrabble struct {
    Value int
    Letters string
}

func Score(word string) int {
     scrabbleValues := []TScrabble{
        { Value: 1, Letters: "AEIOULNRST"},
        { Value: 2, Letters: "DG"},
        { Value: 3, Letters: "BCMP"},
        { Value: 4, Letters: "FHVWY"},
        { Value: 5, Letters: "K"},
        { Value: 8, Letters: "JX"},
        { Value: 10, Letters: "QZ"},
    }   
    
	var score int
    for _, letter := range word {
        for _, sv := range scrabbleValues {
            if strings.Contains(sv.Letters, strings.ToUpper(string(letter))) {
                score += sv.Value
            }
        }
    }
    return score
}
