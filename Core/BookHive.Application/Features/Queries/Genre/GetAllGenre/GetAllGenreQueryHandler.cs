using BookHive.Application.Abstracts.Services.Dapper;
using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Domain.Entities;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Queries.Genre.GetAllGenre
{
    public class GetAllGenreQueryHandler : IRequestHandler<GetAllGenreQueryRequest, GetAllGenreQueryResponse>
    {
        private readonly IGenreReadDapper genreReadDapper;
        public GetAllGenreQueryHandler(IGenreReadDapper genreReadDapper)
        {
            this.genreReadDapper = genreReadDapper; 
        }


        public async Task<GetAllGenreQueryResponse> Handle(GetAllGenreQueryRequest request, CancellationToken cancellationToken)
        {
            var genres = await genreReadDapper.GetGenresAsync(request.categoryId);

            List<GenreDto> genreDtos = genres.Adapt<List<GenreDto>>();
            return new() { GenreDtos = genreDtos, Result = new SuccessResult(Messages.SuccessAdded) };
        }
    }
}
