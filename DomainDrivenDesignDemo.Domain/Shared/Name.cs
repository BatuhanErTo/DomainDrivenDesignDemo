namespace DomainDrivenDesignDemo.Domain.Shared;

public sealed record Name
{
    public string Value { get; set; }

    public Name(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Name information cannot be null or empty!");

        }

        if (value.Length < 3)
        {
            throw new ArgumentException("Name information be less than three character!");
        }

        Value = value;
    }
}