package diamond

import (
	"bytes"
	"errors"
	"strings"
)

func Gen(char byte) (string, error) {
	if char < 'A' || char > 'Z' {
		return "", errors.New("char out of range")
	}
	rowLth := 2*(char-'A') + 1
	rows := make([]string, rowLth)
	for c := byte('A'); c <= char; c++ {
		row := bytes.Repeat([]byte{' '}, int(rowLth))
		colNum := char - c
		row[colNum] = c
		row[rowLth-colNum-1] = c
		rowNum := c - 'A'
		rows[rowNum] = string(row)
		rows[rowLth-rowNum-1] = string(row)
	}
	return strings.Join(rows, "\n"), nil
}
