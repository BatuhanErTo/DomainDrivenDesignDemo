namespace DomainDrivenDesignDemo.Domain.Users;

public sealed record Email
{
    public string Value { get; set; }

    public Email(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Email information cannot be null!");
        }

        if (value.Length < 3)
        {
            throw new ArgumentException("Email information be less than three character!");
        }

        if (!value.Contains("@"))
        {
            throw new ArgumentException("Email information must be in valid format!");
        }

        Value = value;
    }
}