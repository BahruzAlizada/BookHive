using BookHive.Application.Abstracts.Services.Dapper;
using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.DTOs;
using BookHive.Application.DTOs.Category;
using BookHive.Application.Parametres.ResponseParametres;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly ICategoryReadDapper categoryReadDapper;
        public GetByIdCategoryQueryHandler(ICategoryReadDapper categoryReadDapper)
        {
            this.categoryReadDapper = categoryReadDapper;
        }


        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await categoryReadDapper.GetCategoryAsync(request.Id);
            if (category == null) return new() { Result = new ErrorResult(Messages.IdNull) };
                

            CategoryDto categoryDto = category.Adapt<CategoryDto>();
            return new() { CategoryDto = categoryDto, Result = new SuccessResult(Messages.SuccessGetFiltered) };
        }
    }
}
