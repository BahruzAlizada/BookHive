using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using BookHive.Application.DTOs.Category;
using MediatR;

namespace BookHive.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryHandler : IRequestHandler<GetByIdCategoryQueryRequest, GetByIdCategoryQueryResponse>
    {
        private readonly ICategoryReadRepository categoryReadRepository;
        private readonly IMapper mapper;
        public GetByIdCategoryQueryHandler(ICategoryReadRepository categoryReadRepository, IMapper mapper)
        {
            this.categoryReadRepository = categoryReadRepository;
            this.mapper = mapper;
        }


        public async Task<GetByIdCategoryQueryResponse> Handle(GetByIdCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var category = await categoryReadRepository.GetSingleAsync(x=>x.Id == request.Id);
            if (category == null)
                return new GetByIdCategoryQueryResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };

            CategoryDto categoryDto = mapper.Map<CategoryDto>(category);

            return new GetByIdCategoryQueryResponse
            {
                CategoryDto = categoryDto,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessGetFiltered
                }
            };
        }
    }
}
