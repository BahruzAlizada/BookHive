

using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
using MediatR;

namespace BookHive.Application.Features.Commands.Author.DeleteAuthor
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommandRequest, DeleteAuthorCommandResponse>
    {
        private readonly IAuthorReadRepository authorReadRepository;
        private readonly IAuthorWriteRepository authorWriteRepository;
        public DeleteAuthorCommandHandler(IAuthorReadRepository authorReadRepository, IAuthorWriteRepository authorWriteRepository)
        {
            this.authorReadRepository = authorReadRepository;
            this.authorWriteRepository = authorWriteRepository;
        }


        public async Task<DeleteAuthorCommandResponse> Handle(DeleteAuthorCommandRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Entities.Author? author = await authorReadRepository.GetSingleAsync(x => x.Id == request.Id);
            if (author == null)
            {
                return new DeleteAuthorCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };
            }

            authorWriteRepository.Remove(author);
            await authorWriteRepository.SaveAsync();

            return new DeleteAuthorCommandResponse
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
