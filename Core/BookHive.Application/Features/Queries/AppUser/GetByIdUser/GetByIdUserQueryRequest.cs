
using MediatR;

namespace BookHive.Application.Features.Queries.AppUser.GetByIdUser
{
    public class GetByIdUserQueryRequest : IRequest<GetByIdUserQueryResponse>
    {
        public Guid Id {  get; set; }
    }
}
