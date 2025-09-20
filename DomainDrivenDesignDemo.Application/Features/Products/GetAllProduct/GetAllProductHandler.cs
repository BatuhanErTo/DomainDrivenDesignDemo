using DomainDrivenDesignDemo.Domain.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesignDemo.Application.Features.Products.GetAllProduct
{
    public sealed record GetAllProductQuery() : IRequest<List<Product>>;
}
