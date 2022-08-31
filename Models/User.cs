using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalApiAuth.Models
{
    public class User
    {
        public User()
        {

        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public User(string username, string password, string role)
        {

            Username = username;
            Password = password;
            Role = role;
        }

        public User(int id, string username, string password, string role)
        {
            Id = id;
            Username = username;
            Password = password;
            Role = role;
        }

        public int Id { get; private set; }
        public string Username { get; private set; } = "";
        public string Password { get; private set; } = "";
        public string Role { get; private set; } = "";

        public void CleanPassword()
        {
            Password = "";
        }
        public bool isValid()
        {
            return !string.IsNullOrEmpty(Username)
                && !string.IsNullOrEmpty(Password)
                && !string.IsNullOrEmpty(Role);
        }
    }
}