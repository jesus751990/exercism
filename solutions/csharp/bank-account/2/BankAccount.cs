public class BankAccount
{
    private decimal balance;
    private bool isOpen;
    private readonly object balance_lock = new();

    public void Open()
    {
        if (isOpen)
            throw new InvalidOperationException("Account is already open.");
        lock (balance_lock)
            isOpen = true;
    }

    public void Close()
    {
        EnsureAccountIsOpen();
        lock (balance_lock)
        {
            balance = 0;
            isOpen = false;
        }
    }

    public decimal Balance
    {
        get
        {
            EnsureAccountIsOpen();
            return balance;
        }
    }

    public void Deposit(decimal change)
    {
        EnsureAccountIsOpen();
        if (change <= 0)
            throw new InvalidOperationException("Deposit amount must be positive.");
        lock (balance_lock)
            balance += change;
    }

    public void Withdraw(decimal change)
    {
        EnsureAccountIsOpen();
        if (change > balance || change <= 0)
            throw new InvalidOperationException("Change must be higher than 0 and lower than current balance.");
        lock (balance_lock)
            balance -= change;
    }

    private void EnsureAccountIsOpen()
    {
        if (!isOpen)
            throw new InvalidOperationException("Account is closed.");
    }
}
