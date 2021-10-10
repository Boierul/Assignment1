using System;
using System.Collections.Generic;
using System.Linq;
using Assignment1.Models;

namespace Assignment1.Data.Implementation
{
    public class InMemoryUserService : IUserService
    {
        private IList<User> users;

        public InMemoryUserService()
        {
            users = new[]
            {
                new User
                {
                    UserName = "parent1",
                    Password = "123456",
                    Role = "Adult",
                    SecurityLevel = 5
                },
                new User
                {
                    UserName = "child1",
                    Password = "123456",
                    Role = "Child",
                    SecurityLevel = 0
                }
            }.ToList();
        }


        public User ValidateUser(string userName, string password)
        {
            User first = users.FirstOrDefault(user => user.UserName.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }

        // public User Get()
        // {
        //     return users.FirstOrDefault(user => user.UserName.Equals("Troels"));
        // }
    }
}