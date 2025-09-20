namespace DomainDrivenDesignDemo.Domain.Users;

public interface IUserRepository
{
    Task<User> CreateAsync(string name, string mail, string password, string country, string city, string street, string fullAdress,
        string postalCode, CancellationToken cancellationToken = default);
    Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default);
}