package linkedlist

import "errors"

type List struct {
	head, tail *Node
}

type Node struct {
	Value      any
	next, prev *Node
}

func NewList(elements ...any) *List {
	list := &List{}
	for _, e := range elements {
		list.Push(e)
	}
	return list
}

func (l *List) Unshift(v any) {
	node := &Node{Value: v, next: l.head}
	if l.head == nil {
		l.tail = node
	} else {
		l.head.prev = node
	}
	l.head = node
}

func (l *List) Push(v any) {
	node := &Node{Value: v, prev: l.tail}
	if l.head == nil {
		l.head = node
	} else {
		l.tail.next = node
	}
	l.tail = node
}

var ErrEmptyList = errors.New("list is empty")

func (l *List) Shift() (any, error) {
	if l.head == nil {
		return nil, ErrEmptyList
	}
	value := l.head.Value
	l.head = l.head.next
	if l.head != nil {
		l.head.prev = nil
	} else {
		l.tail = nil
	}
	return value, nil
}

func (l *List) Pop() (any, error) {
	if l.tail == nil {
		return nil, ErrEmptyList
	}
	value := l.tail.Value
	l.tail = l.tail.prev
	if l.tail != nil {
		l.tail.next = nil
	} else {
		l.head = nil
	}
	return value, nil
}

func (l *List) Reverse() {
	for c := l.tail; c != nil; c = c.next {
		c.next, c.prev = c.prev, c.next
	}
	l.head, l.tail = l.tail, l.head
}

func (l *List) First() *Node { return l.head }

func (l *List) Last() *Node { return l.tail }

func (n *Node) Next() *Node { return n.next }

func (n *Node) Prev() *Node { return n.prev }
