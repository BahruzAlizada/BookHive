using BookHive.Application.Abstracts.Services.Dapper;
using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Queries.Genre.GetByIdGenre
{
    public class GetByIdGenreQueryHandler : IRequestHandler<GetByIdGenreQueryRequest, GetByIdGenreQueryResponse>
    {
        private readonly IGenreReadDapper genreReadDapper;
        public GetByIdGenreQueryHandler(IGenreReadDapper genreReadDapper)
        {
            this.genreReadDapper = genreReadDapper;
        }


        public async Task<GetByIdGenreQueryResponse> Handle(GetByIdGenreQueryRequest request, CancellationToken cancellationToken)
        {
            var genre = await genreReadDapper.GetGenreAsync(request.Id);
            if (genre == null) return new() { Result = new ErrorResult(Messages.IdNull) };
           

            GenreDto genreDto = genre.Adapt<GenreDto>();
            return new GetByIdGenreQueryResponse { GenreDto = genreDto, Result = new SuccessResult(Messages.SuccessGetFiltered) };
        }
    }
}
