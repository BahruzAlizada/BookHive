using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.CategoryValidator;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
    {
        private readonly ICategoryWriteRepository categoryWriteRepository;
        private readonly ICategoryRuleService categoryRuleService;
        public CreateCategoryCommandHandler(ICategoryWriteRepository categoryWriteRepository, ICategoryRuleService categoryRuleService)
        {
            this.categoryWriteRepository = categoryWriteRepository;
            this.categoryRuleService = categoryRuleService;
        }


        public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new CategoryAddValidator(), request.CategoryAddDto);
            if (!validationResult.Success) return new() { Result = validationResult };
           

            var result = BusinessRules.Run(categoryRuleService.CheckIfNameExisted(request.CategoryAddDto.Name));
            if (!result.Success) return new() { Result = result };
            

            BookHive.Domain.Entities.Category category = request.CategoryAddDto.Adapt<BookHive.Domain.Entities.Category>();
            await categoryWriteRepository.AddAsync(category);
            await categoryWriteRepository.SaveAsync();

            return new CreateCategoryCommandResponse() { Result = new SuccessResult(Messages.SuccessAdded) };
        }
    }
}
