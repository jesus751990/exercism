package phonenumber

import (
	"errors"
	"fmt"
	"strings"
	"unicode"
)

func Number(phoneNumber string) (string, error) {
	var number string
	var builder strings.Builder
	for _, r := range phoneNumber {
		if unicode.IsDigit(r) {
			builder.WriteRune(r)
		}
	}
	number = builder.String()
	if len(number) < 10 || len(number) > 11 {
		return "", errors.New("bad phone number, must have 10 digits and optional country code")
	}
	if len(number) == 11 {
		if int(number[0]-'0') != 1 {
			return "", errors.New("bad phone number, country code must be 1")
		}
		number = number[1:]
	}
	if int(number[0]-'0') < 2 || int(number[3]-'0') < 2 {
		return "", errors.New("bad phone number, first and fourth number must be greather than 1")
	}
	return number, nil
}

func AreaCode(phoneNumber string) (string, error) {
	number, err := Number(phoneNumber)
	if err != nil {
		return "", err
	}

	return number[0:3], nil
}

func Format(phoneNumber string) (string, error) {
	number, err := Number(phoneNumber)
	if err != nil {
		return "", err
	}
	return fmt.Sprintf("(%s) %s-%s", number[0:3], number[3:6], number[6:]), nil
}
