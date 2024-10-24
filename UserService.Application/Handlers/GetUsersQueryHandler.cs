using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Application.Commands;
using UserService.Application.Dtos;
using UserService.Domain.Entities;

namespace UserService.Application.Handlers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        private readonly List<User> _users; 

        public GetUsersQueryHandler()
        {
            _users = new List<User>
            {
                new User("User 1", "user1@example.com"),
                new User("User 2", "user2@example.com")
            };
        }

        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_users.Select(u => new UserDto
            {
                Id = u.Id,
                Name = u.Name,
            }).ToList());
        }
    }
}
