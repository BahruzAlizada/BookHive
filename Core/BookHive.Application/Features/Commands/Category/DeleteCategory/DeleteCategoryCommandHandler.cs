
using BookHive.Application.Abstracts.Services;
using BookHive.Application.ConstMessages;
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
            BookHive.Domain.Entities.Category? category = await categoryReadRepository.GetSingleAsync(x=>x.Id==request.Id);
            if (category == null)
                return new DeleteCategoryCommandResponse
                {
                    Result = new Parametres.ResponseParametres.Result
                    {
                        Success = false,
                        Message = Messages.IdNull
                    }
                };


            categoryWriteRepository.Remove(category);
            await categoryWriteRepository.SaveAsync();

            return new DeleteCategoryCommandResponse
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
