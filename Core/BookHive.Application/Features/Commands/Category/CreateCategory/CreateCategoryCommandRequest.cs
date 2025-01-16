using BookHive.Application.DTOs;
using MediatR;

namespace BookHive.Application.Features.Commands.Category.CreateCategory
{
    public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResponse>
    {
        public CategoryAddDto CategoryAddDto { get; set; }
    }
}
