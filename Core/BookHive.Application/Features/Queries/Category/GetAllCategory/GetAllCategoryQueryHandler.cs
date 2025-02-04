using AutoMapper;
using BookHive.Application.Abstracts.Services.Dapper;
using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.DTOs.Category;
using BookHive.Application.Parametres.ResponseParametres;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        private readonly ICategoryReadDapper categoryReadDapper;
        public GetAllCategoryQueryHandler(ICategoryReadDapper categoryReadDapper)
        {
            this.categoryReadDapper = categoryReadDapper;
        }


        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var categories = await categoryReadDapper.GetCategoriesAsync();

            List<CategoryDto> categoriesDto = categories.Adapt<List<CategoryDto>>();
            return new() { Categories = categoriesDto, Result = new SuccessResult(Messages.SuccessListed) };
        }
    }
}
