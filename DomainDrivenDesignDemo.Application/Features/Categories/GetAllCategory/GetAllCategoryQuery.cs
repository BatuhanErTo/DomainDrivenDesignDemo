using DomainDrivenDesignDemo.Domain.Categories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesignDemo.Application.Features.Categories.GetAllCategory
{
    public sealed record GetAllCategoryQuery() : IRequest<List<Category>>;
}
