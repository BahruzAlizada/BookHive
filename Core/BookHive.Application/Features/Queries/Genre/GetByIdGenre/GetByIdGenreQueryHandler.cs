using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Queries.Genre.GetByIdGenre
{
    public class GetByIdGenreQueryHandler : IRequestHandler<GetByIdGenreQueryRequest, GetByIdGenreQueryResponse>
    {
        private readonly IGenreReadRepository genreReadRepository;
        public GetByIdGenreQueryHandler(IGenreReadRepository genreReadRepository)
        {
            this.genreReadRepository = genreReadRepository;
        }


        public async Task<GetByIdGenreQueryResponse> Handle(GetByIdGenreQueryRequest request, CancellationToken cancellationToken)
        {
            GenreDto? genreDto = await genreReadRepository.GetGenreDtoAsync(request.Id);
            if (genreDto==null)
            {
                return new GetByIdGenreQueryResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }


            return new GetByIdGenreQueryResponse
            {
                GenreDto = genreDto,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessGetFiltered
                }
            };
        }
    }
}
