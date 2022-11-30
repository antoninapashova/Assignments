﻿using Application.Logger;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categories.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<int> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            _categoryRepository.DeleteCategoryByID(command.Id);
            SingletonLogger.Instance.LogMessage("delete", "Category with Id: " + command.Id + " is deleted");
            return Task.FromResult(command.Id);
        }
    }
}
