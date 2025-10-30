package linkedlist

import "errors"

// Define the List and Element types here.
type Element struct {
	value int
	next  *Element
}

type List struct {
	head *Element
	size int
}

func New(elements []int) *List {
	list := &List{head: nil, size: 0}
	for _, elem := range elements {
		list.Push(elem)
	}
	return list
}

func (l *List) Size() int {
	return l.size
}

func (l *List) Push(element int) {
	l.size++
	item := &Element{value: element, next: nil}
	if l.head == nil {
		l.head = item
	} else {
		current := l.head
		for current.next != nil {
			current = current.next
		}
		current.next = item
	}
}

func (l *List) Pop() (int, error) {
	if l.head == nil {
		return 0, errors.New("pop from empty list")
	}
	l.size--
	current := l.head
	previous := current
	value := 0
	for current.next != nil {
		previous = current
		current = current.next
		value = current.value
	}
	previous.next = nil
	return value, nil
}

func (l *List) Array() []int {
	res := make([]int, 0)
	current := l.head
	for current != nil && current.value != 0 {
		res = append(res, current.value)
		current = current.next
	}
	return res
}

func (l *List) Reverse() *List {
	reverse := &List{head: nil, size: l.size}
	current := l.head
	for current != nil {
		item := &Element{value: current.value, next: reverse.head}
		reverse.head = item
		current = current.next
	}
	return reverse
}
