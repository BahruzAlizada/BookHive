using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Queries.BookStatus.GetByIdBookStatus
{
    public class GetByIdBookStatusQueryHandler : IRequestHandler<GetByIdBookStatusQueryRequest, GetByIdBookStatusQueryResponse>
    {
        private readonly IBookStatusReadRepository bookStatusReadRepository;
        private readonly IMapper mapper;
        public GetByIdBookStatusQueryHandler(IBookStatusReadRepository bookStatusReadRepository, IMapper mapper)
        {
            this.bookStatusReadRepository = bookStatusReadRepository;
            this.mapper = mapper;
        }


        public async Task<GetByIdBookStatusQueryResponse> Handle(GetByIdBookStatusQueryRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Entities.BookStatus? bookStatus = await bookStatusReadRepository.GetSingleAsync(x=>x.Id == request.Id);
            if (bookStatus == null)
            {
                return new GetByIdBookStatusQueryResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            BookStatusDto bookStatusDto = mapper.Map<BookStatusDto>(bookStatus);
            return new GetByIdBookStatusQueryResponse
            {
                BookStatusDto = bookStatusDto,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessGetFiltered
                }
            };

        }
    }
}
