package sublist

// Relation type is defined in relations.go file.

func Equals(l1, l2 []int) bool {
	if len(l1) != len(l2) {
		return false
	}

	for i := 0; i < len(l1); i++ {
		if l1[i] != l2[i] {
			return false
		}
	}

	return true
}

func Sublist(l1, l2 []int) Relation {
	if len(l1) == len(l2) {
		if Equals(l1, l2) {
			return RelationEqual
		}
		return RelationUnequal
	}

	var (
		short    []int
		long     []int
		relation Relation
	)
	if len(l1) > len(l2) {
		long = l1
		short = l2
		relation = RelationSuperlist
	} else {
		long = l2
		short = l1
		relation = RelationSublist
	}

	for i := 0; i < len(long); i++ {
		if len(long) < i+len(short) {
			break
		}
		if Equals(short, long[i:i+len(short)]) {
			return relation
		}
	}
	return RelationUnequal
}
