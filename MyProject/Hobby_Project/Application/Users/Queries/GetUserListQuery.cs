﻿using Application.Categories.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Users.Queries
{
    public  class GetUserListQuery : IRequest<IEnumerable<UserListVm>>
    {
      
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public List<HobbyArticleDTO> Hobbies { get; set; }
    }
}