using DomainDrivenDesignDemo.Domain.Abstractions;
using DomainDrivenDesignDemo.Domain.Products;
using DomainDrivenDesignDemo.Domain.Shared;

namespace DomainDrivenDesignDemo.Domain.Categories;

public sealed class Category : Entity
{
    public Category(Guid id, Name name) : base(id)
    {
        Name = name;
    }

    public Name Name { get; private set; }
    public ICollection<Product> Products { get; private set; }

    public void ChangeName(string name)
    {
        Name = new(name);
    }
}