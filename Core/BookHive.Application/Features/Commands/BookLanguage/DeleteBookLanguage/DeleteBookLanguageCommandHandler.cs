
using BookHive.Application.Abstracts.Caching;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using MediatR;

namespace BookHive.Application.Features.Commands.BookLanguage
{
    public class DeleteBookLanguageCommandHandler : IRequestHandler<DeleteBookLanguageCommandRequest, DeleteBookLanguageCommandResponse>
    {
        private readonly IBookLanguageReadRepository bookLanguageReadRepository;
        private readonly IBookLanguageWriteRepository bookLanguageWriteRepository;
        private readonly ICacheService cacheService;
        public DeleteBookLanguageCommandHandler(IBookLanguageReadRepository bookLanguageReadRepository,IBookLanguageWriteRepository bookLanguageWriteRepository,
            ICacheService cacheService)
        {
            this.bookLanguageReadRepository = bookLanguageReadRepository;
            this.bookLanguageWriteRepository = bookLanguageWriteRepository;
            this.cacheService = cacheService;
        }


        public async Task<DeleteBookLanguageCommandResponse> Handle(DeleteBookLanguageCommandRequest request, CancellationToken cancellationToken)
        {
            var bookLanguage = await bookLanguageReadRepository.GetSingleAsync(x=>x.Id== request.Id);
            if (bookLanguage == null)
            {
                return new DeleteBookLanguageCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            bookLanguageWriteRepository.Remove(bookLanguage);
            await bookLanguageWriteRepository.SaveAsync();

            cacheService.Remove(CacheKeys.BookLanguage);

            return new DeleteBookLanguageCommandResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessDeleted
                }
            };

        }
    }
}
