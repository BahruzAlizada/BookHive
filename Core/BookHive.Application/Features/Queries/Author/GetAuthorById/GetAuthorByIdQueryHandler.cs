using BookHive.Application.Abstracts.Services.Dapper;
using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Domain.Entities;
using Mapster;
using MediatR;

namespace BookHive.Application.Features.Queries.Author.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQueryRequest, GetAuthorByIdQueryResponse>
    {
        private readonly IAuthorReadDapper authorReadDapper;
        public GetAuthorByIdQueryHandler(IAuthorReadDapper authorReadDapper)
        {
            this.authorReadDapper = authorReadDapper;
        }


        public async Task<GetAuthorByIdQueryResponse> Handle(GetAuthorByIdQueryRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Entities.Author? author = await authorReadDapper.GetAuthorAsync(request.Id);
            if (author == null) return new() { Result = new ErrorResult(Messages.IdNull) };
           

            AuthorDto authorDto = author.Adapt<AuthorDto>();
            return new GetAuthorByIdQueryResponse { AuthorDto = authorDto, Result = new SuccessResult(Messages.SuccessGetFiltered) };
        }
    }
}
