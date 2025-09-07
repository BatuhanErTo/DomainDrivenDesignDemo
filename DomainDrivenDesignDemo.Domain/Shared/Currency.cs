namespace DomainDrivenDesignDemo.Domain.Shared;

public sealed record Currency
{

    public static readonly Currency NONE = new("");
    public static readonly Currency USD = new("USD");
    public static readonly Currency TRY = new("TRY");


    public string Code { get; init; }

    private Currency(string code)
    {
        Code = code;
    }

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(element => element.Code.Equals(code, StringComparison.CurrentCultureIgnoreCase)) ??
            throw new ArgumentException("Not valid currency!");
    }

    public static readonly IReadOnlyCollection<Currency> All = new[] { USD, TRY };
}