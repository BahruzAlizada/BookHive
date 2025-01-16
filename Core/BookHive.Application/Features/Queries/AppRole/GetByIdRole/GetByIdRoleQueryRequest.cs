using MediatR;

namespace BookHive.Application.Features.Queries.AppRole.GetByIdRole
{
    public class GetByIdRoleQueryRequest : IRequest<GetByIdRoleQueryResponse>
    {
        public Guid Id { get; set; }
    }
}