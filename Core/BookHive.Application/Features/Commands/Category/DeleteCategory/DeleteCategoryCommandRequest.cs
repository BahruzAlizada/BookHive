using MediatR;

namespace BookHive.Application.Features.Commands.Category.DeleteCategory
{
    public class DeleteCategoryCommandRequest : IRequest<DeleteCategoryCommandResponse>
    {
        public Guid Id { get; set; }
    }
}
