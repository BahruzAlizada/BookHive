using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using MediatR;

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
            List<AuthorDto> authorDtos = await authorReadRepository.GetAuthorDtosAsync();
            return new GetAllAuthorQueryResponse
            {
                AuthorDtos = authorDtos,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessListed
                }
            };
        }
    }
}
