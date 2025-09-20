using DomainDrivenDesignDemo.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DomainDrivenDesignDemo.Application
{
    public static class DepedencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfr =>
            {
                cfr.RegisterServicesFromAssemblies(
                    Assembly.GetExecutingAssembly(),
                    typeof(Entity).Assembly);
            });
            return services;
        }

    }
}
