package hamming

import "errors"

func Distance(a, b string) (int, error) {
    var distance int
    if len(a) != len(b) {
        return distance, errors.New("inputs must have same length")
    }    
	for i, _ := range a {
        if a[i] != b[i] {
            distance++
        }
    }    
    return distance, nil
}
