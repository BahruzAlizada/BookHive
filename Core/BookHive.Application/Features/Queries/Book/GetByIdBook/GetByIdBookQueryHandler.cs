using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Queries.Book.GetByIdBook
{
    public class GetByIdBookQueryHandler : IRequestHandler<GetByIdBookQueryRequest, GetByIdBookQueryResponse>
    {
        private readonly IBookReadRepository bookReadRepository;
        public GetByIdBookQueryHandler(IBookReadRepository bookReadRepository)
        {
            this.bookReadRepository = bookReadRepository;
        }


        public async Task<GetByIdBookQueryResponse> Handle(GetByIdBookQueryRequest request, CancellationToken cancellationToken)
        {
            //BookDto? bookDto = await bookReadRepository.GetBookAsync(request.Id);
            //if(bookDto == null)
            //{
            //    return new GetByIdBookQueryResponse
            //    {
            //        Result = new Parametres.ResponseParametres.Result
            //        {
            //            Success = false,
            //            Message = Messages.IdNull
            //        }
            //    };
            //}

            //return new GetByIdBookQueryResponse
            //{
            //    BookDto = bookDto,
            //    Result = new Parametres.ResponseParametres.Result
            //    {
            //        Success = true,
            //        Message = Messages.SuccessGetFiltered
            //    }
            //};
            throw new NotImplementedException();
        }
    }
}
