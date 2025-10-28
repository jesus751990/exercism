public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount left, CurrencyAmount right)
    {
        EnsureSameCurrency(left, right);
        return left.amount == right.amount;
    }

    public static bool operator !=(CurrencyAmount left, CurrencyAmount right)
    {
        EnsureSameCurrency(left, right);
        return left.amount != right.amount;
    }

    public static bool operator <(CurrencyAmount left, CurrencyAmount right)
    {
        EnsureSameCurrency(left, right);
        return left.amount < right.amount && left.currency == right.currency;
    }

    public static bool operator >(CurrencyAmount left, CurrencyAmount right)
    {
        EnsureSameCurrency(left, right);
        return left.amount > right.amount && left.currency == right.currency;
    }

    public static CurrencyAmount operator +(CurrencyAmount left, CurrencyAmount right)
    {
        EnsureSameCurrency(left, right);
        return new CurrencyAmount(left.amount + right.amount, left.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount left, CurrencyAmount right)
    {
        EnsureSameCurrency(left, right);
        return new CurrencyAmount(left.amount - right.amount, left.currency);
    }

    public static CurrencyAmount operator *(decimal factor, CurrencyAmount amount) => new(factor * amount.amount, amount.currency);

    public static CurrencyAmount operator /(decimal factor, CurrencyAmount amount) => new(factor / amount.amount, amount.currency);

    public static implicit operator decimal(CurrencyAmount amount) => amount.amount;

    public static implicit operator double(CurrencyAmount amount) => (double)amount.amount;

    private static void EnsureSameCurrency(CurrencyAmount left, CurrencyAmount right)
    {
        if (left.currency != right.currency)
            throw new ArgumentException("Currency amounts must have the same currency.");
    }
}
