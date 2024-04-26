﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Welcome.Model;
using Welcome.Others;

namespace WelcomeExtended.Data
{
    public class UserData
    {
        private List<User> _users;
        private int _nextId;

        public UserData() { 
            _users = new List<User>();
            _nextId = 0;
        }

        public void AddUser(User user)
        {
            user.ID = _nextId++;
            _users.Add(user);
        }

        public void DeleteUser(User user) {
            _users.Remove(user);
        }

        public bool ValidateUser(string name, string password)
        {
            foreach (var user in _users)
            {
                if(user.Names == name && user.Password == password)
                {
                    return true;
                }
            }

            return false;
        }

        public bool ValidateUserLambda(string name, string password)
        {
            return _users.Where(x => x.Names == name && x.Password == password)
                .FirstOrDefault() != null ? true : false;
        }

        public bool ValidateUserLinq(string name, string password)
        {
            var ret = from user in _users
                      where user.Names == name && user.Password == password
                      select user.ID;
            return ret != null ? true : false;
        }

        public User GetUser(string name, string password)
        {
            bool validate = ValidateUserLinq(name, password);

            if(validate)
            {
                User user = _users.FirstOrDefault(u => u.Names == name && u.Password == password);
                return user;
            }

            return null;
        }

        public void SetActive(string name, DateTime expires)
        {
           
            User user = _users.FirstOrDefault(u => u.Names == name );
            user.Expires = expires;

        }

        public void PrintUsers()
        {
            Console.WriteLine("List of Users:");
            foreach (var user in _users)
            {
                Console.WriteLine($"ID: {user.ID}");
                Console.WriteLine($"Name: {user.Names}");
                Console.WriteLine($"Password: {user.Password}");
                // Print other properties as needed
                Console.WriteLine();
            }
        }

        public void AssignUserRole(string name, UserRolesEnum role)
        {
            User user = _users.FirstOrDefault(u => u.Names == name);
            user.Role = role;
        }
    }
}
