using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.CategoryValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository categoryWriteRepository;
        private readonly ICategoryRuleService categoryRuleService;
        private readonly IMapper mapper;
        public UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryRuleService categoryRuleService, IMapper mapper)
        {
            this.categoryWriteRepository = categoryWriteRepository;
            this.categoryRuleService = categoryRuleService;
            this.mapper = mapper;
        }


        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new CategoryUpdateValidator().ValidateAsync(request.CategoryUpdateDto);
            if (!validationResult.IsValid)
            {
                return new UpdateCategoryCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(categoryRuleService.CheckIfNameExisted(request.CategoryUpdateDto.Name, request.CategoryUpdateDto.Id));
            if (!result.Success)
            {
                return new UpdateCategoryCommandResponse
                {
                    Result = result
                };
            }

            var category = mapper.Map<BookHive.Domain.Entities.Category>(request.CategoryUpdateDto);

            categoryWriteRepository.Update(category);
            await categoryWriteRepository.SaveAsync();

            return new UpdateCategoryCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessUpdated
                }
            };
        }
    }
}
