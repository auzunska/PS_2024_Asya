using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using WelcomeExtended.Data;
using System.Security.Cryptography;
using System.Text;

namespace WelcomeExtended.Helpers
{
    public static class UserHelper
    {
        public static string ToString(this User user)
        {
            return $"User ID: {user.ID}, Name: {user.Names}, Password: {user.Password}";
        }

        public static string ValidateCredentials(UserData userData, string name, string password)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "The name cannot be empty";
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return "The password cannot be empty";
            }

            if (!userData.ValidateUser(name, password))
            {
                return "Invalid credentials";
            }

            return null;
        }

        public static User GetUser(UserData userData, string name, string password) 
        {
            return userData.GetUser(name, password);
        }

        
    }
}
