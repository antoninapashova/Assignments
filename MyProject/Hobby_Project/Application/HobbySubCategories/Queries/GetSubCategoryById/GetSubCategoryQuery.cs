using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HobbyProject.Application.HobbySubCategories.Queries.GetSubCategoryById
{
    public class GetSubCategoryQuery : IRequest<HobbySubCategoryDto>
    {
        public int Id { get; set; }
    }
}
