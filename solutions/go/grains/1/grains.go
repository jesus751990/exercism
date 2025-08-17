package grains

import "errors"

func Square(number int) (uint64, error) {
    if number <= 0 || number >= 65 {
		return uint64(0), errors.New("Must be bigger than 0 and lower than 65")         
    }

    if number == 1 {
    	return uint64(1), nil
    } else {
        res, _ := Square(number-1)
        return uint64(2) * res, nil
    }
}

func Total() uint64 {
    var result uint64 = 0
    var square uint64 = 0
	for i := 1; i <= 64; i++ {
        square, _ = Square(i)
        result += square
    }
    return result
}
