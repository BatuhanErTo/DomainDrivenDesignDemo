using DomainDrivenDesignDemo.Domain.Categories;
using DomainDrivenDesignDemo.Domain.Orders;
using DomainDrivenDesignDemo.Domain.Products;
using DomainDrivenDesignDemo.Domain.Users;
using DomainDrivenDesignDemo.Infrastructure.Context;
using DomainDrivenDesignDemo.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesignDemo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services)
        {

            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IUnitOfWork>(opt => opt.GetRequiredService<ApplicationDbContext>());

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            return services;
        }
    }
}
