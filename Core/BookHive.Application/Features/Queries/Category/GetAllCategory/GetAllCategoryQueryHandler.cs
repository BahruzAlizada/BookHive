using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs.Category;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        private readonly ICategoryReadRepository categoryReadRepository;
        private readonly IMapper mapper;
        public GetAllCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            this.categoryReadRepository = categoryReadRepository;
            this.mapper = mapper;
        }


        public async Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            int totalCategoryCount = await categoryReadRepository.GetAll(false).CountAsync();
            var categories = await categoryReadRepository.GetAll(false).ToListAsync();

            List<CategoryDto> categoriesDto = mapper.Map<List<CategoryDto>>(categories);

            return new GetAllCategoryQueryResponse
            {
                TotalCategoryCount = totalCategoryCount,
                Categories = categoriesDto,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessListed
                }
            };
        }
    }
}
