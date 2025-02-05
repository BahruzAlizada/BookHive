using BookHive.Application.Abstracts.Services.Dapper;
using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Domain.Entities;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Application.Features.Queries.Author.GetAllAuthor
{
    public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQueryRequest, GetAllAuthorQueryResponse>
    {
        private readonly IAuthorReadDapper authorReadDapper;
        public GetAllAuthorQueryHandler(IAuthorReadDapper authorReadDapper)
        {
            this.authorReadDapper = authorReadDapper;
        }


        public async Task<GetAllAuthorQueryResponse> Handle(GetAllAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            List<BookHive.Domain.Entities.Author> authors = await authorReadDapper.GetAuthorsAsync();
            List<AuthorDto> authorDtos = authors.Adapt<List<AuthorDto>>();

            return new GetAllAuthorQueryResponse { AuthorDtos = authorDtos, Result = new SuccessResult(Messages.SuccessListed) };
        }
    }
}
