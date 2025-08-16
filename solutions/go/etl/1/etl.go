package etl

import (
    "strings"
    "slices"
)

func Transform(in map[int][]string) map[string]int {
    result := make(map[string]int, 26)
    runeString := ""
    for r := 'a'; r <= 'z'; r++ {
        runeString = string(r)
        for points, letters := range in {
            if slices.Contains(letters, strings.ToUpper(runeString)) {
                result[runeString] = points
                break
            }
        }
    }
    return result
}
