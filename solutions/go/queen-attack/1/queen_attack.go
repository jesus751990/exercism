package queenattack

import (
	"errors"
	"math"
)

func CanQueenAttack(whitePosition, blackPosition string) (bool, error) {
	if len(whitePosition) != 2 || len(blackPosition) != 2 || whitePosition == blackPosition {
		return false, errors.New("invalid position")
	}

	whiteCol := whitePosition[0]
	whiteRow := whitePosition[1]
	blackCol := blackPosition[0]
	blackRow := blackPosition[1]

	if whiteCol < 'a' || whiteCol > 'h' || blackCol < 'a' || blackCol > 'h' ||
		whiteRow < '1' || whiteRow > '8' || blackRow < '1' || blackRow > '8' {
		return false, errors.New("position out of bounds")
	}

	sameRow := whiteRow == blackRow
	sameCol := whiteCol == blackCol
	sameDiagonal := math.Abs(float64(int(whiteCol)-int(blackCol))) == math.Abs(float64(int(whiteRow)-int(blackRow)))

	return sameRow || sameCol || sameDiagonal, nil
}
