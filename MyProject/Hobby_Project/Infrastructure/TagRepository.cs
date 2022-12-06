﻿using Application.Repositories;
using Hobby_Project;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class TagRepository  : ITagRepository
    {
        private readonly HobbyDbContext _context;

        public TagRepository(HobbyDbContext context)
        {
            _context = context;
        }

        public async Task<Tag> Add(Tag entity)
        {
           await _context.Tags.AddAsync(entity);
           _context.SaveChanges();
            return entity;
        }

        public async Task DeleteAsync(int id) 
        { 
            Tag tagForDeletion = await IsValid(id);
            _context.Tags.Remove(tagForDeletion);
            _context.SaveChanges();
        }
        
        public async Task<IEnumerable<Tag>> GetAllEntitiesAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            Tag tag = await IsValid(id);
            return tag;
        }

        public async Task UpdateAsync(int id, Tag entity)
        {
            Tag searchedTag =await IsValid(id);
            _context.SaveChanges();
            //Refactor
        }

        private async Task<Tag> IsValid(int Id)
        {
            if (Id <= 0) throw new NullReferenceException("Id must be positive!");
            var tag =await _context.Tags.FirstOrDefaultAsync(t => t.Id == Id);
            if (tag == null) throw new InvalidOperationException("Tag with id: " + Id + " does not exist!!!");
            return tag;
        }
    }
}