

using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Validation.FluentValidation.FriendshipValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Friendship.SendRequestFriend
{
    public class SendRequestFriendCommandHandler : IRequestHandler<SendRequestFriendCommandRequest, SendRequestFriendCommandResponse>
    {
        private readonly IFriendshipWriteRepository friendshipWriteRepository;
        public SendRequestFriendCommandHandler(IFriendshipWriteRepository friendshipWriteRepository)
        {
            this.friendshipWriteRepository = friendshipWriteRepository;
        }


        public async Task<SendRequestFriendCommandResponse> Handle(SendRequestFriendCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new SendRequestValidator(), request.SendRequestDto);
            if(!validationResult.Success) return new() { Result = validationResult };

            await friendshipWriteRepository.SendRequestAsync(request.SendRequestDto.RequesterId, request.SendRequestDto.AddresseeId);
            return new() { Result = new SuccessResult("Success Friend Request") };
        }
    }
}
