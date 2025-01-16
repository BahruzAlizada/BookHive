

using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using MediatR;

namespace BookHive.Application.Features.Queries.Genre.GetAllGenre
{
    public class GetAllGenreQueryHandler : IRequestHandler<GetAllGenreQueryRequest, GetAllGenreQueryResponse>
    {
        private readonly IGenreReadRepository genreReadRepository;
        public GetAllGenreQueryHandler(IGenreReadRepository genreReadRepository)
        {
            this.genreReadRepository = genreReadRepository; 
        }


        public async Task<GetAllGenreQueryResponse> Handle(GetAllGenreQueryRequest request, CancellationToken cancellationToken)
        {
            var genres = await genreReadRepository.GetGenreDtosAsync(request.categoryId);
            return new GetAllGenreQueryResponse
            {
                GenreDtos = genres,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessListed
                }
            };
        }
    }
}
