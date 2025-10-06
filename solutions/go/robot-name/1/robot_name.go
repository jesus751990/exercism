package robotname

import (
	"errors"
	"fmt"
	"math/rand"
	"slices"
)

type Robot struct{ name string }

const limit = 26 * 26 * 10 * 10

var names = make([]string, limit)
var index = 0

func (r *Robot) Name() (string, error) {
	if r.name != "" {
		return r.name, nil
	}

	if index == limit {
		return "", errors.New("can't generate more names")
	}

	r.name = getName()
	return r.name, nil
}

func (r *Robot) Reset() {
	r.name = ""
}

func getName() string {
	name := generateName()
	for slices.Contains(names, name) {
		name = generateName()
	}
	names[index] = name
	index++
	return name
}

func generateName() string {
	letters := "ABCDEFGHIJKLMNOPQRSTUVWXYZ"
	digits := "0123456789"
	letter1 := letters[rand.Intn(26)]
	letter2 := letters[rand.Intn(26)]
	digit1 := digits[rand.Intn(10)]
	digit2 := digits[rand.Intn(10)]
	digit3 := digits[rand.Intn(10)]
	return fmt.Sprintf("%c%c%c%c%c", letter1, letter2, digit1, digit2, digit3)
}
