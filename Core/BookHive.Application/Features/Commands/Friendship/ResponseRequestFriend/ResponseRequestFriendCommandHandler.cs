
using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Extensions.FluentValidationExtension;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Validation.FluentValidation.FriendshipValidator;
using MediatR;

namespace BookHive.Application.Features.Commands.Friendship.ResponseRequestFriend
{
    public class ResponseRequestFriendCommandHandler : IRequestHandler<ResponseRequestFriendCommandRequest, ResponseRequestFriendCommandResponse>
    {
        private readonly IFriendshipWriteRepository friendshipWriteRepository;
        public ResponseRequestFriendCommandHandler(IFriendshipWriteRepository friendshipWriteRepository)
        {
            this.friendshipWriteRepository = friendshipWriteRepository;
        }


        public async Task<ResponseRequestFriendCommandResponse> Handle(ResponseRequestFriendCommandRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await ValidationExtension.ValidatorResult(new ResponseRequestValidator(), request.ResponseRequestDto);
            if (!validationResult.Success) return new() { Result = validationResult };

            await friendshipWriteRepository.RespondToRequest(request.ResponseRequestDto.FriendshipId,request.ResponseRequestDto.Accept);
            return new() { Result = new SuccessResult("Respond to Request") };
        }
    }
}
