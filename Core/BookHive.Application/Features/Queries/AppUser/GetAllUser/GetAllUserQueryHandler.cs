

using AutoMapper;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Application.Features.Queries.AppUser.GetAllUser
{
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQueryRequest, GetAllUserQueryResponse>
    {
        private readonly UserManager<BookHive.Domain.Identity.AppUser> userManager;
        private readonly IMapper mapper;
        public GetAllUserQueryHandler(UserManager<BookHive.Domain.Identity.AppUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }


        public async Task<GetAllUserQueryResponse> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
        {
            List<BookHive.Domain.Identity.AppUser> users = await userManager.Users.ToListAsync();
            List<UserDto> userDtos = mapper.Map<List<UserDto>>(users);

            return new GetAllUserQueryResponse
            {
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessListed
                },
                UserDtos = userDtos
            };
        }
    }
}
