namespace DomainDrivenDesignDemo.Domain.Users;

public sealed record Password
{
    public string Value { get; init; }

    public Password(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Password information cannot be null or empty!");
        }

        if (value.Length < 6)
        {
            throw new ArgumentException("Password information be less than three character!");
        }

        Value = value;
    }
}