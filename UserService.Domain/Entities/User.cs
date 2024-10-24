﻿
using SharedKernel;

namespace UserService.Domain.Entities
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Ride CurrentRide { get; set; }

        public User(string name, string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
        }
    }
}
