
using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.BookStatus.UpdateBookStatus
{
    public class UpdateBookStatusCommandRequest : IRequest<UpdateBookStatusCommandResponse>
    {
        public BookStatusUpdateDto BookStatusUpdateDto { get; set; }
    }
}
