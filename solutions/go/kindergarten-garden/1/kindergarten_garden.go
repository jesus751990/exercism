package kindergarten

import (
	"errors"
	"fmt"
	"regexp"
	"sort"
	"strings"
)

type Garden struct {
	childs []ChildPlants
}

type ChildPlants struct {
	child  string
	plants []string
}

func NewGarden(diagram string, children []string) (*Garden, error) {
	var garden Garden
	re := regexp.MustCompile(`^(?:\n[GCRV]+)+$`)

	if !re.MatchString(diagram) {
		return nil, errors.New("bad diagram format")
	}

	splitFn := func(c rune) bool {
		return c == '\n'
	}
	lines := strings.FieldsFunc(diagram, splitFn)

	if _, errLines := LinesAreValids(lines); errLines != nil {
		return nil, errLines
	}

	clone := make([]string, len(children))
	copy(clone, children)
	sort.Strings(clone)
	for _, c := range clone {
		if _, errChild := ChildIsValid(c, garden.childs); errChild != nil {
			return nil, errChild
		}
		child := ChildPlants{child: c, plants: make([]string, 0)}
		garden.childs = append(garden.childs, child)
	}

	for l := 0; l < len(lines); l++ {
		c := 0
		for i := 0; i < len(lines[l]); i += 2 {
			for j := i; j < i+2; j++ {
				plant, errDec := Decoding(rune(lines[l][j]))
				if errDec != nil {
					return nil, errDec
				}
				garden.childs[c].plants = append(garden.childs[c].plants, plant)
			}
			c++
		}
	}
	return &garden, nil
}

func (g *Garden) Plants(child string) ([]string, bool) {
	for _, c := range g.childs {
		if c.child == child {
			return c.plants, true
		}
	}
	return nil, false
}

func Decoding(r rune) (string, error) {
	switch r {
	case 'G':
		return "grass", nil
	case 'C':
		return "clover", nil
	case 'R':
		return "radishes", nil
	case 'V':
		return "violets", nil
	default:
		return "", fmt.Errorf("error decoding %s", string(r))
	}
}

func LinesAreValids(lines []string) (bool, error) {
	if len(lines) == 0 {
		return false, errors.New("diagram rows cannot be empty")
	}

	len1 := len(lines[0])
	if len1%2 != 0 {
		return false, errors.New("diagram rows plants cannot be ood")
	}
	for _, l := range lines {
		if len1 != len(l) {
			return false, errors.New("diagram rows must have same lenght")
		}
	}
	return true, nil
}

func ChildIsValid(c string, children []ChildPlants) (bool, error) {
	if len(c) == 0 {
		return false, errors.New("child name cannot be empty")
	}

	for _, v := range children {
		if c == v.child {
			return false, errors.New("child names must be uniques")
		}
	}
	return true, nil
}
