package sieve

type PrimeCandidate struct {
	Value   int
	IsPrime bool
}

func Sieve(limit int) []int {
	var sieve []PrimeCandidate

	for i := 2; i <= limit; i++ {
		sieve = append(sieve, PrimeCandidate{Value: i, IsPrime: true})
	}

	for i, candidate := range sieve {
		if candidate.IsPrime {
			for j := i + 1; j < len(sieve); j++ {
				if sieve[j].IsPrime {
					sieve[j].IsPrime = sieve[j].Value%candidate.Value != 0
				}
			}
		}
	}

	var primes []int
	for _, candidate := range sieve {
		if candidate.IsPrime {
			primes = append(primes, candidate.Value)
		}
	}
	return primes
}
