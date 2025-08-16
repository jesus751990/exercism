package collatzconjecture

import "errors"

func CollatzConjecture(n int) (int, error) {
	if n < 1 {
        return 0, errors.New("n must be >= 1")
    }
    
    var i int
    for {
        if n == 1 {
            break
        }
        i++
        switch {
    	case n % 2 == 0:
            n = n / 2
		default:
            n = 3 * n + 1
        }
    }
    return i, nil
}
