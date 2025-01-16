using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Category.UpdateCategory
{
    public class UpdateCategoryCommandRequest : IRequest<UpdateCategoryCommandResponse>
    {
        public CategoryUpdateDto CategoryUpdateDto { get; set; }
    }
}
