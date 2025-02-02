using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Application.Constants;
using BookHive.Application.Parametres.ResponseParametres;
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
            BookHive.Domain.Entities.Author? author = await authorReadRepository.GetFindAsync(request.Id);
            if (author == null) return new() { Result = new ErrorResult(Messages.IdNull) };
            

            authorWriteRepository.Remove(author);
            await authorWriteRepository.SaveAsync();
            return new DeleteAuthorCommandResponse { Result = new SuccessResult(Messages.SuccessDeleted) };
            

        }
    }
}
