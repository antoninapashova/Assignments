﻿using Domain.Interfaces;
using Hobby_Project.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hobby_Project
{
    public class HobbyComment :BaseEntity, IEdit
    {
        public string Title { get; set; }
        public string CommentContent { get; set; }

        public DateTime AddedOn { get; set; }

        public HobbyComment(string title, string commentContent)
        {
            Title = title;
            CommentContent = commentContent;
           
            AddedOn = DateTime.Now;
        }

        public void ChangeName(string name)
        {
            this.Title = name;
        }

        public void EditName()
        {
            this.Title.ToUpper();
        }
    }
}