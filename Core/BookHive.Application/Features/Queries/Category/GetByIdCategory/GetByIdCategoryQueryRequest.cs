using MediatR;

namespace BookHive.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryRequest : IRequest<GetByIdCategoryQueryResponse>
    {
        public Guid Id { get; set; }
    }
}
