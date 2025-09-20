using DomainDrivenDesignDemo.Domain.Categories;
using DomainDrivenDesignDemo.Domain.Orders;
using DomainDrivenDesignDemo.Domain.Products;
using DomainDrivenDesignDemo.Domain.Shared;
using DomainDrivenDesignDemo.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesignDemo.Infrastructure.Context
{
    internal sealed class ApplicationDbContext : DbContext, IUnitOfWork
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5433;Database=ddd_demo;Username=postgres;Password=postgres;Include Error Detail=true");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(p => p.Name)
                .HasConversion(name => name.Value, value => new(value));

            modelBuilder.Entity<User>()
               .Property(p => p.Email)
               .HasConversion(email => email.Value, value => new(value));

            modelBuilder.Entity<User>()
               .Property(p => p.Password)
               .HasConversion(password => password.Value, value => new(value));

            modelBuilder.Entity<User>()
                .OwnsOne(p => p.Address);

            modelBuilder.Entity<Category>()
                .Property(p => p.Name)
                .HasConversion(name => name.Value, value => new(value));

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .HasConversion(name => name.Value, value => new(value));

            modelBuilder.Entity<Product>()
                .OwnsOne(p => p.Price, priceBuilder =>
                {
                    priceBuilder
                    .Property(p => p.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                    priceBuilder
                    .Property(p => p.Amount)
                    .HasColumnType("money");
                });

            modelBuilder.Entity<OrderLine>()
                .OwnsOne(p => p.Price, priceBuilder =>
                {
                    priceBuilder
                    .Property(p => p.Currency)
                    .HasConversion(currency => currency.Code, code => Currency.FromCode(code));

                    priceBuilder
                    .Property(p => p.Amount)
                    .HasColumnType("money");
                });
        }
    }
}
