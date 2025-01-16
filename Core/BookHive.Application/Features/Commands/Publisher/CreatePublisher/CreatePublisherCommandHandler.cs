
using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation.PublisherValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Publisher.CreatePublisher
{
    public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommandRequest, CreatePublisherCommandResponse>
    {
        private readonly IPublisherWriteRepository publisherWriteRepository;
        private readonly IPublisherRuleService publisherRuleService;
        private readonly IMapper mapper;
        public CreatePublisherCommandHandler(IPublisherWriteRepository publisherWriteRepository, IPublisherRuleService publisherRuleService, IMapper mapper)
        {
            this.publisherWriteRepository = publisherWriteRepository;
            this.publisherRuleService = publisherRuleService;
            this.mapper = mapper;
        }


        public async Task<CreatePublisherCommandResponse> Handle(CreatePublisherCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new PublisherAddValidator().ValidateAsync(request.PublisherAddDto);
            if (!validationResult.IsValid)
            {
                return new CreatePublisherCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(publisherRuleService.CheckIfNameExisted(request.PublisherAddDto.Name));
            if (!result.Success)
            {
                return new CreatePublisherCommandResponse
                {
                    Result = result
                };
            }


            request.PublisherAddDto.ContactNumber = $"{request.PublisherAddDto.ContactNumber.Substring(0, 3)}-{request.PublisherAddDto.ContactNumber.Substring(3, 3)}-{request.PublisherAddDto.ContactNumber.Substring(6, 2)}-{request.PublisherAddDto.ContactNumber.Substring(8, 2)}";
            BookHive.Domain.Entities.Publisher publisher = mapper.Map<BookHive.Domain.Entities.Publisher>(request.PublisherAddDto);

            await publisherWriteRepository.AddAsync(publisher);
            await publisherWriteRepository.SaveAsync();

            return new CreatePublisherCommandResponse
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
