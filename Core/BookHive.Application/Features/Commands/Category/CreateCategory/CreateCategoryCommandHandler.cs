using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.CategoryValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository categoryWriteRepository;
        private readonly ICategoryRuleService categoryRuleService;
        private readonly IMapper mapper;
        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryRuleService categoryRuleService, IMapper mapper)
        {
            this.categoryWriteRepository = categoryWriteRepository;
            this.categoryRuleService = categoryRuleService;
            this.mapper = mapper;
        }


        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new CategoryAddValidator().ValidateAsync(request.CategoryAddDto);
            if (!validationResult.IsValid)
            {
                return new CreateCategoryCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(categoryRuleService.CheckIfNameExisted(request.CategoryAddDto.Name));
            if (!result.Success)
            {
                return new CreateCategoryCommandResponse { Result = result };
            };


            BookHive.Domain.Entities.Category category = mapper.Map<BookHive.Domain.Entities.Category>(request.CategoryAddDto);

            await categoryWriteRepository.AddAsync(category);
            await categoryWriteRepository.SaveAsync();

            return new CreateCategoryCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessAdded
                }
            };
        }
    }
}
