

using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs.Book;
using MediatR;

namespace BookHive.Application.Features.Queries.Book.GetAllBook
{
    public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQueryRequest, GetAllBookQueryResponse>
    {
        private readonly IBookReadRepository bookReadRepository;
        public GetAllBookQueryHandler(IBookReadRepository bookReadRepository)
        {
            this.bookReadRepository = bookReadRepository;
        }


        public async Task<GetAllBookQueryResponse> Handle(GetAllBookQueryRequest request, CancellationToken cancellationToken)
        {
            List<BookDto> bookDtos = await bookReadRepository.GetBookDtosAsync();

            return new GetAllBookQueryResponse
            {
                BookDtos = bookDtos,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessListed
                }
            };
        }
    }
}
