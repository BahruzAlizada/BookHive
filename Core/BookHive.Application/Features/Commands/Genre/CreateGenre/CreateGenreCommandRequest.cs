using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Genre.CreateGenre
{
    public class CreateGenreCommandRequest : IRequest<CreateGenreCommandResponse>
    {
        public GenreAddDto GenreAddDto { get; set; }
    }
}
