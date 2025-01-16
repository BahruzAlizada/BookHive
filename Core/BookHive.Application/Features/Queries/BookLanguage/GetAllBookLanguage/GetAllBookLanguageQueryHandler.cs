

using AutoMapper;
using BookHive.Application.Abstracts.Caching;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;
using BookHive.Application.Utilities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace BookHive.Application.Features.Queries.BookLanguage.GetAllBookLanguage
{
    public class GetAllBookLanguageQueryHandler : IRequestHandler<GetAllBookLanguageQueryRequest, GetAllBookLanguageQueryResponse>
    {
        private readonly IBookLanguageReadRepository bookLanguageReadRepository;
        private readonly IMapper mapper;
        private readonly ICacheService cacheService;
        public GetAllBookLanguageQueryHandler(IBookLanguageReadRepository bookLanguageReadRepository, IMapper mapper,ICacheService cacheService)
        {
            this.bookLanguageReadRepository = bookLanguageReadRepository;
            this.mapper = mapper;
            this.cacheService = cacheService;
        }


        public async Task<GetAllBookLanguageQueryResponse> Handle(GetAllBookLanguageQueryRequest request, CancellationToken cancellationToken)
        {
            using PerformanceMeter meter = new PerformanceMeter("GetAllBookLanguageQueryHandler");
            List<BookLanguageDto> bookLanguageDtos;


            bookLanguageDtos = cacheService.Get<List<BookLanguageDto>>(CacheKeys.BookLanguage);
            if (bookLanguageDtos == null)
            {
                List<BookHive.Domain.Entities.BookLanguage> bookLanguages = await bookLanguageReadRepository.GetAll().ToListAsync();
                bookLanguageDtos = mapper.Map<List<BookLanguageDto>>(bookLanguages);

                cacheService.Set(CacheKeys.BookLanguage, bookLanguageDtos,5,15);
            }


            return new GetAllBookLanguageQueryResponse
            {
                BookLanguages = bookLanguageDtos,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessListed
                }
            };
        }
    }
}
