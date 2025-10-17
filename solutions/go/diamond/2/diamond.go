package diamond

import (
	"bytes"
	"errors"
	"strings"
)

func Gen(target byte) (string, error) {
	if target < 'A' || target > 'Z' {
		return "", errors.New("char out of range")
	}
	size := 2*(target-'A') + 1
	rows := make([]string, size)
	for c := byte('A'); c <= target; c++ {
		row := bytes.Repeat([]byte{' '}, int(size))
		index := c - 'A'
		row[size/2-index] = c
		row[size/2+index] = c
		rows[index] = string(row)
		rows[size-index-1] = string(row)
	}
	return strings.Join(rows, "\n"), nil
}
