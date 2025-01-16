

using AutoMapper;
using BookHive.Application.ConstMessages;
using BookHive.Application.DTOs;
using BookHive.Application.Exceptions;
using BookHive.Domain.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BookHive.Application.Features.Queries.AppUser.GetByIdUser
{
    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQueryRequest, GetByIdUserQueryResponse>
    {
        private readonly UserManager<BookHive.Domain.Identity.AppUser> userManager;
        private readonly IMapper mapper;
        public GetByIdUserQueryHandler(UserManager<BookHive.Domain.Identity.AppUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }


        public async Task<GetByIdUserQueryResponse> Handle(GetByIdUserQueryRequest request, CancellationToken cancellationToken)
        {
            BookHive.Domain.Identity.AppUser? user = await userManager.Users.FirstOrDefaultAsync(x=>x.Id==request.Id);
            if (user == null)
                throw new UserNotFoundException();

            UserDto userDto = mapper.Map<UserDto>(user);

            return new GetByIdUserQueryResponse
            {
                UserDto = userDto,
                Result = new Parametres.ResponseParametres.Result
                {
                    Success = true,
                    Message = Messages.SuccessGetFiltered
                }
            };
        }
    }
}
