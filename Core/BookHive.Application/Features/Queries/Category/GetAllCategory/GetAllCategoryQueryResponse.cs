using BookHive.Application.DTOs.Category;
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryResponse
    {
        public List<CategoryDto> Categories { get; set; }
        public Result Result { get; set; }
    }
}
