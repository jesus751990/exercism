package wordy

import (
	"fmt"
	"strconv"
	"strings"
)

func Answer(question string) (int, bool) {
	operators := make([]string, 0)
	operands := make([]int, 0)
	words := GetWords(question)

	for _, w := range words {
		if opd, errOpd := strconv.Atoi(w); errOpd == nil {
			if len(operands) != len(operators) {
				return 0, false
			}
			operands = append(operands, opd)
		} else if opt, errOpt := GetOperator(w); errOpt == nil {
			operators = append(operators, opt)
			if len(operands) < len(operators) {
				return 0, false
			}
		} else {
			return 0, false
		}
	}

	if len(operators) >= len(operands) {
		return 0, false
	}

	if len(operands) == 1 {
		return operands[0], true
	}

	res := 0
	if len(operators) > 0 {
		res = ApplyOperator(operands[0], operands[1], operators[0])

		for i := 1; i < len(operators); i++ {
			res = ApplyOperator(res, operands[i+1], operators[i])
		}
	}
	return res, true
}

func GetOperator(word string) (string, error) {
	availabeOperators := []string{"plus", "minus", "multiplied", "divided"}
	for _, op := range availabeOperators {
		if strings.ToLower(word) == op {
			return op, nil
		}
	}
	return "", fmt.Errorf("invalid operator %s", word)
}

func ApplyOperator(a, b int, op string) int {
	switch op {
	case "plus":
		return a + b
	case "minus":
		return a - b
	case "multiplied":
		return a * b
	case "divided":
		return a / b
	default:
		return 0
	}
}

func GetWords(question string) []string {
	question = strings.Replace(question, "?", "", 1)
	question = strings.Replace(question, "What is ", "", 1)
	question = strings.ReplaceAll(question, "by ", "")
	return strings.Split(question, " ")
}
