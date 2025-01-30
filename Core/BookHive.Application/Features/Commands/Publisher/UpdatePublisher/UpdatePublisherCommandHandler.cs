using BookHive.Application.Abstracts.Services;
using BookHive.Application.Constants;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.PublisherValidator;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Commands.Publisher.UpdatePublisher
{
    public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommandRequest, UpdatePublisherCommandResponse>
    {
        private readonly IPublisherWriteRepository publisherWriteRepository;
        private readonly IPublisherRuleService publisherRuleService;
        public UpdatePublisherCommandHandler(IPublisherWriteRepository publisherWriteRepository, IPublisherRuleService publisherRuleService)
        {
            this.publisherWriteRepository = publisherWriteRepository;
            this.publisherRuleService = publisherRuleService;
        }


        public async Task<UpdatePublisherCommandResponse> Handle(UpdatePublisherCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new PublisherUpdateValidator(), request.PublisherUpdateDto);
            if (!validationResult.Success) return new() { Result = validationResult };  

            var result = BusinessRules.Run(publisherRuleService.CheckIfNameExisted(request.PublisherUpdateDto.Name, request.PublisherUpdateDto.Id));
            if (!result.Success) return new() { Result = result };
            

            request.PublisherUpdateDto.ContactNumber = $"{request.PublisherUpdateDto.ContactNumber.Substring(0, 3)}-{request.PublisherUpdateDto.ContactNumber.Substring(3, 3)}-{request.PublisherUpdateDto.ContactNumber.Substring(6, 2)}-{request.PublisherUpdateDto.ContactNumber.Substring(8, 2)}";
            BookHive.Domain.Entities.Publisher publisher = request.PublisherUpdateDto.Adapt<BookHive.Domain.Entities.Publisher>();

            publisherWriteRepository.Update(publisher);
            await publisherWriteRepository.SaveAsync();
            return new UpdatePublisherCommandResponse { Result = new SuccessResult(Messages.SuccessUpdated) };
        }
    }
}
