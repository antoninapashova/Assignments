﻿using Application;
using Hobby_Project;
using Infrastructure;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace HobbyProjectTests
{
    public class CategoryRepositoryTesting
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly Mock<List<HobbySubCategory>> _hobbySubCategory;
        public CategoryRepositoryTesting()
        {
            _categoryRepository = new InMemoryCategoryRepository();
            _hobbySubCategory = new Mock<List<HobbySubCategory>>();
            _categoryRepository.CreateCategory(new("Sport", _hobbySubCategory.Object));
            
        }

        [Fact]
        public void AddCategoryTest()
        {             
            var savedCategory = Assert.Single(_categoryRepository.GetAllCategories());
            Assert.NotNull(savedCategory);
            Assert.Equal("Sport", savedCategory.Name);
        }

        [Fact]
        public void UpdateCategotyTest()
        {            
            _categoryRepository.UpdateCategory(1, "Sports");
            var category = _categoryRepository.GetAllCategories().First();
            
            Assert.NotNull(category);
            Assert.Equal("Sports", category.Name);
        }

        [Fact]
        public void CategoryByIdTest()
        {
            HobbyCategory hobbyCategory = _categoryRepository.GetHobbyCategory(1);
            Assert.NotNull(hobbyCategory);
            Assert.Equal("Sport", hobbyCategory.Name);
        }

        [Fact]
        public void DeleteCategoryByIdTest()
        {
            _categoryRepository.DeleteCategoryByID(1);
            Assert.Empty(_categoryRepository.GetAllCategories());
        }
    }
}
