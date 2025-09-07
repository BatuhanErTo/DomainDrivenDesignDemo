namespace DomainDrivenDesignDemo.Domain.Shared;

public sealed record Money(decimal Amount, Currency Currency)
{
    public static Money operator +(Money a, Money b)
    {
        if (a.Currency != b.Currency)
        {
            throw new ArgumentException("Currency's type must be same!");
        }
        return new(a.Amount + b.Amount, a.Currency);
    }

    public static Money operator -(Money a, Money b)
    {
        if (a.Currency != b.Currency)
        {
            throw new ArgumentException("Currency's type must be same!");
        }

        if (a.Amount < b.Amount)
        {
            throw new ArgumentException("The result cannot be negative!!");
        }
        return new(a.Amount - b.Amount, a.Currency);
    }

    public static Money Zero() => new(0, Currency.NONE);
    public static Money Zero(Currency currency) => new(0, currency);
    public bool IsZero() => this == Zero(Currency);
}