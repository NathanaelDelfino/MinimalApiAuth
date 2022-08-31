using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MinimalApiAuth.Models;

namespace MinimalApiAuth.Repository
{
    public static class UserRepository
    {
        private static List<User> ListaDeUsuarios()
        {
            return new List<User>(){
                new (1, "admin", "admin", "admin"),
                new (2, "user", "user", "user")
            };
        }
        public static User Get(string username, string password)
        {
            return ListaDeUsuarios().FirstOrDefault(x => x.Username.ToLower() == username && x.Password == password) ?? new User();
        }
        public static User Get(User user)
        {
            return ListaDeUsuarios().FirstOrDefault(x => x.Username.ToLower() == user.Username && x.Password == user.Password) ?? new User();
        }
    }
}