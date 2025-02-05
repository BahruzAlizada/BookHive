using BookHive.Application.Repositories;
using BookHive.Domain.Entities;

namespace BookHive.Application.Abstracts.Services.EntityFramework
{
    public interface IFriendshipWriteRepository : IWriteRepository<Friendship>
    {
        Task SendRequestAsync(Guid requesterId, Guid addresseeId);
        Task RespondToRequest(Guid friendshipId, bool accept);
    }
}
