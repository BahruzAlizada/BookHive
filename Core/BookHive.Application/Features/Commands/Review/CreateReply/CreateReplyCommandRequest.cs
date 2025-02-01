using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Review.CreateReply
{
    public class CreateReplyCommandRequest : IRequest<CreateReplyCommandResponse>
    {
        public ReplyAddDto ReplyAddDto { get; set; }
    }
}