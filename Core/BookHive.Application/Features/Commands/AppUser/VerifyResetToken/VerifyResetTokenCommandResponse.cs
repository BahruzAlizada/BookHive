
using BookHive.Application.Parametres.ResponseParametres;

namespace BookHive.Application.Features.Commands.AppUser.VerifyResetToken
{
    public class VerifyResetTokenCommandResponse
    {
        public Result Result { get; set; }
        public bool? State {  get; set; }
    }
}
