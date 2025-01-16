using AutoMapper;
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Application.Features.Queries.BookStatus.GetAllBookStatus
{
    public class GetAllBookStatusQueryHandler : IRequestHandler<GetAllBookStatusQueryRequest, GetAllBookStatusQueryResponse>
    {
        private readonly IBookStatusReadRepository bookStatusReadRepository;
        private readonly IMapper mapper;
        public GetAllBookStatusQueryHandler(IBookStatusReadRepository bookStatusReadRepository, IMapper mapper)
        {
            this.bookStatusReadRepository = bookStatusReadRepository;
            this.mapper = mapper;
        }


        public async Task<GetAllBookStatusQueryResponse> Handle(GetAllBookStatusQueryRequest request, CancellationToken cancellationToken)
        {
            var bookStasuses = await bookStatusReadRepository.GetAll(false).ToListAsync();
            List<BookStatusDto> bookStatusDtos = mapper.Map<List<BookStatusDto>>(bookStasuses);

            return new GetAllBookStatusQueryResponse
            {
                bookStatusDtos = bookStatusDtos,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessListed
                }
            };
        }
    }
}
