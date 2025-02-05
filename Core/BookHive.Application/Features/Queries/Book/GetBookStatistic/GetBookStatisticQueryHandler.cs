using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.DTOs;
using BookHive.Application.Parametres.ResponseParametres;
using MediatR;

namespace BookHive.Application.Features.Queries.Book.GetBookStatistic
{
    public class GetBookStatisticQueryHandler : IRequestHandler<GetBookStatisticQueryRequest, GetBookStatisticQueryResponse>
    {
        private readonly IBookStatisticReadRepository bookStatisticReadRepository;
        public GetBookStatisticQueryHandler(IBookStatisticReadRepository bookStatisticReadRepository)
        {
            this.bookStatisticReadRepository = bookStatisticReadRepository;
        }


        public async Task<GetBookStatisticQueryResponse> Handle(GetBookStatisticQueryRequest request, CancellationToken cancellationToken)
        {
            BookStatisticDto bookStatistic = await bookStatisticReadRepository.GetBookStatistic(request.BookId);
            if (bookStatistic == null) return new() { Result = new ErrorResult(Messages.IdNull) };

            return new() { BookStatisticDto = bookStatistic, Result = new SuccessResult(Messages.SuccessGetFiltered) };
        }
    }
}
