package linkedlist

import "errors"

type List struct {
	head *Node
	tail *Node
}

type Node struct {
	Value any
	next  *Node
	prev  *Node
}

func NewList(elements ...any) *List {
	list := &List{}
	for _, elem := range elements {
		list.Push(elem)
	}
	return list
}

func (n *Node) Next() *Node {
	return n.next
}

func (n *Node) Prev() *Node {
	return n.prev
}

func (l *List) Unshift(v any) {
	node := &Node{Value: v}
	if l.head == nil {
		l.head = node
		l.tail = node
	} else {
		node.next = l.head
		l.head.prev = node
		l.head = node
	}
}

func (l *List) Push(v any) {
	node := &Node{Value: v}
	if l.tail == nil {
		l.head = node
		l.tail = node
	} else {
		node.prev = l.tail
		l.tail.next = node
		l.tail = node
	}
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
	reverse := &List{}
	for current := l.tail; current != nil; current = current.prev {
		reverse.Push(current.Value)
	}
	l.head = reverse.head
	l.tail = reverse.tail
}

func (l *List) First() *Node {
	return l.head
}

func (l *List) Last() *Node {
	return l.tail
}
