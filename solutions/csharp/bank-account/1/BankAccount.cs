public class BankAccount
{
    private decimal balance;
    private bool isOpen;

    public void Open()
    {
        if (isOpen)
            throw new InvalidOperationException("Account is already open.");
        isOpen = true;
    }

    public void Close()
    {
        EnsureAccountIsOpen();
        balance = 0;
        isOpen = false;
    }

    public decimal Balance { get { EnsureAccountIsOpen(); return balance; } }

    public void Deposit(decimal change)
    {
        EnsureAccountIsOpen();
        if (change <= 0)
            throw new InvalidOperationException("Deposit amount must be positive.");
        balance += change;
    }

    public void Withdraw(decimal change)
    {
        EnsureAccountIsOpen();
        if (change > balance)
            throw new InvalidOperationException("Insufficient funds.");
        if (change <= 0)
            throw new InvalidOperationException("Withdraw amount must be positive.");
        balance -= change;
    }

    private void EnsureAccountIsOpen()
    {
        if (!isOpen)
            throw new InvalidOperationException("Account is closed.");
    }
}
