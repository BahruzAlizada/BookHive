
using System.Diagnostics;
using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Queries.BookLanguage.GetByIdBookLanguage
{
    public class GetByIdBookLanguageQueryHandler : IRequestHandler<GetByIdBookLanguageQueryRequest, GetByIdBookLanguageQueryResponse>
    {
        private readonly IBookLanguageReadRepository bookLanguageReadRepository;
        private readonly IMapper mapper;
        public GetByIdBookLanguageQueryHandler(IBookLanguageReadRepository bookLanguageReadRepository, IMapper mapper)
        {
            this.bookLanguageReadRepository = bookLanguageReadRepository;
            this.mapper = mapper;
        }

        public async Task<GetByIdBookLanguageQueryResponse> Handle(GetByIdBookLanguageQueryRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Entities.BookLanguage? bookLanguage = await bookLanguageReadRepository.GetSingleAsync(x => x.Id == request.Id);
            if (bookLanguage == null)
            {
                return new GetByIdBookLanguageQueryResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            BookLanguageDto bookLanguageDto = mapper.Map<BookLanguageDto>(bookLanguage);

            return new GetByIdBookLanguageQueryResponse
            {
                BookLanguageDto = bookLanguageDto,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessGetFiltered
                }
            };

        }
    }
}
