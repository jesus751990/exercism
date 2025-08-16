package diffsquares

func SquareOfSum(n int) int {
	var (
        i int = 1
        sum int
    )
    for {
        if i > n {
            break;
        }
        sum += i
        i++
    }
    return sum * sum
}

func SumOfSquares(n int) int {
	var (
        i int = 1
        sum int
    )
    for {
        if i > n {
            break;
        }
        sum += i * i
        i++
    }
    return sum
}

func Difference(n int) int {
	return SquareOfSum(n) - SumOfSquares(n)
}
