
using MediatR;

namespace BookHive.Application.Features.Commands.Genre.DeleteGenre
{
    public class DeleteGenreCommandRequest : IRequest<DeleteGenreCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
