using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.BookStatus.CreateBookStatus
{
    public class CreateBookStatusCommandRequest : IRequest<CreateBookStatusCommandResponse> 
    {
        public BookStatusAddDto BookStatusAddDto { get; set; }
    }
}
