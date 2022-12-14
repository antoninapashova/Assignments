using Application.HobbySubCategories.Commands.Create;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.Validators
{
     public class SubCategoryValidator : AbstractValidator<CreateSubCategoryCommand>
    {
        public SubCategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().Length(3, 10)
                .WithMessage("SubCategory name must be between 5 and 10 characters!");

        }

    }
}
