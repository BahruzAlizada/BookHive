

using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using MediatR;

namespace BookHive.Application.Features.Commands.BookStatus.DeleteBookStatus
{
    public class DeleteBookStatusCommandHandler : IRequestHandler<DeleteBookStatusCommandRequest, DeleteBookStatusCommandResponse>
    {
        private readonly IBookStatusReadRepository bookStatusReadRepository;
        private readonly IBookStatusWriteRepository bookStatusWriteRepository;
        public DeleteBookStatusCommandHandler(IBookStatusReadRepository bookStatusReadRepository, IBookStatusWriteRepository bookStatusWriteRepository)
        {
            this.bookStatusReadRepository = bookStatusReadRepository;
            this.bookStatusWriteRepository = bookStatusWriteRepository;
        }
        public async Task<DeleteBookStatusCommandResponse> Handle(DeleteBookStatusCommandRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Entities.BookStatus? bookStatus = await bookStatusReadRepository.GetSingleAsync(x=>x.Id == request.Id);
            if (bookStatus == null)
            {
                return new DeleteBookStatusCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }


            bookStatusWriteRepository.Remove(bookStatus);
            await bookStatusWriteRepository.SaveAsync();

            return new DeleteBookStatusCommandResponse
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
