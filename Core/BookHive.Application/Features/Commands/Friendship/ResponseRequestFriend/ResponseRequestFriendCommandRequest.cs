using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Friendship.ResponseRequestFriend
{
    public class ResponseRequestFriendCommandRequest : IRequest<ResponseRequestFriendCommandResponse>
    {
        public ResponseRequestDto ResponseRequestDto { get; set; }
    }
}