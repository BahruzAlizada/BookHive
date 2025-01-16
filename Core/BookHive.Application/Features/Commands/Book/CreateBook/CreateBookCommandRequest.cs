using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Book.CreateBook
{
    public class CreateBookCommandRequest : IRequest<CreateBookCommandResponse>
    {
        public BookAddDto BookAddDto { get; set; }
    }
}
