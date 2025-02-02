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
        private readonly IAuthorReadRepository authorReadRepository;
        public GetAllAuthorQueryHandler(IAuthorReadRepository authorReadRepository)
        {
            this.authorReadRepository = authorReadRepository;
        }


        public async Task<GetAllAuthorQueryResponse> Handle(GetAllAuthorQueryRequest request, CancellationToken cancellationToken)
        {
            List<BookHive.Domain.Entities.Author> authors = await authorReadRepository.GetAll().ToListAsync();
            List<AuthorDto> authorDtos = authors.Adapt<List<AuthorDto>>();

            return new GetAllAuthorQueryResponse { AuthorDtos = authorDtos, Result = new SuccessResult(Messages.SuccessListed) };
        }
    }
}
