using BookHive.Application.Abstracts.Services;
using BookHive.Application.Constants;
using BookHive.Application.Parametres.ResponseParametres;
using MediatR;

namespace BookHive.Application.Features.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest, DeleteCategoryCommandResponse>
    {
        private readonly ICategoryReadRepository categoryReadRepository;
        private readonly ICategoryWriteRepository categoryWriteRepository;
        public DeleteCategoryCommandHandler(ICategoryReadRepository categoryReadRepository,ICategoryWriteRepository categoryWriteRepository)
        {
            this.categoryReadRepository = categoryReadRepository;
            this.categoryWriteRepository = categoryWriteRepository;
        }


        public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Entities.Category? category = await categoryReadRepository.GetFindAsync(request.Id);
            if (category == null) return new() { Result = new ErrorResult(Messages.IdNull) };

            categoryWriteRepository.Remove(category);
            await categoryWriteRepository.SaveAsync();

            return new() { Result = new SuccessResult(Messages.SuccessDeleted) };
        }
    }
}
