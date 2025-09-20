using DomainDrivenDesignDemo.Domain.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainDrivenDesignDemo.Application.Features.Users.GetAllUser
{
    public record GetAllUserQuery() : IRequest<List<User>>;
}
