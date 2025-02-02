using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using MediatR;

namespace BookHive.Application.Features.Commands.Genre.DeleteGenre
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommandRequest, DeleteGenreCommandResponse>
    {
        private readonly IGenreReadRepository genreReadRepository;
        private readonly IGenreWriteRepository genreWriteRepository;
        public DeleteGenreCommandHandler(IGenreReadRepository genreReadRepository,IGenreWriteRepository genreWriteRepository)
        {
            this.genreReadRepository = genreReadRepository; 
            this.genreWriteRepository = genreWriteRepository;
        }
        public async Task<DeleteGenreCommandResponse> Handle(DeleteGenreCommandRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Entities.Genre? genre = await genreReadRepository.GetSingleAsync(x=>x.Id == request.Id);
            if(genre == null)
            {
                return new DeleteGenreCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            genreWriteRepository.Remove(genre);
            await genreWriteRepository.SaveAsync();

            return new DeleteGenreCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessDeleted
                }
            };
        }
    }
}
