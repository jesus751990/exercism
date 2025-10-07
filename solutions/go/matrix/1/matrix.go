package matrix

import (
	"errors"
	"regexp"
	"strconv"
	"strings"
)

// Define the Matrix type here.
type Matrix [][]int

func New(s string) (Matrix, error) {
	rows := strings.Split(s, "\n")
	if len(rows) == 0 {
		return nil, errors.New("bad input format")
	}

	splitFn := func(c rune) bool {
		return c == ' '
	}
	var res Matrix
	for _, r := range rows {
		numberFollowOrPrecededBySpace := regexp.MustCompile(`^\s*\d+( \d+)*\s*$`)
		match := numberFollowOrPrecededBySpace.MatchString(r)
		if !match {
			return nil, errors.New("bad input format")
		}
		svalues := strings.FieldsFunc(r, splitFn)
		row := make([]int, len(svalues))
		for i, sv := range svalues {
			iv, err := strconv.Atoi(sv)
			if err != nil {
				return nil, err
			}
			row[i] = iv
		}
		if len(res) > 0 && len(res[0]) != len(row) {
			return nil, errors.New("bad input format")
		}
		res = append(res, row)
	}
	return res, nil
}

// Cols and Rows must return the results without affecting the matrix.
func (m Matrix) Cols() [][]int {
	columns := len(m[0])
	rows := len(m)
	result := make([][]int, columns)
	for c := 0; c < columns; c++ {
		row := make([]int, rows)
		for r := 0; r < rows; r++ {
			row[r] = m[r][c]
		}
		result[c] = row
	}
	return result
}

func (m Matrix) Rows() [][]int {
	columns := len(m)
	rows := len(m[0])
	result := make([][]int, columns)
	for c := 0; c < columns; c++ {
		row := make([]int, rows)
		for r := 0; r < rows; r++ {
			row[r] = m[c][r]
		}
		result[c] = row
	}
	return result
}

func (m Matrix) Set(row, col, val int) bool {
	rows := len(m)
	columns := len(m[0])
	if columns > col && rows > row && row >= 0 && col >= 0 {
		m[row][col] = val
		return true
	}
	return false
}
