

using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Queries.Author.GetAuthorById
{
    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQueryRequest, GetAuthorByIdQueryResponse>
    {
        private readonly IAuthorReadRepository authorReadRepository;
        public GetAuthorByIdQueryHandler(IAuthorReadRepository authorReadRepository)
        {
            this.authorReadRepository = authorReadRepository;
        }


        public async Task<GetAuthorByIdQueryResponse> Handle(GetAuthorByIdQueryRequest request, CancellationToken cancellationToken)
        {
            AuthorDto? authorDto = await authorReadRepository.GetAuthorDtoAsync(request.Id);
            if(authorDto == null)
            {
                return new GetAuthorByIdQueryResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            return new GetAuthorByIdQueryResponse
            {
                AuthorDto = authorDto,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessGetFiltered
                }
            };

        }
    }
}
