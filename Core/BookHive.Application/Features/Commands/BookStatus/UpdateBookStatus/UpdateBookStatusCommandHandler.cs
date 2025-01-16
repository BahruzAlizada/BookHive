using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Rule;
using BookHive.Application.Rules.Abstract;
using BookHive.Application.Validation.FluentValidation;
using MediatR;

namespace BookHive.Application.Features.Commands.BookStatus.UpdateBookStatus
{
    public class UpdateBookStatusCommandHandler : IRequestHandler<UpdateBookStatusCommandRequest, UpdateBookStatusCommandResponse>
    {
        private readonly IBookStatusWriteRepository bookStatusWriteRepository;
        private readonly IBookStatusRuleService bookStatusRuleService;
        private readonly IMapper mapper;
        public UpdateBookStatusCommandHandler(IBookStatusWriteRepository bookStatusWriteRepository, IBookStatusRuleService bookStatusRuleService, IMapper mapper)
        {
            this.bookStatusWriteRepository = bookStatusWriteRepository;
            this.bookStatusRuleService = bookStatusRuleService;
            this.mapper = mapper;
        }


        public async Task<UpdateBookStatusCommandResponse> Handle(UpdateBookStatusCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new BookStatusUpdateValidator().ValidateAsync(request.BookStatusUpdateDto);
            if (!validationResult.IsValid)
            {
                return new UpdateBookStatusCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = validationResult.ValidationErrorString()
                    }
                };
            }

            var result = BusinessRules.Run(bookStatusRuleService.CheckIfNameExisted(request.BookStatusUpdateDto.Name, request.BookStatusUpdateDto.Id));
            if(!result.Success)
            {
                return new UpdateBookStatusCommandResponse { Result = result };
            }

            var bookStatus = mapper.Map<BookHive.Domain.Entities.BookStatus>(request.BookStatusUpdateDto);

            bookStatusWriteRepository.Update(bookStatus);
            await bookStatusWriteRepository.SaveAsync();

            return new UpdateBookStatusCommandResponse
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
