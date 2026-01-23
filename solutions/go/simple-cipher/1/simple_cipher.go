package cipher

import (
	"regexp"
	"strings"
)

type shift struct {
	distance int
}
type vigenere struct {
	key string
}

func NewCaesar() Cipher {
	return &shift{distance: 3}
}

func NewShift(distance int) Cipher {
	if distance <= -26 || distance == 0 || distance >= 26 {
		return nil
	}
	return &shift{distance: distance}
}

func (c shift) Encode(input string) string {
	var builder strings.Builder
	builder.Grow(len(input))
	for _, r := range strings.ToLower(input) {
		if 'a' <= r && r <= 'z' {
			builder.WriteRune(ShiftRune(r, c.distance))
		}
	}
	return builder.String()
}

func (c shift) Decode(input string) string {
	var builder strings.Builder
	builder.Grow(len(input))
	for _, r := range input {
		if 'a' <= r && r <= 'z' {
			builder.WriteRune(ShiftRune(r, -c.distance))
		}
	}
	return builder.String()
}

func NewVigenere(key string) Cipher {
	if len(key) == 0 {
		return nil
	}
	re := regexp.MustCompile(`^[a]*$`)
	if re.MatchString(key) {
		return nil
	}
	for _, r := range key {
		if r < 'a' || r > 'z' {
			return nil
		}
	}
	return &vigenere{key: key}
}

func (v vigenere) Encode(input string) string {
	var builder strings.Builder
	builder.Grow(len(input))
	var i int
	for _, r := range strings.ToLower(input) {
		if 'a' <= r && r <= 'z' {
			key := i % len(v.key)
			distance := int(rune(v.key[key]) - 'a')
			builder.WriteRune(ShiftRune(r, distance))
			i++
		}
	}
	return builder.String()
}

func (v vigenere) Decode(input string) string {
	var builder strings.Builder
	builder.Grow(len(input))
	for i, r := range input {
		if 'a' <= r && r <= 'z' {
			key := i % len(v.key)
			distance := int(rune(v.key[key]) - 'a')
			builder.WriteRune(ShiftRune(r, -distance))
		}
	}
	return builder.String()
}

func ShiftRune(r rune, distance int) rune {
	if distance < 0 {
		distance = 26 + distance
	}
	idx := (int(r-'a') + distance) % 26
	return rune('a' + idx)
}
