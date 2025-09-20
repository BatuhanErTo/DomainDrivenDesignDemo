using DomainDrivenDesignDemo.Domain.Categories;
using DomainDrivenDesignDemo.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesignDemo.Infrastructure.Repositories
{
    internal sealed class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
        {
            Category category = new(Guid.NewGuid(), new(name));
            await _context.Categories.AddAsync(category, cancellationToken);
        }

        public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Categories.ToListAsync(cancellationToken);
        }
    }
}
