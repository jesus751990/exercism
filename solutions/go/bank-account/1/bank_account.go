package account

import "sync"

// Define the Account type here.
type Account struct {
	amount int64
	closed bool
	mutext sync.Mutex
}

func Open(amount int64) *Account {
	if amount < 0 {
		return nil
	}
	return &Account{amount: amount}
}

func (a *Account) Balance() (int64, bool) {
	a.mutext.Lock()
	defer a.mutext.Unlock()
	if a.closed {
		return 0, false
	}
	return a.amount, true
}

func (a *Account) Deposit(amount int64) (int64, bool) {
	a.mutext.Lock()
	defer a.mutext.Unlock()
	total := a.amount + amount
	if a.closed || total < 0 {
		return 0, false
	}
	a.amount += total
	return total, true
}

func (a *Account) Close() (int64, bool) {
	a.mutext.Lock()
	defer a.mutext.Unlock()
	if a.closed {
		return 0, false
	}
	amount := a.amount
	a.closed = true
	a.amount = 0
	return amount, true
}
