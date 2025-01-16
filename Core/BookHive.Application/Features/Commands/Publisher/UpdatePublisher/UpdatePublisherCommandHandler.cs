
using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.PublisherValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Publisher.UpdatePublisher
{
    public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommandRequest, UpdatePublisherCommandResponse>
    {
        private readonly IPublisherWriteRepository publisherWriteRepository;
        private readonly IPublisherRuleService publisherRuleService;
        private readonly IMapper mapper;
        public UpdatePublisherCommandHandler(IPublisherWriteRepository publisherWriteRepository, IPublisherRuleService publisherRuleService, IMapper mapper)
        {
            this.publisherWriteRepository = publisherWriteRepository;
            this.publisherRuleService = publisherRuleService;
            this.mapper = mapper;
        }
        public async Task<UpdatePublisherCommandResponse> Handle(UpdatePublisherCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new PublisherUpdateValidator().ValidateAsync(request.PublisherUpdateDto);
            if (!validationResult.IsValid)
            {
                return new UpdatePublisherCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(publisherRuleService.CheckIfNameExisted(request.PublisherUpdateDto.Name, request.PublisherUpdateDto.Id));
            if (!result.Success)
            {
                return new UpdatePublisherCommandResponse
                {
                    Result = result
                };
            }

            request.PublisherUpdateDto.ContactNumber = $"{request.PublisherUpdateDto.ContactNumber.Substring(0, 3)}-{request.PublisherUpdateDto.ContactNumber.Substring(3, 3)}-{request.PublisherUpdateDto.ContactNumber.Substring(6, 2)}-{request.PublisherUpdateDto.ContactNumber.Substring(8, 2)}";
            BookHive.Domain.Entities.Publisher publisher = mapper.Map<BookHive.Domain.Entities.Publisher>(request.PublisherUpdateDto);

            publisherWriteRepository.Update(publisher);
            await publisherWriteRepository.SaveAsync();

            return new UpdatePublisherCommandResponse
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
