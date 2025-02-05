using BookHive.Application.Abstracts.Services.EntityFramework;
using BookHive.Domain.Entities;
using BookHive.Domain.Enums;
using BookHive.Domain.Identity;
using BookHive.Persistence.Concrete;
using BookHive.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Persistence.Services.EntityFramework
{
    public class FriendshipWriteRepository : WriteRepository<Friendship>, IFriendshipWriteRepository
    {
        private readonly Context context;
        private readonly UserManager<AppUser> userManager;
        public FriendshipWriteRepository(Context context, UserManager<AppUser> userManager) : base(context)
        {
            this.context = context;
            this.userManager = userManager;
        }

        public async Task RespondToRequest(Guid friendshipId, bool accept)
        {
            Friendship? friendship = await context.Friendships.FindAsync(friendshipId);
            if (friendship == null)
                throw new Exception("Request not found");

            if (accept)
            {
                friendship.Status = FriendshipStatus.Accepted;
                friendship.RespondedAt = DateTime.UtcNow.AddHours(4);
                context.Friendships.Update(friendship);
            }
            else
                context.Friendships.Remove(friendship);

            await context.SaveChangesAsync();
        }

        public async Task SendRequestAsync(Guid requesterId, Guid addresseeId)
        {
            if (requesterId == addresseeId)
                throw new InvalidOperationException("You cannot send a friend request to yourself.");

            AppUser? requestUser = await userManager.FindByIdAsync(requesterId.ToString());
            AppUser? addresseUser = await userManager.FindByIdAsync(addresseeId.ToString());
            if (requesterId == null)
                throw new Exception("RequesterUser not found");
            if (addresseUser == null)
                throw new Exception("AdreeseUser not found");


            var existingRequest = await context.Friendships.FirstOrDefaultAsync(f =>
          (f.RequesterId == requesterId && f.AddresseeId == addresseeId) || (f.RequesterId == addresseeId && f.AddresseeId == requesterId));
            if (existingRequest != null)
                throw new InvalidOperationException("Friend request already exists or you are already friends.");

            Friendship friendship = new Friendship
            {
                RequesterId = requesterId,
                AddresseeId = addresseeId,
                Status = FriendshipStatus.Pending
            };

            await context.Friendships.AddAsync(friendship);
            await context.SaveChangesAsync();
        }


    }
}
