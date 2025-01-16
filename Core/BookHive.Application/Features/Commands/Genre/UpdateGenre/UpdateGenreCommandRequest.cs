using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Genre.UpdateGenre
{
    public class UpdateGenreCommandRequest : IRequest<UpdateGenreCommandResponse>
    {
        public GenreUpdateDto GenreUpdateDto { get; set; }
    }
}
