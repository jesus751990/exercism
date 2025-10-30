package pythagorean

import "math"

type Triplet [3]int

// Range generates list of all Pythagorean triplets with side lengths
// in the provided range.
func Range(min, max int) (result []Triplet) {
	for a := min; a <= max-2; a++ {
		for b := a + 1; b <= max-1; b++ {
			c := math.Sqrt(math.Pow(float64(a), 2) + math.Pow(float64(b), 2))
			if c == math.Trunc(c) && c <= float64(max) && float64(b) < c {
				result = append(result, Triplet{a, b, int(c)})
			}
		}
	}
	return result
}

// Sum returns a list of all Pythagorean triplets with a certain perimeter.
func Sum(p int) (result []Triplet) {
	candidates := Range(0, p)
	for _, candidate := range candidates {
		if candidate[0]+candidate[1]+candidate[2] == p {
			result = append(result, candidate)
		}
	}
	return result
}
