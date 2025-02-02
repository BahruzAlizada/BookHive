using AutoMapper;
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
        private readonly ICategoryReadRepository categoryReadRepository;
        public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            this.categoryReadRepository = categoryReadRepository;
        }


        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            int totalCategoryCount = await categoryReadRepository.GetAll(false).CountAsync();
            var categories = await categoryReadRepository.GetAll(false).ToListAsync();

            List<CategoryDto> categoriesDto = categories.Adapt<List<CategoryDto>>();
            return new() { TotalCategoryCount = totalCategoryCount, Categories = categoriesDto, Result = new SuccessResult(Messages.SuccessListed) };
        }
    }
}
