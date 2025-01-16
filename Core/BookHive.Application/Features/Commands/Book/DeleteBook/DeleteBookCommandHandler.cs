

using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using MediatR;

namespace BookHive.Application.Features.Commands.Book.DeleteBook
{
    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommandRequest, DeleteBookCommandResponse>
    {
        private readonly IBookReadRepository bookReadRepository;
        private readonly IBookWriteRepository bookWriteRepository;
        public DeleteBookCommandHandler(IBookReadRepository bookReadRepository, IBookWriteRepository bookWriteRepository)
        {
            this.bookReadRepository = bookReadRepository;
            this.bookWriteRepository = bookWriteRepository;
        }



        public async Task<DeleteBookCommandResponse> Handle(DeleteBookCommandRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Entities.Book? book = await bookReadRepository.GetSingleAsync(x=>x.Id==request.Id);
            if (book == null)
            {
                return new DeleteBookCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            bookWriteRepository.Remove(book);
            await bookWriteRepository.SaveAsync();

            return new DeleteBookCommandResponse
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
