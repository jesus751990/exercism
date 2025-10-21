package pascal

func Triangle(n int) [][]int {
	if n <= 0 {
		return [][]int{}
	}

	triangle := make([][]int, n)
	for i := range triangle {
		triangle[i] = make([]int, i+1)
		triangle[i][0] = 1
		for j := 1; j < i; j++ {
			triangle[i][j] = triangle[i-1][j-1] + triangle[i-1][j]
		}
		triangle[i][i] = 1
	}
	return triangle
}
