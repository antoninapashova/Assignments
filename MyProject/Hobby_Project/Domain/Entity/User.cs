﻿using Domain.Entity;
using Hobby_Project.Domain.Entity;
using Hobby_Project.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class User : BaseEntity
    {
       
        private string username;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        private int age;
        public List<HobbyArticle> Hobbies { get; set; }

        public User(string username, string firstName, string lastName, string email, int age, List<HobbyArticle> hobbies)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Age = age;
            Hobbies = hobbies;
        }

        public string Username {
            get { return username; }  
            set
            {
                if(value.Length<5)
                {
                    throw new ArgumentException("The username must be 5 or more characters!");
                }
                username = value;
            }
        }
        public int Age
        {
            get { return age; }
            set
            {
                if (value <=0)
                {
                    throw new Exception("The age can not be negative or zero!");
                }
                age = value;
            }
        }
   }
}
