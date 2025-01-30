using BookHive.Application.Abstracts.Services;
using BookHive.Application.Constants;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.PublisherValidator;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Commands.Publisher.CreatePublisher
{
    public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommandRequest, CreatePublisherCommandResponse>
    {
        private readonly IPublisherWriteRepository publisherWriteRepository;
        private readonly IPublisherRuleService publisherRuleService;
        public CreatePublisherCommandHandler(IPublisherWriteRepository publisherWriteRepository, IPublisherRuleService publisherRuleService)
        {
            this.publisherWriteRepository = publisherWriteRepository;
            this.publisherRuleService = publisherRuleService;
        }


        public async Task<CreatePublisherCommandResponse> Handle(CreatePublisherCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new PublisherAddValidator(), request.PublisherAddDto);
            if (!validationResult.Success) return new() { Result = validationResult };
            

            var result = BusinessRules.Run(publisherRuleService.CheckIfNameExisted(request.PublisherAddDto.Name));
            if (!result.Success) return new() { Result = result };


            request.PublisherAddDto.ContactNumber = $"{request.PublisherAddDto.ContactNumber.Substring(0, 3)}-{request.PublisherAddDto.ContactNumber.Substring(3, 3)}-{request.PublisherAddDto.ContactNumber.Substring(6, 2)}-{request.PublisherAddDto.ContactNumber.Substring(8, 2)}";
            BookHive.Domain.Entities.Publisher publisher = request.PublisherAddDto.Adapt<BookHive.Domain.Entities.Publisher>();

            await publisherWriteRepository.AddAsync(publisher);
            await publisherWriteRepository.SaveAsync();
            return new CreatePublisherCommandResponse { Result = new SuccessResult(Messages.SuccessAdded) };
        }
    }
}
