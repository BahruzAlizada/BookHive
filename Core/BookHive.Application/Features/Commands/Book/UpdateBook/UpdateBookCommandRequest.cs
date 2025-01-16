using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Book.UpdateBook
{
    public class UpdateBookCommandRequest : IRequest<UpdateBookCommandResponse>
    {
        public BookUpdateDto BookUpdateDto { get; set; }
    }
}
