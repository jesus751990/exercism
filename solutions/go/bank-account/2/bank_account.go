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
	balance, closed := a.amount, a.closed
	return balance, !closed
}

func (a *Account) Deposit(amount int64) (int64, bool) {
	a.mutext.Lock()
	defer a.mutext.Unlock()
	total, closed := a.amount+amount, a.closed
	if a.closed || total < 0 {
		return 0, false
	}
	a.amount = total
	return total, !closed
}

func (a *Account) Close() (int64, bool) {
	a.mutext.Lock()
	defer a.mutext.Unlock()
	total, closed := a.amount, a.closed
	a.closed = true
	a.amount = 0
	return total, !closed
}
