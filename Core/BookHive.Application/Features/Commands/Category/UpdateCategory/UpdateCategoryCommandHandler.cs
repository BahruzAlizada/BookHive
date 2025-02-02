using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.CategoryValidator;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommandRequest, UpdateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository categoryWriteRepository;
        private readonly ICategoryRuleService categoryRuleService;
        public UpdateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryRuleService categoryRuleService)
        {
            this.categoryWriteRepository = categoryWriteRepository;
            this.categoryRuleService = categoryRuleService;
        }


        public async Task<UpdateCategoryCommandResponse> Handle(UpdateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new CategoryUpdateValidator(), request.CategoryUpdateDto);
            if (!validationResult.Success) return new() {  Result = validationResult };
        

            var result = BusinessRules.Run(categoryRuleService.CheckIfNameExisted(request.CategoryUpdateDto.Name, request.CategoryUpdateDto.Id));
            if (!result.Success) return new() { Result = result };
            

            BookHive.Domain.Entities.Category category = request.CategoryUpdateDto.Adapt<BookHive.Domain.Entities.Category>();
            categoryWriteRepository.Update(category);
            await categoryWriteRepository.SaveAsync();

            return new() { Result = new SuccessResult(Messages.SuccessUpdated) };
        }
    }
}
