package listops

// IntList is an abstraction of a list of integers which we can define methods on
type IntList []int

func (s IntList) Foldl(fn func(int, int) int, initial int) int {
	for i := 0; i < len(s); i++ {
		initial = fn(initial, s[i])
	}
	return initial
}

func (s IntList) Foldr(fn func(int, int) int, initial int) int {
	for i := len(s) - 1; i >= 0; i-- {
		initial = fn(s[i], initial)
	}
	return initial
}

func (s IntList) Filter(fn func(int) bool) IntList {
	filter := make(IntList, 0)
	for _, v := range s {
		if fn(v) {
			filter = append(filter, v)
		}
	}
	return filter
}

func (s IntList) Length() int {
	return len(s)
}

func (s IntList) Map(fn func(int) int) IntList {
	res := make(IntList, len(s))
	for i, v := range s {
		res[i] = fn(v)
	}
	return res
}

func (s IntList) Reverse() IntList {
	rev := make(IntList, len(s))
	j := 0
	for i := len(s) - 1; i >= 0; i-- {
		rev[j] = s[i]
		j++
	}
	return rev

}

func (s IntList) Append(lst IntList) IntList {
	res := make(IntList, 0, len(s)+len(lst))
	res = append(res, s...)
	res = append(res, lst...)
	return res
}

func (s IntList) Concat(lists []IntList) IntList {
	res := make(IntList, 0, len(s)*len(lists))
	res = append(res, s...)
	for _, l := range lists {
		res = append(res, l...)
	}
	return res
}
