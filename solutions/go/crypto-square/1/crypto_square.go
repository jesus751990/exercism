package cryptosquare

import (
	"math"
	"strings"
	"unicode"
)

func Encode(pt string) string {
	runes := make([]rune, 0)
	for _, r := range strings.ToLower(pt) {
		if unicode.IsLetter(r) || unicode.IsDigit(r) {
			runes = append(runes, r)
		}
	}
	sqrt := int(math.Sqrt(float64(len(runes))))
	c := sqrt
	r := sqrt
	for c*r < len(runes) {
		if c == r {
			c++
		} else {
			r++
		}
	}

	square := make([][]rune, r)
	ri := 0
	var rv rune
	for i := 0; i < r; i++ {
		row := make([]rune, c)
		for j := 0; j < c; j++ {
			if ri >= len(runes) {
				rv = rune(' ')
			} else {
				rv = runes[ri]
			}
			row[j] = rv
			ri++
		}
		square[i] = row
	}

	var res strings.Builder
	for i := 0; i < c; i++ {
		for j := 0; j < r; j++ {
			res.WriteRune(square[j][i])
		}
		if i+1 < c {
			res.WriteRune(' ')
		}
	}
	return res.String()
}
