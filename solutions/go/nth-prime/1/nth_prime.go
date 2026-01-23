package prime

import (
	"errors"
)

func IsPrime(n int) (bool, error) {
	if n <= 1 {
		return false, errors.New("n must be greather than one")
	}

	if (n > 2 && n%2 == 0) || (n > 5 && n%5 == 0) {
		return false, nil
	}

	if n > 3 {
		sumDigits := 0
		sdn := n
		for sdn > 0 {
			sumDigits += sdn % 10
			sdn /= 10
		}
		if sumDigits%3 == 0 {
			return false, nil
		}
	}

	for i := 2; i < n; i++ {
		if n%i == 0 {
			return false, nil
		}
	}
	return true, nil
}

// Nth returns the nth prime number. An error must be returned if the nth prime number can't be calculated ('n' is equal or less than zero)
func Nth(n int) (int, error) {
	if n < 1 {
		return 0, errors.New("n must be greather or equal to one")
	}
	primes := 0
	prime := 0
	i := 2
	for {
		if isPrime, _ := IsPrime(i); isPrime {
			primes++
			if primes == n {
				prime = i
				break
			}
		}
		i++
	}
	return prime, nil
}
