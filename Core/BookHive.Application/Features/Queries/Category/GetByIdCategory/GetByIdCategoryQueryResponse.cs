using BookHive.Application.DTOs.Category;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryResponse
    {
        public CategoryDto? CategoryDto { get; set; }
        public Result Result { get; set; }
    }
}
