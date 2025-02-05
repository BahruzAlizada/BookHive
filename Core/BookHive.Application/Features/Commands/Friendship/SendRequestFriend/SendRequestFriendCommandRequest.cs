using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Friendship.SendRequestFriend
{
    public class SendRequestFriendCommandRequest : IRequest<SendRequestFriendCommandResponse>
    {
        public SendRequestDto SendRequestDto { get; set; }
    }
}