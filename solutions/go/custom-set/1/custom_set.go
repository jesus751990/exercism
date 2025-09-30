package stringset

import (
	"fmt"
	"strings"
)

type Set []string

func New() Set {
	return make([]string, 0)
}

func NewFromSlice(l []string) Set {
	set := New()
	for _, v := range l {
		set.Add(v)
	}
	return set
}

func (s Set) String() string {
	var builder strings.Builder
	builder.WriteString("{")
	for i := 0; i < len(s)-1; i++ {
		builder.WriteString(fmt.Sprintf("\"%s\", ", s[i]))
	}
	if len(s) > 0 {
		builder.WriteString(fmt.Sprintf("\"%s\"", s[len(s)-1]))
	}
	builder.WriteString("}")
	return builder.String()
}

func (s Set) IsEmpty() bool {
	return len(s) == 0
}

func (s Set) Has(elem string) bool {
	for _, v := range s {
		if elem == v {
			return true
		}
	}
	return false
}

func (s *Set) Add(elem string) {
	if !s.Has(elem) {
		*s = append(*s, elem)
	}
}

func Subset(s1, s2 Set) bool {
	for _, v := range s1 {
		if !s2.Has(v) {
			return false
		}
	}
	return true
}

func Disjoint(s1, s2 Set) bool {
	for _, v := range s1 {
		if s2.Has(v) {
			return false
		}
	}
	return true
}

func Equal(s1, s2 Set) bool {
	if len(s1) == len(s2) {
		for _, v := range s2 {
			if !s1.Has(v) {
				return false
			}
		}
		return true
	}
	return false
}

func Intersection(s1, s2 Set) Set {
	res := New()
	for _, v := range s1 {
		if s2.Has(v) {
			res.Add(v)
		}
	}
	return res
}

func Difference(s1, s2 Set) Set {
	res := New()
	for _, v := range s1 {
		if !s2.Has(v) {
			res.Add(v)
		}
	}
	return res
}

func Union(s1, s2 Set) Set {
	res := NewFromSlice(s1)
	for _, v := range s2 {
		res.Add(v)
	}
	return res
}
